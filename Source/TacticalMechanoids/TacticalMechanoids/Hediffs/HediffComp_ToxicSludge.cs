using System.Collections.Generic;
using System.Collections;
using System.Linq;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class HediffComp_BurnsOverTime : HediffComp
    {
        private int burnCounter = 0;
        private int blisterCounter = 0;
        private float currentBurnVariance = 0f;
        private float currentBlisterVariance = 0f;

        public HediffCompProperties_BurnsOverTime Props => (HediffCompProperties_BurnsOverTime)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            burnCounter++;
            blisterCounter++;

            float burnTime = (Props.burnRate* (1 + currentBurnVariance)) / (1 + parent.Severity);
            if (burnCounter >= burnTime)
            {
                burnCounter = 0;
                currentBurnVariance = Rand.Range(-Props.burnVariance, Props.burnVariance);
                if (Pawn.health != null)
                {
                    Pawn.TakeDamage(new DamageInfo(DefDatabase<DamageDef>.GetNamed("Burn"), (Props.burnDamage * Rand.Range(-Props.burnDamageVariance, Props.burnDamageVariance)), 0f, -1f, null, null, null, DamageInfo.SourceCategory.ThingOrUnknown, null));
                }
            }

            float blisterTime = (Props.blisterRate * (1 + currentBlisterVariance)) / (1 + parent.Severity);
            if (blisterCounter >= blisterTime)
            {
                if (Pawn.health != null)
                {
                    blisterCounter = 0;
                    currentBlisterVariance = Rand.Range(-Props.blisterVariance, Props.blisterVariance);
                    IEnumerable<BodyPartRecord> injuredBodyParts = Pawn.health.hediffSet.GetInjuredParts();
                    HediffDef burnHediff = HediffDef.Named("Burn");
                    HediffDef blisterHediff = HediffDef.Named("TM_Blister");
                    GenList.Shuffle<BodyPartRecord>(injuredBodyParts.ToList());
                    foreach (BodyPartRecord bodyPart in injuredBodyParts)
                    {
                        if (Pawn.health.hediffSet.HasHediff(burnHediff, bodyPart))
                        {
                            if (Pawn.health.hediffSet.HasHediff(blisterHediff, bodyPart))
                            {
                                List<Hediff> blisters = new List<Hediff>(Pawn.health.hediffSet.hediffs);
                                GenList.Shuffle<Hediff>(blisters);
                                foreach (Hediff blister in blisters)
                                {
                                    if (blister.Part == bodyPart && blister.def == blisterHediff)
                                    {
                                        blister.Severity += .3f;
                                        break;
                                    }
                                }
                            } else
                            {
                                Pawn.health.AddHediff(blisterHediff, bodyPart, null);
                                string message = "TM_DevelopedBlister".Translate(Pawn.Label);
                                Messages.Message(message, MessageTypeDefOf.NegativeEvent);
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}

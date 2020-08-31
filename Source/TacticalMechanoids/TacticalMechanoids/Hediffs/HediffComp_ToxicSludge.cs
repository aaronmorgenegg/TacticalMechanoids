using System.Collections.Generic;
using System.Collections;
using System.Linq;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class HediffComp_ToxicSludge : HediffWithComps
    {
        private int burnCounter = 0;
        private int burnRate = 9000;
        private float burnVariance = 0.25f;
        private float currentBurnVariance = 0f;
        private int burnDamage = 5;
        private float burnDamageVariance = 0.5f;
        private int blisterCounter = 0;
        private int blisterRate = 15000;
        private float blisterVariance = 0.25f;
        private float currentBlisterVariance = 0f;

        public override void Tick()
        {
            base.Tick();
            burnCounter++;
            blisterCounter++;

            float burnTime = (burnRate* (1 + currentBurnVariance)) / (1 + Severity);
            if (burnCounter >= burnTime)
            {
                burnCounter = 0;
                currentBurnVariance = Rand.Range(-burnVariance, burnVariance);
                if (pawn.health != null)
                {
                    pawn.TakeDamage(new DamageInfo(DefDatabase<DamageDef>.GetNamed("Burn"), (burnDamage * Rand.Range(-burnDamageVariance, burnDamageVariance)), 0f, -1f, null, null, null, DamageInfo.SourceCategory.ThingOrUnknown, null));
                }
            }

            float blisterTime = (blisterRate * (1 + currentBlisterVariance)) / (1 + Severity);
            if (blisterCounter >= blisterTime)
            {
                if (pawn.health != null)
                {
                    blisterCounter = 0;
                    currentBlisterVariance = Rand.Range(-blisterVariance, blisterVariance);
                    IEnumerable<BodyPartRecord> injuredBodyParts = pawn.health.hediffSet.GetInjuredParts();
                    HediffDef burnHediff = HediffDef.Named("Burn");
                    // TODO: Randomize list first?
                    foreach (BodyPartRecord bodyPart in injuredBodyParts)
                    {
                        if (pawn.health.hediffSet.HasHediff(burnHediff, bodyPart))
                        {
                            pawn.health.AddHediff(HediffDef.Named("TM_Blister"), bodyPart, null);
                            string message = "TM_DevelopedBlister".Translate(pawn.Label);
                            Messages.Message(message, MessageTypeDefOf.NegativeEvent);
                            break;
                        }
                    }
                }
            }
        }
    }
}

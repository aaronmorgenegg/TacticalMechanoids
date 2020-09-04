using System.Collections.Generic;
using System.Linq;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class HediffComp_BurnsOverTime : HediffComp
    {
        private int burnCounter = 0;
        private float currentBurnVariance = 0f;

        public HediffCompProperties_BurnsOverTime Props => (HediffCompProperties_BurnsOverTime)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            burnCounter++;

            float burnTime = (Props.burnRate* (1 + currentBurnVariance)) / (1 + parent.Severity);
            if (burnCounter >= burnTime)
            {
                burnCounter = 0;
                currentBurnVariance = Rand.Range(-Props.burnVariance, Props.burnVariance);
                if (Pawn.health != null)
                {
                    Pawn.TakeDamage(new DamageInfo(DefDatabase<DamageDef>.GetNamed("TM_ChemicalBurn"), (Props.burnDamage * Rand.Range(1-Props.burnDamageVariance, 1+Props.burnDamageVariance) * parent.Severity), 0.9f, -1f, null, null, null, DamageInfo.SourceCategory.ThingOrUnknown, null));
                }
            }
        }
    }
}

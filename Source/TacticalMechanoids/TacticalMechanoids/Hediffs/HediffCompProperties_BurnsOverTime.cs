using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class HediffCompProperties_BurnsOverTime : HediffCompProperties
    {
        public int burnRate = 9000;
        public float burnVariance = 0.25f;
        public int burnDamage = 10;
        public float burnDamageVariance = 0.5f;
        public int blisterRate = 15000;
        public float blisterVariance = 0.25f;

        public HediffCompProperties_BurnsOverTime()
        {
            this.compClass = typeof(HediffComp_BurnsOverTime);
        }
    }
}

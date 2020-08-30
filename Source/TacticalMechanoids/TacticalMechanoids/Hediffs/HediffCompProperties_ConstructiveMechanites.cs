using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class HediffCompProperties_ConstructiveMechanites : HediffCompProperties
    {
        public float constructiveMechaniteHealStrength = 0.1f;
        public float constructiveMechaniteHealRate = 30;
        public float constructiveMechaniteDuration = 1000;

        public HediffCompProperties_ConstructiveMechanites()
        {
            this.compClass = typeof(HediffCompConstructiveMechanites);
        }
    }
}

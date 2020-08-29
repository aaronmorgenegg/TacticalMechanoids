using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_ConstructiveMechanites : CompProperties
    {
        public float constructiveMechaniteHealStrength = 0.1f;
        public float constructiveMechaniteHealRate = 30;

        public CompProperties_ConstructiveMechanites()
        {
            this.compClass = typeof(CompConstructiveMechanites);
        }
    }
}

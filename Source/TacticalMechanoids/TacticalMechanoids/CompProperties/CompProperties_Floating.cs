using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_Floating : CompProperties
    {
        private bool isFloater = false;
        private bool canCrossWater = false;

        public CompProperties_Floating()
        {
            this.compClass = typeof(CompFloating);
        }
    }
}

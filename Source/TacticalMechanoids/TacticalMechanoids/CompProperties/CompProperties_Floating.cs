using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_Floating : CompProperties
    {
        public bool isFloater = false;
        public bool canCrossWater = false;

        public CompProperties_Floating()
        {
            this.compClass = typeof(CompFloating);
        }
    }
}

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_Burrowing : CompProperties
    {
        public int burrowDuration = 250;
        public int burrowDistance = 25;
        public float chanceToBurrow = 0.1f;

        public CompProperties_Burrowing()
        {
            this.compClass = typeof(CompBurrowing);
        }
    }
}

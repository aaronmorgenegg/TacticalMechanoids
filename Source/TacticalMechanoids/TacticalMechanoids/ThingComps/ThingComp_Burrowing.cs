using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompBurrowing : ThingComp
    {
        private bool isBurrowed = false;
        private int burrowCounter = 0;

        public CompProperties_Burrowing Props
        {
            get
            {
                return (CompProperties_Burrowing)this.props;
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            if (isBurrowed)
            {
                burrowCounter--;
                if (burrowCounter <= 0)
                {
                    // TODO: Pop up at the burrow location
                }
            }
        }

        public void BurrowTowardAttacker(IntVec3 attackerPosition)
        {
            // TODO: Get random, available position between intPosition and attackerPosition
            // TODO: Despawn, create burrowing motes + change sprite to digging.
            isBurrowed = true;
            burrowCounter = Props.burrowDuration;
        }

    }
}

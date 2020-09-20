using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompBurrowing : ThingComp
    {
        private bool isBurrowed = false;
        private int burrowCounter = 0;
        private Map mapToBurrowTo;
        private IntVec3 positionToBurrowTo;

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
                    GenSpawn.Spawn(this.parent, positionToBurrowTo, mapToBurrowTo, WipeMode.Vanish);
                }
            }
        }

        public void BurrowTowardAttacker(IntVec3 attackerPosition)
        {
            // TODO: Get random, available position between intPosition and attackerPosition
            // TODO: Despawn, create burrowing motes + sound + change sprite to digging.
            burrowCounter = Props.burrowDuration; // TODO: adjust the duration based on the distance to burrow
            mapToBurrowTo = this.parent.Map;
            positionToBurrowTo = attackerPosition;
            this.parent.DeSpawn();
            isBurrowed = true;
        }

    }
}

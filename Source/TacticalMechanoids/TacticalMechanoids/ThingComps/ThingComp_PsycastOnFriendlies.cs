using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompPsycastOnFriendlies : ThingComp
    {
        int tickCounter = 0;

        public CompProperties_PsycastOnFriendlies Props
        {
            get
            {
                return (CompProperties_PsycastOnFriendlies)this.props;
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            /*
            tickCounter++;
            if (tickCounter < Props.psycastFrequency)
            {
                
            }*/
        }

    }
}

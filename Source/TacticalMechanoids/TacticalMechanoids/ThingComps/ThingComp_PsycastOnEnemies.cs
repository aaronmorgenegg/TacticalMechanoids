using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompPsycastOnEnemies : ThingComp
    {

        public CompProperties_PsycastOnEnemies Props
        {
            get
            {
                return (CompProperties_PsycastOnEnemies)this.props;
            }
        }

        public void CastPsycast(Pawn pawn)
        {
            if (Rand.Value < Props.psycastChance)
            {
                if (pawn != null & pawn.health != null)
                {
                    string psycastName = Props.psycastsToUse[Rand.Range(0, Props.psycastsToUse.Count)];
                    // TODO: Lookup psycast
                    // TODO: Apply psycast to pawn
                }
            }
        }
    }
}

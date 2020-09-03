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

        public void CastPsycast(Pawn hitPawn, Pawn sourcePawn)
        {
            if (Rand.Value < Props.psycastChance)
            {
                if (hitPawn != null & hitPawn.health != null)
                {
                    if (sourcePawn.psychicEntropy == null)
                    {
                        sourcePawn.psychicEntropy = new Pawn_PsychicEntropyTracker(sourcePawn);
                    }
                    string psycastName = Props.psycastsToUse[Rand.Range(0, Props.psycastsToUse.Count)];
                    AbilityDef psycastDef = DefDatabase<AbilityDef>.GetNamed(psycastName);
                    Psycast psycast = new Psycast(sourcePawn, psycastDef);
                    psycast.Activate(hitPawn, sourcePawn);
                }
            }
        }
    }
}

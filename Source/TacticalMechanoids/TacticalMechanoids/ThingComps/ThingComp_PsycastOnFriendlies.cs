using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompPsycastOnFriendlies : ThingComp
    {
        private int tickCounter = 0;

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
            
            tickCounter++;
            if (tickCounter > Props.psycastFrequency)
            {
                tickCounter = 0;
                if (this.parent is Pawn sourcePawn && sourcePawn != null)
                {
                    bool isAwake = !sourcePawn.Dead && !sourcePawn.Downed && sourcePawn.Map != null && !sourcePawn.stances.stunner.Stunned && sourcePawn.TryGetComp<CompCanBeDormant>().Awake;
                    if (sourcePawn.psychicEntropy == null)
                    {
                        sourcePawn.psychicEntropy = new Pawn_PsychicEntropyTracker(sourcePawn);
                    }
                    if (isAwake)
                    {
                        string psycastName = Props.psycastsToUse[Rand.Range(0, Props.psycastsToUse.Count)];
                        foreach (Thing thing in GenRadial.RadialDistinctThingsAround(sourcePawn.Position, sourcePawn.Map, Props.psycastRange, true))
                        {
                            if (thing != null && thing is Pawn targetPawn && targetPawn != sourcePawn && targetPawn.health != null)
                            {
                                if (targetPawn.RaceProps.IsMechanoid && targetPawn.Faction == Faction.OfMechanoids)
                                {
                                    AbilityDef psycastDef = DefDatabase<AbilityDef>.GetNamed(psycastName);
                                    Psycast psycast = new Psycast(sourcePawn, psycastDef);
                                    psycast.Activate(targetPawn, sourcePawn);
                                    break;
                                }
                            }

                        }
                    }

                }
            }
        }

    }
}

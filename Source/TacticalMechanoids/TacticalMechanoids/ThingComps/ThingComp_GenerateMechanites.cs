using System.Collections.Generic;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompGenerateMechanites : ThingComp
    {
        private int tickCounter = 0;

        public CompProperties_GenerateMechanites Props
        {
            get
            {
                return (CompProperties_GenerateMechanites)this.props;
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            tickCounter++;
            if (this.parent is Pawn pawn && pawn != null & pawn.health != null)
            {
                float mechaniteGeneration = pawn.health.capacities.GetLevel(PawnCapacityDefOf.TM_MechaniteGeneration);
                bool isAwake = !pawn.Dead && !pawn.Downed && pawn.Map != null && pawn.TryGetComp<CompCanBeDormant>().Awake;
                if (mechaniteGeneration > 0 && isAwake && tickCounter >= (this.Props.mechaniteSpawnRate / mechaniteGeneration))
                {
                    foreach (Thing thing in GenRadial.RadialDistinctThingsAround(pawn.Position, pawn.Map, Props.mechaniteRange, true))
                    {
                        if (thing != null && thing is Pawn targetPawn && targetPawn.health != null)
                        {
                            if (targetPawn.RaceProps.IsMechanoid && targetPawn.health.hediffSet.GetFirstHediffOfDef(HediffDef.Named(this.Props.MechanoidMechanitesHediff)) == null)
                            {
                                targetPawn.health.AddHediff(HediffDef.Named(this.Props.MechanoidMechanitesHediff), null, null);
                                break;
                            }
                            if (targetPawn.RaceProps.Humanlike && targetPawn.health.hediffSet.GetFirstHediffOfDef(HediffDef.Named(this.Props.NonMechanoidMechanitesHediff)) == null &&
                                Rand.Value <= this.Props.nonMechanoidChance)
                            {
                                targetPawn.health.AddHediff(HediffDef.Named(this.Props.NonMechanoidMechanitesHediff), null, null);
                                string message = "TM_NonMechanoidContractedMechanites".Translate(targetPawn.Label, pawn.Label);
                                Messages.Message(message, MessageTypeDefOf.NegativeEvent);
                                break;
                            }
                        }
                        
                    }
                    tickCounter = 0;
                }
            }
        }
    }
}

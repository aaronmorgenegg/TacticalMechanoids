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
            Pawn pawn = this.parent as Pawn;
            float mechaniteGeneration = (pawn?.health.capacities.GetLevel(PawnCapacityDefOf.TM_MechaniteGeneration) ?? 0);
            bool isAwake = pawn?.TryGetComp<CompCanBeDormant>().Awake ?? false;
            if (mechaniteGeneration > 0 && isAwake && tickCounter >= (this.Props.mechaniteSpawnRate / mechaniteGeneration))
            {
                if (pawn.health != null)
                {
                    List<Pawn> pawns = pawn.Map.mapPawns.AllPawnsSpawned;
                    for (int i = 0; i < pawns.Count; i++)
                    {
                        if (pawns[i] != null && pawns[i].RaceProps.IsMechanoid && pawns[i].health != null && pawns[i].health.hediffSet.GetFirstHediffOfDef(HediffDef.Named(this.Props.MechanoidMechanitesHediff)) == null && 
                            pawn.Position.DistanceTo(pawns[i].Position) <= this.Props.mechaniteRange)
                        {
                            Hediff hediff = HediffMaker.MakeHediff(HediffDef.Named(this.Props.MechanoidMechanitesHediff), pawns[i], null);
                            pawns[i].health.AddHediff(hediff, null, null);
                            break;
                        }
                        if (pawns[i] != null && pawns[i].RaceProps.Humanlike && pawns[i].health != null && pawns[i].health.hediffSet.GetFirstHediffOfDef(HediffDef.Named(this.Props.NonMechanoidMechanitesHediff)) == null &&
                            pawn.Position.DistanceTo(pawns[i].Position) <= this.Props.mechaniteRange && Rand.Value <= this.Props.nonMechanoidChance)
                        {
                            Hediff hediff = HediffMaker.MakeHediff(HediffDef.Named(this.Props.NonMechanoidMechanitesHediff), pawns[i], null);
                            pawns[i].health.AddHediff(hediff, null, null);
                            string message = TranslatorFormattedStringExtensions.Translate("TM_NonMechanoidContractedMechanites", pawns[i].Label, pawn.Label);
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

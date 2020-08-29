using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class GenerateMechanites : ThingComp
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

            mechaniteSource = (pawn?.GetStatValue(StatDefOf.TM_MechaniteSource) ?? 0);
            isAwakeCheck = pawn?.TryGetComp<Awake>();
            isAwake = isAwakeCheck != null && isAwakeCheck;
            if (mechaniteSource > 0 && isAwake && tickCounter >= (mechaniteSpawnRate / TM_MechaniteSource))
            {
                if (pawn.health != null)
                {
                    List<Pawn> pawns = Pawn.Map.mapPawns.AllSpawnedPawns;
                    for (int i = 0; i < pawns.Count; i++)
                    {
                        if (pawns[i] != null && pawns[i].isMechanoid && pawns[i].health != null && pawns[i].health.hediffSet.GetFirstHediffOfDef(Def.MechanoidMechanitesHediff) == null && pawn.Position.DistanceTo(pawns[i].Position) <= mechaniteRange)
                        {
                            Hediff hediff = HediffMaker.MakeHediff(Def.MechanoidMechanitesHediff, pawns[i], null);
                            pawns[i].health.AddHediff(hediff, null, null);
                            break;
                        }
                        if (pawns[i] != null && pawns[i].RaceProps.Humanlike && pawns[i].health != null && pawns[i].health.hediffSet.GetFirstHediffOfDef(Def.NonMechanoidMechanitesHediff) == null && pawn.Position.DistanceTo(pawns[i].Position) <= mechaniteRange && Rand.Value <= nonMechanoidChance)
                        {
                            Messages.Message("TM_NonMechanoidContractedMechanites".Translate(new object[] {
                                pawn.Label, pawns[i].Label
                            }), MessageSound.Standard);
                            Hediff hediff = HediffMaker.MakeHediff(Def.NonMechanoidMechanitesHediff, pawns[i], null);
                            pawns[i].health.AddHediff(hediff, null, null);
                            break;
                        }
                    }
                }
                tickCounter = 0;
            }
        }
    }
}

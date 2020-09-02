using System.Collections.Generic;

using RimWorld;
using Verse;
using Verse.AI.Group;

namespace TacticalMechanoids
{
    public class DeathActionWorker_SpawnMechanoids : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse)
        {
            LordJob_MechanoidsDefend lordJob = new LordJob_MechanoidsDefend(new List<Thing>() { corpse }, Faction.OfMechanoids, 40, corpse.Position, true, false);
            Lord lord = LordMaker.MakeNewLord(Faction.OfMechanoids, lordJob, corpse.Map, null);
            if (corpse.InnerPawn.GetComp<CompSpawnMechanoidsOnDeath>() is CompSpawnMechanoidsOnDeath spawnComp && spawnComp != null && spawnComp.Props is CompProperties_SpawnMechanoidsOnDeath Props && Props != null)
            {
                float randVariance = Rand.Range(1 - Props.combatPowerVariance, 1 + Props.combatPowerVariance);
                while (spawnComp.spawnedMechanoidsCombatPower < Props.totalCombatPower * randVariance)
                {
                    int randomMechIndex = Rand.Range(0, Props.mechanoidsToChooseFrom.Count);
                    PawnGenerationRequest request = new PawnGenerationRequest(PawnKindDef.Named(Props.mechanoidsToChooseFrom[randomMechIndex]), corpse.Faction, PawnGenerationContext.NonPlayer, -1, false, false, false, false, false, false, 0f, false, false, false, false);
                    Pawn mechToSpawn = PawnGenerator.GeneratePawn(request);
                    PawnUtility.TrySpawnHatchedOrBornPawn(mechToSpawn, corpse);
                    lord.AddPawn(mechToSpawn);
                    spawnComp.spawnedMechanoidsCombatPower += mechToSpawn.kindDef.combatPower;
                }
            }
            
        }
    }
}

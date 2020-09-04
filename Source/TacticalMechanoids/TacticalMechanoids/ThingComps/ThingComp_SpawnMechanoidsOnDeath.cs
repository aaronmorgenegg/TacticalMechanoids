using System.Collections.Generic;

using RimWorld;
using Verse;
using Verse.AI.Group;

namespace TacticalMechanoids
{
    public class CompSpawnMechanoidsOnDeath : ThingComp
    {
        public float spawnedMechanoidsCombatPower = 0f;
        public List<Pawn> pawnsToSpawn = new List<Pawn>();
        public CompProperties_SpawnMechanoidsOnDeath Props
        {
            get
            {
                return (CompProperties_SpawnMechanoidsOnDeath)this.props;
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            if (spawnedMechanoidsCombatPower == 0)
            {
                if (this.parent is Pawn pawn && pawn != null && pawn.GetLord() != null)
                {
                    float randVariance = Rand.Range(1 - Props.combatPowerVariance, 1 + Props.combatPowerVariance);

                    while (spawnedMechanoidsCombatPower < Props.totalCombatPower * randVariance)
                    {
                        int randomMechIndex = Rand.Range(0, Props.mechanoidsToChooseFrom.Count);
                        PawnGenerationRequest request = new PawnGenerationRequest(PawnKindDef.Named(Props.mechanoidsToChooseFrom[randomMechIndex]), Faction.OfMechanoids, PawnGenerationContext.NonPlayer, -1, false, false, false, false, false, false, 0f, false, false, false, false);
                        Pawn mechToSpawn = PawnGenerator.GeneratePawn(request);
                        pawn.GetLord().AddPawn(mechToSpawn);
                        pawnsToSpawn.Add(mechToSpawn);
                        spawnedMechanoidsCombatPower += mechToSpawn.kindDef.combatPower;
                    }
                }
            }
        }

    }
}

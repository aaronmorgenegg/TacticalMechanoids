using RimWorld;
using Verse;
using Verse.AI.Group;

namespace TacticalMechanoids
{
    public class DeathActionWorker_SpawnMechanoids : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse)
        {
            if (corpse != null && corpse.InnerPawn.GetComp<CompSpawnMechanoidsOnDeath>() is CompSpawnMechanoidsOnDeath spawnComp && spawnComp != null)
            {
                foreach (Pawn pawnToSpawn in spawnComp.pawnsToSpawn)
                {
                    PawnUtility.TrySpawnHatchedOrBornPawn(pawnToSpawn, corpse);
                }
            }
        }
    }
}

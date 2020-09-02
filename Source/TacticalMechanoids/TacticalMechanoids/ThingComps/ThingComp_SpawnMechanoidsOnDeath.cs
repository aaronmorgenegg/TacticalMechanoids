using System.Collections.Generic;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompSpawnMechanoidsOnDeath : ThingComp
    {
        public float spawnedMechanoidsCombatPower = 0f;
        public CompProperties_SpawnMechanoidsOnDeath Props
        {
            get
            {
                return (CompProperties_SpawnMechanoidsOnDeath)this.props;
            }
        }

        // Refer to DeathActionWorker_SpawnMechanoids for implementation

    }
}

using System.Collections.Generic;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_SpawnMechanoidsOnDeath : CompProperties
    {


        public int totalCombatPower = 300;
        public float combatPowerVariance = 0.25f;
        public List<string> mechanoidsToChooseFrom = new List<string>();


        public CompProperties_SpawnMechanoidsOnDeath()
        {
            this.compClass = typeof(CompSpawnMechanoidsOnDeath);
        }


    }
}
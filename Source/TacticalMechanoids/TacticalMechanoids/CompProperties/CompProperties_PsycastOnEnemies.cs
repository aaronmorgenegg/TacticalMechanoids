using System.Collections.Generic;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_PsycastOnEnemies : CompProperties
    {
        public List<string> psycastsToUse = new List<string>();
        public float psycastChance = 0.1f;
        public int brainDamage = 10;

        public CompProperties_PsycastOnEnemies()
        {
            this.compClass = typeof(CompPsycastOnEnemies);
        }
    }
}

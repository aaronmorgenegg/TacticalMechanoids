using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_GenerateMechanites : CompProperties
    {
        private int mechaniteSpawnRate = 500;
        private float nonMechanoidChance = 0.1f;
        private int mechaniteRange = 25;
        private HediffDef MechanoidMechanitesHediff = HediffDefOf.ConstructiveMechanites;
        private HediffDef NonMechanoidMechanitesHediff = HediffDefOf.FibrousMechanites;

        public CompProperties_GenerateMechanites()
        {
            this.compClass = typeof(CompGenerateMechanites);
        }
    }
}

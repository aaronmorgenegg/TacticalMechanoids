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
        public int mechaniteSpawnRate = 500;
        public float nonMechanoidChance = 0.1f;
        public int mechaniteRange = 25;
        public HediffDef MechanoidMechanitesHediff = HediffDef.Named("TM_ConstructiveMechanites");
        public HediffDef NonMechanoidMechanitesHediff = HediffDef.Named("FibrousMechanites");

        public CompProperties_GenerateMechanites()
        {
            this.compClass = typeof(CompGenerateMechanites);
        }
    }
}

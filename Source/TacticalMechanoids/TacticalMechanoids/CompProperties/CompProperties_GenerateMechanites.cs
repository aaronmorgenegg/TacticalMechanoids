using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_GenerateMechanites : CompProperties
    {
        public int mechaniteSpawnRate = 500;
        public float nonMechanoidChance = 0.1f;
        public int mechaniteRange = 25;
        public string MechanoidMechanitesHediff = "TM_ConstructiveMechanites";
        public string NonMechanoidMechanitesHediff = "FibrousMechanites";

        public CompProperties_GenerateMechanites()
        {
            this.compClass = typeof(CompGenerateMechanites);
        }
    }
}

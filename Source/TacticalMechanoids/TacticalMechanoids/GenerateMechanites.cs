using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_GenerateMechanites : ThingDef
    {
        public int rateInTicks = 500;
        public float nonMechanoidChance = 0.1f;
        public HediffDef MechanoidHediff = HediffDefOf.ArchotechEye;
        public HediffDef NonMechanoidHediff = HediffDefOf.FibrousMechanites;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_Floating : CompProperties
    {
        private bool isFloater = false;
        private bool canCrossWater = false;

        public CompProperties_Floating()
        {
            this.compClass = typeof(CompFloating);
        }
    }
}

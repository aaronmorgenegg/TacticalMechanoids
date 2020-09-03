using System.Collections.Generic;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_PsycastOnFriendlies : CompProperties
    {
        public List<string> psycastsToUse = new List<string>();
        public int psycastFrequency = 5000;
        public int psycastRange = 25;

        public CompProperties_PsycastOnFriendlies()
        {
            this.compClass = typeof(CompPsycastOnFriendlies);
        }
    }
}

﻿using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompFloating : ThingComp
    {
        public CompProperties_Floating Props
        {
            get
            {
                return (CompProperties_Floating)this.props;
            }
        }

    }
}

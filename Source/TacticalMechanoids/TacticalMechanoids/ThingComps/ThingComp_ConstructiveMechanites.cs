using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class ConstructiveMechanites : ThingComp
    {
        private int tickCounter = 0;

        public CompProperties_ConstructiveMechanites Props
        {
            get
            {
                return (CompProperties_ConstructiveMechanites)this.props;
            }
        }

        public override Tick()
        {
            base.Tick();
            tickCounter++;

            if (tickCounter >= constructiveMechaniteHealRate)
            {
                if (pawn.health != null)
                {
                    if (pawn.health.hediffSet.GetInjuriesTendable() != null && pawn.health.hediffSet.GetInjuriesTendable().Count<Hediff_Injury>() > 0)
                    {
                        foreach (Hediff_Injury injury in pawn.health.hediffSet.GetInjuriesTendable())
                        {
                            injury.Severity = injury.Severity - constructiveMechaniteHealStrength;
                            break;
                        }
                    }
                }
                tickCounter = 0;
            }
        }
    }
}

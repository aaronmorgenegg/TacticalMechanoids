using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class GenerateMechanites : ThingDef
    {
        private int tickCounter = 0;

        public CompProperties_GenerateMechanites Props
        {
            get
            {
                return (CompProperties_GenerateMechanites)this.props;
            }
        }

        public override Tick()
        {
            base.Tick();
            tickCounter++;

            // TODO: If statement to check if pawn has a working TM_MechaniteSource, compare current tickCounter to mechaniteSpawnRate adjusted by TM_MechaniteSource effectiveness.
            if (pawn.TM_MechaniteSource && tickCounter >= mechaniteSpawnRate * TM_MechaniteSource)
            {
                if (pawn.health != null)
                {
                    // TODO: for pawn in getNextClosestPawn:
                        // TODO: If pawn is friendly mechanoid, 
                            // TODO: If pawn does not have MechanoidMechanitesHediff:
                                // TODO: Apply MechanoidMechanitesHediff hediff and break.
                        // TODO: elif pawn is enemy humanoid
                            // TODO: if random.randFloat(0, 1) < nonMechanoidChance and pawn does not have NonMechanoidMechanitesHediff:
                                // TODO: Apply NonMechanoidMechanitesHediff and break.
                }
                tickCounter = 0;
            }
        }
    }
}

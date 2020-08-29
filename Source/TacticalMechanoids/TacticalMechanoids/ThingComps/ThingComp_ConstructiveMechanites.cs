using System.Linq;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompConstructiveMechanites : ThingComp
    {
        private int tickCounter = 0;

        public CompProperties_ConstructiveMechanites Props
        {
            get
            {
                return (CompProperties_ConstructiveMechanites)this.props;
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            tickCounter++;

            if (tickCounter >= this.Props.constructiveMechaniteHealRate)
            {
                Pawn pawn = this.parent as Pawn;
                if (pawn.health != null)
                {
                    if (pawn.health.hediffSet.GetInjuriesTendable() != null && pawn.health.hediffSet.GetInjuriesTendable().Count<Hediff_Injury>() > 0)
                    {
                        foreach (Hediff_Injury injury in pawn.health.hediffSet.GetInjuriesTendable())
                        {
                            injury.Severity = injury.Severity - this.Props.constructiveMechaniteHealStrength;
                            break;
                        }
                    }
                }
                tickCounter = 0;
            }
        }
    }
}

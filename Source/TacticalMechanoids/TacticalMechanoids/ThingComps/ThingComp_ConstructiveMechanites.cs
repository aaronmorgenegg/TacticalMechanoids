using System.Linq;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class CompConstructiveMechanites : HediffComp
    {
        private int tickCounter = 0;

        public CompProperties_ConstructiveMechanites Props
        {
            get
            {
                return (CompProperties_ConstructiveMechanites)this.props;
            }
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            tickCounter++;

            if (tickCounter >= this.Props.constructiveMechaniteHealRate)
            {
                if (this.parent.pawn.health != null)
                {
                    if (this.parent.pawn.health.hediffSet.GetInjuriesTendable() != null && this.parent.pawn.health.hediffSet.GetInjuriesTendable().Count<Hediff_Injury>() > 0)
                    {
                        foreach (Hediff_Injury injury in this.parent.pawn.health.hediffSet.GetInjuriesTendable())
                        {
                            injury.Severity -= this.Props.constructiveMechaniteHealStrength;
                            break;
                        }
                    }
                }
                tickCounter = 0;
            }
        }
    }
}

using System.Linq;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class HediffCompConstructiveMechanites : HediffComp
    {
        private int healCounter = 0;
        private int durationCounter = 0;

        public HediffCompProperties_ConstructiveMechanites Props
        {
            get
            {
                return (HediffCompProperties_ConstructiveMechanites)this.props;
            }
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            healCounter++;
            //durationCounter++;

            if (healCounter >= this.Props.constructiveMechaniteHealRate)
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
                healCounter = 0; // TODO: Constructive MEchanites has comps, needs to inherit from HediffWithcomps or get rid of comps?
            }

            /*if (durationCounter >= this.Props.constructiveMechaniteDuration)
            {
                TODO: May not need this.
                TODO: End hediff effect.
            }*/
        }
    }
}

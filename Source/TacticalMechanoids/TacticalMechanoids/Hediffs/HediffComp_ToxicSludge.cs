using System.Linq;

using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class HediffCompConstructiveMechanites : HediffWithComps
    {
        private int healCounter = 0;
        private float constructiveMechaniteHealStrength = 0.1f;
        private float constructiveMechaniteHealRate = 60;

        public override void Tick()
        {
            base.Tick();
            healCounter++;

            if (healCounter >= constructiveMechaniteHealRate)
            {
                if (pawn.health != null)
                {
                    if (pawn.health.hediffSet.GetInjuriesTendable() != null && pawn.health.hediffSet.GetInjuriesTendable().Count<Hediff_Injury>() > 0)
                    {
                        foreach (Hediff_Injury injury in pawn.health.hediffSet.GetInjuriesTendable())
                        {
                            injury.Severity -= constructiveMechaniteHealStrength;
                            break;
                        }
                    }
                }
            }
        }
    }
}

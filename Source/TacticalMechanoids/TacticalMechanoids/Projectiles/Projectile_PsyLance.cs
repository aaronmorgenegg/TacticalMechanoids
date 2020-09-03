using RimWorld;
using UnityEngine;
using Verse;

namespace TacticalMechanoids
{
    public class Projectile_PsyLance : Projectile
    {

        public CompProperties_PsycastOnEnemies Props
        {
            get
            {
                return this.GetComp<Comp_PsycastOnEnemies>.Props;
            }
        }

        protected override void Impact(Thing hitThing)
        {
            base.Impact(hitThing);

            if (hitThing is Pawn hitPawn && hitPawn != null)
            {
                // TODO: deal additional damage to brain directly
                // TODO: call compPsycastOnEnemies.CastPsycast
            }
        }

    }
}
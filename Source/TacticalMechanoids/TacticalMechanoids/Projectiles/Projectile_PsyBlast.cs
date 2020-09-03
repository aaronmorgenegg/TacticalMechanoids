using RimWorld;
using UnityEngine;
using Verse;

namespace TacticalMechanoids
{
    public class Projectile_PsyBlast : Bullet
    {

        public CompProperties_PsycastOnEnemies Props
        {
            get
            {
                return this.GetComp<CompPsycastOnEnemies>().Props;
            }
        }

        protected override void Impact(Thing hitThing)
        {
            base.Impact(hitThing);

            if (hitThing is Pawn hitPawn && hitPawn != null && Props != null)
            {
                if (launcher is Pawn sourcePawn)
                {
                    this.GetComp<CompPsycastOnEnemies>().CastPsycast(hitPawn, sourcePawn);
                }
            }
        }

    }
}
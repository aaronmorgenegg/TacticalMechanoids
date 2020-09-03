using RimWorld;
using UnityEngine;
using Verse;

namespace TacticalMechanoids
{
    public class Projectile_PsyBlast : Projectile
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
                BodyPartRecord brain = hitPawn.health.hediffSet.GetBrain();
                hitPawn.TakeDamage(new DamageInfo(DefDatabase<DamageDef>.GetNamed("Blunt"), Props.brainDamage * Rand.Range(-.25f, .25f), 1.0f, -1f, null, brain, null, DamageInfo.SourceCategory.ThingOrUnknown, null));
                if (launcher is Pawn sourcePawn)
                {
                    this.GetComp<CompPsycastOnEnemies>().CastPsycast(hitPawn, sourcePawn);
                }
            }
        }

    }
}
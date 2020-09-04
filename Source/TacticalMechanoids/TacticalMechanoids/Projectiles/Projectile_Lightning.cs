using RimWorld;
using UnityEngine;
using Verse;
using JecsTools;

namespace TacticalMechanoids
{
    public class Projectile_Lightning : Projectile_Laser
    {


        public override void PostImpactEffects(Pawn launcher, Pawn hitTarget)
        {
            if (hitTarget.health != null)
            {
                if (!hitTarget.RaceProps.IsMechanoid && Rand.Value < 0.50)
                {
                    hitTarget.health.AddHediff(HediffDef.Named("HeartAttack"), null, null);
                    string message = "TM_PawnSufferingHeartAttack".Translate(hitTarget.Label);
                    Messages.Message(message, MessageTypeDefOf.NegativeEvent);
                }
                hitTarget.stances.stunner.StunFor_NewTmp(300, launcher);
            }
        }

        protected override void Explode(Thing hitThing, bool destroy = false)
        {
            base.Explode(hitThing, destroy);

            GenExplosion.DoExplosion(hitThing?.PositionHeld ?? this.destination.ToIntVec3(), this.Map, this.def.projectile.explosionRadius+1,
                DefDatabase<DamageDef>.GetNamed("EMP"), launcher, 50, 0f, null, equipmentDef, def);

        }

    }
}
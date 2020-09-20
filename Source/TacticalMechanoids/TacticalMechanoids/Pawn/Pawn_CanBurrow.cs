using System.Collections.Generic;
using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class TM_PawnCanBurrow : Pawn
    {
        public override void PostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            base.PostApplyDamage(dinfo, totalDamageDealt);

            if (!Dead)
            {
                // TODO: If attacker was ranged and If not in melee range with an enemy and burrowChance * totalDamageDealt <= rand.value and burrowComp != null
                IntVec3 attackerPosition = dinfo.Instigator.Position;
                CompBurrowing burrowComp = GetComp<CompBurrowing>();
                burrowComp.BurrowTowardAttacker(attackerPosition);
            }
        }

    }
}

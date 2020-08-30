using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;
using Verse.AI.Group;

namespace TacticalMechanoids
{
    public class Projectile_SludgeBullet : Projectile_Explosive
    {

        protected override void Impact(Thing hitThing)
        {
            base.Impact(hitThing);

            if (hitThing is Pawn targetPawn && targetPawn != null && targetPawn.health != null && targetPawn.RaceProps.IsFlesh) 
            {

                Hediff targetPawnToxicSludgeHediff = targetPawn.health.hediffSet.GetFirstHediffOfDef(HediffDef.Named("TM_ToxicSludge"));
                float randomSeverity = Rand.Range(0.15f, 0.30f);
                if (targetPawnToxicSludgeHediff != null)
                {
                    targetPawnToxicSludgeHediff.Severity += randomSeverity;
                }
                else
                {
                    Hediff hediff = HediffMaker.MakeHediff(HediffDef.Named("TM_ToxicSludge"), targetPawn, null);
                    hediff.Severity = randomSeverity;
                    targetPawn.health.AddHediff(hediff, null, null);
                }
            }
        }

    }
}
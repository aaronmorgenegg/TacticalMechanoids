using RimWorld;
using UnityEngine;
using Verse;

namespace TacticalMechanoids
{
    public class Projectile_SludgeBullet : Projectile_Explosive
    {

        protected override void Explode()
        {
            Map map = base.Map;
            base.Explode();

            if (base.Position != null && map != null)
            {
                foreach (Thing hitThing in GenRadial.RadialDistinctThingsAround(base.Position, map, base.def.projectile.explosionRadius, true))
                {
                    if (hitThing is Pawn targetPawn && targetPawn != null && targetPawn.health != null && targetPawn.RaceProps.IsFlesh)
                    {
                        Hediff targetPawnToxicSludgeHediff = targetPawn.health.hediffSet.GetFirstHediffOfDef(HediffDef.Named("TM_ToxicSludge"));
                        float toxicSludgeSeverity = Rand.Range(0.15f, 0.30f);
                        if (targetPawnToxicSludgeHediff != null)
                        {
                            targetPawnToxicSludgeHediff.Severity += toxicSludgeSeverity;
                        }
                        else
                        {
                            Hediff hediff = HediffMaker.MakeHediff(HediffDef.Named("TM_ToxicSludge"), targetPawn, null);
                            hediff.Severity = toxicSludgeSeverity;
                            targetPawn.health.AddHediff(hediff, null, null);
                        }
                        Hediff targetPawnToxicBuildupHediff = targetPawn.health.hediffSet.GetFirstHediffOfDef(HediffDef.Named("ToxicBuildup"));
                        float toxicBuildupSeverity = Rand.Range(0.03f, 0.15f);
                        if (targetPawnToxicBuildupHediff != null)
                        {
                            targetPawnToxicBuildupHediff.Severity += toxicBuildupSeverity;
                        }
                        else
                        {
                            Hediff hediff = HediffMaker.MakeHediff(HediffDef.Named("ToxicBuildup"), targetPawn, null);
                            hediff.Severity = toxicBuildupSeverity;
                            targetPawn.health.AddHediff(hediff, null, null);
                        }
                    }
                }
            }
        }

    }
}
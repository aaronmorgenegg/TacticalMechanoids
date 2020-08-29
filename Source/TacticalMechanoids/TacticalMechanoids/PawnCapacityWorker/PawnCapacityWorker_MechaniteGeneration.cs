using System.Collections.Generic;
using RimWorld;
using Verse;

namespace TacticalMechanoids
{
    public class PawnCapacityWorker_MechaniteGeneration : PawnCapacityWorker
    {
        public override float CalculateCapacityLevel(HediffSet diffSet,
                                                      List<PawnCapacityUtility.CapacityImpactor> impactors = null)
        {
            return PawnCapacityUtility.CalculateTagEfficiency(
                diffSet,
                BodyPartTagDefOf.TM_MechaniteSource,
                3.40282347E+38f,
                default(FloatRange),
                impactors);
        }

        public override bool CanHaveCapacity(BodyDef body)
        {
            return body.HasPartWithTag(BodyPartTagDefOf.TM_MechaniteSource);
        }
    }
}

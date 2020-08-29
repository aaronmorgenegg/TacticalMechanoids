using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Verse.AI;
using RimWorld.Planet;


// So, let's comment this code, since it uses Harmony and has moderate complexity

namespace TacticalMechanoids
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.tacticalmechanoids
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }


    }

    /*This Harmony Postfix changes terrain calculation for floating creatures
   */
    [HarmonyPatch(typeof(Verse.AI.Pawn_PathFollower))]
    [HarmonyPatch("CostToMoveIntoCell")]
    [HarmonyPatch(new Type[] { typeof(Pawn), typeof(IntVec3) })]
    public static class Pawn_PathFollower_CostToMoveIntoCell_Patch
    {
        [HarmonyPostfix]
        public static void MakeFloatingCreaturesGreatAgaian(Pawn pawn, IntVec3 c, ref int __result)

        {
            if ((pawn.Map != null) && (pawn.TryGetComp<CompFloating>() != null))
            {
                if (pawn.TryGetComp<CompFloating>().Props.isFloater)
                {
                    int num;
                    if (c.x == pawn.Position.x || c.z == pawn.Position.z)
                    {
                        num = pawn.TicksPerMoveCardinal;
                    }
                    else
                    {
                        num = pawn.TicksPerMoveDiagonal;
                    }
                    TerrainDef terrainDef = pawn.Map.terrainGrid.TerrainAt(c);
                    if (terrainDef == null)
                    {
                        num = 10000;
                    }
                    else if ((terrainDef.passability == Traversability.Impassable) && !terrainDef.IsWater)
                    {
                        num = 10000;
                    }
                    else if (terrainDef.IsWater && !pawn.TryGetComp<CompFloating>().Props.canCrossWater)
                    {
                        num = 10000;
                    }
                    List<Thing> list = pawn.Map.thingGrid.ThingsListAt(c);
                    for (int i = 0; i < list.Count; i++)
                    {
                        Thing thing = list[i];
                        if (thing.def.passability == Traversability.Impassable)
                        {
                            num = 10000;
                        }

                        if (thing is Building_Door)
                        {
                            num += 45;
                        }
                    }

                    __result = num;

                }

            }




        }
    }

    public static bool DetectTacticalMechanoidsAndOptions(PawnKindDef pawn)
    {
        if (pawn != null)
        {
            if (pawn.defName.Contains("TM_"))
            {

                if (pawn.defName.Contains("TM_MechaniteDrone") && TacticalMechanoids_Settings.TM_MechaniteDroneFlag)
                {
                    return true;
                }

                return false;

            }
            else return false;
        }
        else return false;

    }
}

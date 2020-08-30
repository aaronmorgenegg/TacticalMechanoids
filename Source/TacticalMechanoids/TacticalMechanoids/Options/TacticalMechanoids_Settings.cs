using RimWorld;
using UnityEngine;
using Verse;


namespace TacticalMechanoids
{
    public class TacticalMechanoids_Settings : ModSettings

    {
        public static bool TM_MechaniteDroneFlag = false;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref TM_MechaniteDroneFlag, "TM_MechaniteDroneFlag", false, true);
        }
        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();

            ls.Begin(inRect);
            ls.ColumnWidth = inRect.width / 3.2f;

            ls.CheckboxLabeled("TM_disableMechaniteDrone".Translate(), ref TM_MechaniteDroneFlag, null);



            ls.End();

        }

        public static bool MechanoidIsEnabled(string def_name)
        {
            if (def_name == "TM_MechaniteDrone")
            {
                return !TM_MechaniteDroneFlag;
            }

            Log.Warning("MechanoidIsEnabled({}) found no matching def_name. Returning false, but this means you misnamed something somewhere.");
            return false;
        }




    }

}
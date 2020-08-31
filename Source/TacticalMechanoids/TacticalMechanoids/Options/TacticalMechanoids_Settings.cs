using RimWorld;
using UnityEngine;
using Verse;


namespace TacticalMechanoids
{
    public class TacticalMechanoids_Settings : ModSettings

    {
        public static bool TM_BelcherFlag = true;
        public static bool TM_CarrierFlag = true;
        public static bool TM_MechaniteDroneFlag = true;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref TM_BelcherFlag, "TM_BelcherFlag", true, true);
            Scribe_Values.Look(ref TM_CarrierFlag, "TM_CarrierFlag", true, true);
            Scribe_Values.Look(ref TM_MechaniteDroneFlag, "TM_MechaniteDroneFlag", true, true);
        }
        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();

            ls.Begin(inRect);
            ls.ColumnWidth = inRect.width / 3.2f;

            ls.CheckboxLabeled("TM_enableBelcher".Translate(), ref TM_BelcherFlag, null);
            ls.CheckboxLabeled("TM_enableCarrier".Translate(), ref TM_CarrierFlag, null);
            ls.CheckboxLabeled("TM_enableMechaniteDrone".Translate(), ref TM_MechaniteDroneFlag, null);



            ls.End();

        }

        public static bool MechanoidIsEnabled(string def_name)
        {
            // TODO: if statement chain is gross, try turning this into a dictionary or something
            if (def_name == "TM_MechaniteDrone")
            {
                return TM_MechaniteDroneFlag;
            }
            if (def_name == "TM_Belcher")
            {
                return TM_BelcherFlag;
            }
            if (def_name == "TM_Carrier")
            {
                return TM_CarrierFlag;
            }

            Log.Warning("MechanoidIsEnabled({}) found no matching def_name. Returning false, but this means you misnamed something somewhere.");
            return false;
        }




    }

}
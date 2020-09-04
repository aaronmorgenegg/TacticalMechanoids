using RimWorld;
using UnityEngine;
using Verse;


namespace TacticalMechanoids
{
    public class TacticalMechanoids_Settings : ModSettings

    {
        public static bool TM_BelcherFlag = true;
        public static bool TM_CarrierFlag = true;
        public static bool TM_DynamoFlag = true;
        public static bool TM_MechaniteDroneFlag = true;
        public static bool TM_OracleFlag = true;
        public static bool TM_ShredderFlag = true;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref TM_BelcherFlag, "TM_BelcherFlag", true, true);
            Scribe_Values.Look(ref TM_CarrierFlag, "TM_CarrierFlag", true, true);
            Scribe_Values.Look(ref TM_DynamoFlag, "TM_DynamoFlag", true, true);
            Scribe_Values.Look(ref TM_MechaniteDroneFlag, "TM_MechaniteDroneFlag", true, true);
            Scribe_Values.Look(ref TM_OracleFlag, "TM_OracleFlag", true, true);
            Scribe_Values.Look(ref TM_ShredderFlag, "TM_ShredderFlag", true, true);
        }
        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();

            ls.Begin(inRect);
            ls.ColumnWidth = inRect.width / 3.2f;

            ls.CheckboxLabeled("TM_enableBelcher".Translate(), ref TM_BelcherFlag, null);
            ls.CheckboxLabeled("TM_enableCarrier".Translate(), ref TM_CarrierFlag, null);
            ls.CheckboxLabeled("TM_enbaleDynamo".Translate(), ref TM_DynamoFlag, null);
            ls.CheckboxLabeled("TM_enableMechaniteDrone".Translate(), ref TM_MechaniteDroneFlag, null);
            ls.CheckboxLabeled("TM_enableOracle".Translate(), ref TM_OracleFlag, null);
            ls.CheckboxLabeled("TM_enableShredder".Translate(), ref TM_ShredderFlag, null);



            ls.End();

        }

        public static bool MechanoidIsEnabled(string def_name)
        {
            return 
            def_name == "TM_Belcher" ? TM_BelcherFlag :
            def_name == "TM_Carrier" ? TM_CarrierFlag :
            def_name == "TM_Dynamo" ? TM_DynamoFlag :
            def_name == "TM_MechaniteDrone" ? TM_MechaniteDroneFlag :
            def_name == "TM_Oracle" ? TM_OracleFlag :
            def_name == "TM_Shredder" ? TM_ShredderFlag :
            false;
        }


    }

}
using RimWorld;
using UnityEngine;
using Verse;


namespace TacticalMechanoids.Settings
{

    public class TacticalMechanoids_Mod : Mod
    {


        public TacticalMechanoids_Mod(ModContentPack content) : base(content)
        {
            GetSettings<TacticalMechanoids_Settings>();
        }
        public override string SettingsCategory() => "Tactical Mechanoids";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            TacticalMechanoids_Settings.DoWindowContents(inRect);


        }
    }
}
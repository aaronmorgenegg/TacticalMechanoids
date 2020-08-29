using Verse;

namespace TacticalMechanoidsAndEvents
{
    public class CompProperties_ChangeDef : CompProperties
    {


        public string defToChangeTo = "";
        public string defToChangeFrom = "";


        public CompProperties_ChangeDef()
        {
            this.compClass = typeof(CompChangeDef);
        }


    }
}
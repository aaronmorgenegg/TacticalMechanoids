using Verse;

namespace TacticalMechanoids
{
    public class CompProperties_ChangeDef : CompProperties
    {


        public string defToChangeTo = "";
        public string defToChangeFrom = "";
        public int numToSpawn = 1;


        public CompProperties_ChangeDef()
        {
            this.compClass = typeof(CompChangeDef);
        }


    }
}
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;
using Verse.AI.Group;

namespace TacticalMechanoids
{
    public class CompChangeDef : ThingComp
    {




        public CompProperties_ChangeDef Props
        {
            get
            {
                return (CompProperties_ChangeDef)this.props;
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            if (!TacticalMechanoids_Settings.MechanoidIsEnabled(Props.defToChangeFrom))
            {
                if (parent.Map != null)
                {
                    for (int i = 0; i < Props.numToSpawn; i++)
                    {
                        PawnGenerationRequest request = new PawnGenerationRequest(PawnKindDef.Named(Props.defToChangeTo), Find.FactionManager.FirstFactionOfDef(FactionDefOf.Mechanoid), PawnGenerationContext.NonPlayer, -1, false, false, false, false, true, false, 1f, false, true, true, false, false);
                        Pawn pawn = PawnGenerator.GeneratePawn(request);
                        GenSpawn.Spawn(pawn, this.parent.Position, parent.Map, WipeMode.Vanish);

                        Lord lord = null;
                        if (this.parent is Pawn parentPawn)
                        {
                            lord = parentPawn.GetLord();
                        }
                        if (lord == null)
                        {
                            LordJob_DefendPoint lordJob = new LordJob_DefendPoint(pawn.Position, null, false, true);
                            lord = LordMaker.MakeNewLord(Faction.OfMechanoids, lordJob, Find.CurrentMap, null);
                        }
                        lord.AddPawn(pawn);
                    }


                    this.parent.Destroy();
                }

            }


        }


    }
}
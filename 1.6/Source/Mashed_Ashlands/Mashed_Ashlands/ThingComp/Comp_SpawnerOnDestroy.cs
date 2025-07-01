using Verse;

namespace Mashed_Ashlands
{
    public class Comp_SpawnerOnDestroy : ThingComp
    {
        private CompProperties_SpawnerOnDestroy Props => (CompProperties_SpawnerOnDestroy)props;

        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            for (int i = 0; i <= Props.numberToSpawn; i++)
            {
                TryDoSpawn(previousMap);
            }
            base.PostDestroy(mode, previousMap);
        }

        public void TryDoSpawn(Map map)
        {
            Pawn pawn = PawnGenerator.GeneratePawn(Props.pawnKindDef, null);
            GenSpawn.Spawn(pawn, parent.Position, map, Rot4.Random, WipeMode.Vanish, false);
            pawn.mindState.mentalStateHandler.TryStartMentalState(RimWorld.MentalStateDefOf.ManhunterPermanent);
        }
    }
}

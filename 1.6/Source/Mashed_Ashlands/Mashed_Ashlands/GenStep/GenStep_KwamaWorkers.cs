using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_KwamaWorkers : GenStep_ScatterThings
    {
        protected override void ScatterAt(IntVec3 loc, Map map, GenStepParams parms, int stackCount = 1)
        {
            Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDefOf.Mashed_Ashlands_KwamaWorker, null);
            pawn.ageTracker.AgeBiologicalTicks = pawn.ageTracker.AdultMinAgeTicks;
            GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.FullRefund, false);
        }

        public override void Generate(Map map, GenStepParams parms)
        {
            base.Generate(map, parms);
        }
    }
}

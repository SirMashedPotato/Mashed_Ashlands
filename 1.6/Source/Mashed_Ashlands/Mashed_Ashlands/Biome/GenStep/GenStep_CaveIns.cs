using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_CaveIns : GenStep
    {
        public override int SeedPart => 75889013;

        public IntRange caveInCountRange;
        public IntRange caveInSizeRange;
        private const int maxTries = 600;

        public override void Generate(Map map, GenStepParams parms)
        {
            int caveInTarget = caveInCountRange.RandomInRange;
            int caveInCount = 0;
            for (int i = 0; i < maxTries; i++)
            {
                int caveInSize = caveInSizeRange.RandomInRange;
                CellFinder.TryFindRandomCell(map, c => CellValidator(map, c), out IntVec3 result);
                if (result.IsValid)
                {
                    List<IntVec3> caveIn = GridShapeMaker.IrregularLump(result, map, caveInSize, c => CellValidator(map, c));
                    foreach (IntVec3 cell in caveIn)
                    {
                        RoofCollapserImmediate.DropRoofInCells(cell, map);
                    }
                    if (caveInCount++ >= caveInTarget)
                    {
                        return;
                    }
                }
            }
            Log.Warning("GenStep_CaveIns hit max tries of " + maxTries);
        }

        private bool CellValidator(Map map, IntVec3 c)
        {
            if (c.DistanceToEdge(map) < 10)
            {
                return false;
            }

            if (!c.Standable(map))
            {
                return false;
            }

            c.TryGetFirstThing(map, out Thing thing);
            if (thing != null && !(thing is Filth))
            {
                return false;
            }

            return true;
        }
    }
}

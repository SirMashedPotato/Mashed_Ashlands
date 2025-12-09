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
        public int minSpacing = 0;
        private const int maxTries = 600;

        [Unsaved(false)]
        protected List<IntVec3> usedSpots = new List<IntVec3>();

        public override void Generate(Map map, GenStepParams parms)
        {
            usedSpots.Clear();
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
                        usedSpots.Add(cell);
                    }
                    if (caveInCount++ >= caveInTarget)
                    {
                        return;
                    }
                }
            }
            Log.Warning("GenStep_CaveIns hit max tries of " + maxTries);
        }

        protected bool CellValidator(Map map, IntVec3 c)
        {
            if (c.DistanceToEdge(map) < 10)
            {
                return false;
            }

            if (minSpacing > 0 && NearUsedSpot(c))
            {
                return false;
            }

           return Utility.CaveInCellValidator(map, c);
        }

        protected bool NearUsedSpot(IntVec3 c)
        {
            for (int i = 0; i < usedSpots.Count; i++)
            {
                if ((usedSpots[i] - c).LengthHorizontalSquared <= minSpacing * minSpacing)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

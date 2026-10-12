using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_ScatterWithTerrain : GenStep_ScatterThings
    {
        protected override void ScatterAt(IntVec3 loc, Map map, GenStepParams parms, int stackCount = 1)
        {
            base.ScatterAt(loc, map, parms, stackCount);
            if (terrainDef != null)
            {
                List<IntVec3> terrainCells = GridShapeMaker.IrregularLump(loc, map, terrainGridSize, c => CellValidator(map, c));
                foreach (IntVec3 cell in terrainCells)
                {
                    map.terrainGrid.SetTerrain(cell, terrainDef);
                }
            }
        }

        private bool CellValidator(Map map, IntVec3 c)
        {
            if (!c.InBounds(map))
            {
                return false;
            }

            return true;
        }

        public TerrainDef terrainDef;
        public int terrainGridSize = 6;
    }
}

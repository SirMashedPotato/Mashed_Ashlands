using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_ScatterFetcherflyHives : GenStep_ScatterBiomeSpecific
    {
        public override void Generate(Map map, GenStepParams parms)
        {
            if (Mashed_Ashlands_ModSettings.EnableFetcherflyHives)
            {
                base.Generate(map, parms);
            }
        }

        protected override void ScatterAt(IntVec3 loc, Map map, GenStepParams parms, int stackCount = 1)
        {
            base.ScatterAt(loc, map, parms, stackCount);
            if (spawnTerrain != null)
            {
                IEnumerable<IntVec3> cells = GenRadial.RadialCellsAround(loc, spawnTerrainRadius, true);
                foreach (IntVec3 cell in cells)
                {
                    if (cell.GetTerrain(map).affordances.Contains(TerrainAffordanceDefOf.Mashed_Ashlands_GrowAsh))
                    {
                        if (cell.InBounds(map))
                        {
                            map.terrainGrid.SetTerrain(cell, spawnTerrain);
                        }
                    }
                }
            }
        }

        public TerrainDef spawnTerrain;
        public int spawnTerrainRadius = 4;
    }
}

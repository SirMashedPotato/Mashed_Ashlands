using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_TaintedSea : TileMutatorWorker
    {
        public TileMutatorWorker_TaintedSea(TileMutatorDef def) : base(def)
        {
        }

        public override void GeneratePostTerrain(Map map)
        {
            if (ModsConfig.OdysseyActive)
            {
                foreach(IntVec3 cell in map.AllCells)
                {
                    TerrainDef terrain = cell.GetTerrain(map);
                    if (terrain.IsWater)
                    {
                        if (terrain == map.BiomeAt(cell).oceanShallowTerrain || terrain == RimWorld.TerrainDefOf.WaterOceanShallow)
                        {
                            map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_WaterShallowTaintedOcean);
                        }
                        else
                        {
                            if (terrain == map.BiomeAt(cell).oceanDeepTerrain || terrain == RimWorld.TerrainDefOf.WaterOceanDeep)
                            {
                                map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_WaterDeepTaintedOcean);
                            }
                        }
                    }
                }
            }
            base.GeneratePostTerrain(map);
        }
    }
}

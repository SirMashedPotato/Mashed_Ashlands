using RimWorld;
using Verse;
using Verse.Noise;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_UndergroundMine : TileMutatorWorker_UndergroundCave
    {
        protected override float BranchChance => 0.1f;

        protected override float MinTunnelWidth => 2.6f;

        protected override float WidthOffsetPerCell => 0.001f;

        public TileMutatorWorker_UndergroundMine(TileMutatorDef def) : base(def)
        {
        }

        /// <summary>
        /// Largely copy pasted from TileMutatorWorker_Cave, just so I can change the terrain thresholds
        /// </summary>
        public override void GeneratePostTerrain(Map map)
        {
            BiomeCaveProperties props = BiomeCaveProperties.Get(map.Biome);
            if (props == null || props.useDefaultCaveGen)
            {
                base.GeneratePostTerrain(map);
                return;
            }

            Perlin perlin = new Perlin(0.07999999821186066, 2.0, 0.5, 6, Rand.Int, QualityMode.Medium);
            Perlin perlin2 = new Perlin(0.1599999964237213, 2.0, 0.5, 6, Rand.Int, QualityMode.Medium);
            MapGenFloatGrid caves = MapGenerator.Caves;
            MapGenFloatGrid elevation = MapGenerator.Elevation;
            foreach (IntVec3 allCell in map.AllCells)
            {
                if (!(caves[allCell] <= 0f) && !(elevation[allCell] <= 0f) && !allCell.GetTerrain(map).IsRiver)
                {
                    float num = (float)perlin.GetValue(allCell.x, 0.0, allCell.z);
                    float num2 = (float)perlin2.GetValue(allCell.x, 0.0, allCell.z);
                    if (num > props.waterThreshold)
                    {
                        map.terrainGrid.SetTerrain(allCell, MapGenUtility.ShallowFreshWaterTerrainAt(allCell, map));
                    }
                    else if (num2 > props.gravelThreshold)
                    {
                        map.terrainGrid.SetTerrain(allCell, map.BiomeAt(allCell).gravelTerrain);
                    }
                }
            }
        }
    }
}

using RimWorld;
using System.Linq;
using Verse;
using Verse.Noise;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_AncientLavaFlow : TileMutatorWorker
    {
        private const float RidgedFreq = 0.03f;
        private const float RidgedLac = 2f;
        private const int RidgedOctaves = 3;
        private const float RockThreshold = 0.85f;
        private ModuleBase rockNoise;

        public TileMutatorWorker_AncientLavaFlow(TileMutatorDef def) : base(def)
        {
        }

        public override void Init(Map map)
        {
            if (ModsConfig.OdysseyActive)
            {
                rockNoise = new RidgedMultifractal(RidgedFreq, RidgedLac, RidgedOctaves, Rand.Int, QualityMode.High);
                rockNoise = new Clamp(0.0, 1.0, rockNoise);
                rockNoise = new Invert(rockNoise);
                rockNoise = new ScaleBias(1.0, 1.0, rockNoise);
                NoiseDebugUI.StoreNoiseRender(rockNoise, "ancient lava flow");
            }
        }

        public override void GeneratePostElevationFertility(Map map)
        {
            MapGenFloatGrid elevation = MapGenerator.Elevation;
            foreach (IntVec3 allCell in map.AllCells)
            {
                if (!(rockNoise.GetValue(allCell) > 0.85f))
                {
                    elevation[allCell] = 0f;
                }
            }
        }

        public override void GeneratePostTerrain(Map map)
        {
            TerrainPatchMaker terrainPatchMaker = map.Biome.terrainPatchMakers.FirstOrDefault((TerrainPatchMaker x) => x.isPond);
            foreach (IntVec3 allCell in map.AllCells)
            {
                TerrainDef terrain = allCell.GetTerrain(map);
                if (terrain.IsWater)
                {
                    continue;
                }
                TerrainDef terrainDef = terrainPatchMaker?.TerrainAt(allCell, map, allCell.GetFertility(map));
                if (terrainDef != null)
                {
                    map.terrainGrid.SetTerrain(allCell, terrainDef);
                }
                else if (!(rockNoise.GetValue(allCell) > RockThreshold) && terrain != RimWorld.TerrainDefOf.LavaDeep)
                {
                    map.terrainGrid.SetTerrain(allCell, RimWorld.TerrainDefOf.VolcanicRock);
                }
            }
            terrainPatchMaker?.Cleanup();
        }
    }

}


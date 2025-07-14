using RimWorld;
using Verse;
using Verse.Noise;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_SulphuricSprings : TileMutatorWorker
    {
        private const float ShapeNoiseFrequency = 0.015f;
        private const float ShapeNoiseStrength = 25f;
        private const float NoiseFrequency = 0.05f;
        private const float NoiseLacunarity = 1.5f;
        private const float NoisePersistence = 0.5f;
        private const int NoiseOctaves = 4;
        private const float PoolsRadius = 0.35f;
        private const float SpringThreshold = 0.85f;
        private const float SandThreshold = 0.65f;
        private const float FalloffExp = 0.05f;

        private ModuleBase springNoise;

        public TileMutatorWorker_SulphuricSprings(TileMutatorDef def) : base(def)
        {
        }

        public override void Init(Map map)
        {
            if (ModsConfig.OdysseyActive)
            {
                springNoise = new Perlin(NoiseFrequency, NoiseLacunarity, NoisePersistence, NoiseOctaves, Rand.Int, QualityMode.Medium);
                springNoise = new ScaleBias(NoisePersistence, NoisePersistence, springNoise);
                ModuleBase baseShape = MapNoiseUtility.CreateFalloffRadius((float)map.Size.x * PoolsRadius, map.Center.ToVector2(), FalloffExp);
                baseShape = MapNoiseUtility.AddDisplacementNoise(baseShape, ShapeNoiseFrequency, ShapeNoiseStrength, 1);
                NoiseDebugUI.StoreNoiseRender(baseShape, "hot springs area");
                springNoise = new Multiply(springNoise, baseShape);
                NoiseDebugUI.StoreNoiseRender(springNoise, "hot springs");
            }
        }

        public override void GeneratePostElevationFertility(Map map)
        {
            MapGenFloatGrid elevation = MapGenerator.Elevation;
            foreach (IntVec3 allCell in map.AllCells)
            {
                if (springNoise.GetValue(allCell) > 0.65f)
                {
                    elevation[allCell] = 0f;
                }
            }
        }

        public override void GeneratePostTerrain(Map map)
        {
            foreach (IntVec3 allCell in map.AllCells)
            {
                float value = springNoise.GetValue(allCell);
                if (value > SpringThreshold)
                {
                    map.terrainGrid.SetTerrain(allCell, TerrainDefOf.Mashed_Ashlands_ShallowSulphuricWater);
                }
                else if (value > SandThreshold)
                {
                    map.terrainGrid.SetTerrain(allCell, TerrainDefOf.Mashed_Ashlands_SulphuricSand);
                }
            }
        }
    }
}

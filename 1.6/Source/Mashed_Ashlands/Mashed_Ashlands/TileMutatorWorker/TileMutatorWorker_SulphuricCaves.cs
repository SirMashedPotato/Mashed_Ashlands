using RimWorld;
using Verse;
using Verse.Noise;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_SulphuricCaves : TileMutatorWorker_Caves
    {
        private static readonly FloatRange LakeRadius = new FloatRange(10f, 15f);
        private static readonly FloatRange LakeSquash = new FloatRange(1f, 1.25f);
        private const float LakeNoiseFrequency = 0.03f;
        private const float LakeNoiseStrength = 5f;
        private const float LakeChancePerCell = 0.005f;
        private const float WaterThreshold = 0.8f;
        private const float SandThreshold = 0.5f;

        public TileMutatorWorker_SulphuricCaves(TileMutatorDef def) : base(def)
        {
        }

        public override void GeneratePostTerrain(Map map)
        {
            if (!ModsConfig.OdysseyActive)
            {
                return;
            }
            MapGenFloatGrid caves = MapGenerator.Caves;
            base.GeneratePostTerrain(map);
            foreach (IntVec3 allCell in map.AllCells)
            {
                if (caves[allCell] <= 0f || allCell.GetTerrain(map).IsWater || !Rand.Chance(LakeChancePerCell))
                {
                    continue;
                }
                ModuleBase input = new DistFromPoint(LakeRadius.RandomInRange);
                input = new ScaleBias(-1.0, 1.0, input);
                input = new Scale(LakeSquash.RandomInRange, 1.0, 1.0, input);
                input = new Rotate(0.0, Rand.Range(0f, 360f), 0.0, input);
                input = new Translate(-allCell.x, 0.0, -allCell.z, input);
                input = MapNoiseUtility.AddDisplacementNoise(input, LakeNoiseFrequency, LakeNoiseStrength, 4, map.Tile.tileId);
                CellRect cellRect = allCell.RectAbout(30, 30);
                cellRect.ClipInsideMap(map);
                foreach (IntVec3 item in cellRect)
                {
                    float num = (float)input.GetValue(item.x, 0.0, item.z);
                    if (!(num < 0.5f))
                    {
                        item.GetEdifice(map)?.Destroy();
                        if (num > WaterThreshold)
                        {
                            map.terrainGrid.SetTerrain(item, TerrainDefOf.Mashed_Ashlands_ShallowSulphuricWater);
                        }
                        else if (num > SandThreshold)
                        {
                            map.terrainGrid.SetTerrain(item, TerrainDefOf.Mashed_Ashlands_SulphuricSand);
                        }
                    }
                }
            }
        }
    }
}

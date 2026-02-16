using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_LandCoralOasis : TileMutatorWorker_Springs
    {
        private const float WaterThreshold = 0.85f;
        private const float EdgeThreshold = 0.65f;

        public TileMutatorWorker_LandCoralOasis(TileMutatorDef def) : base(def)
        {
        }

        public override void GeneratePostTerrain(Map map)
        {
            foreach (IntVec3 allCell in map.AllCells)
            {
                float value = springNoise.GetValue(allCell);
                if (value > WaterThreshold)
                {
                    map.terrainGrid.SetTerrain(allCell, RimWorld.TerrainDefOf.WaterOceanShallow);
                }
                else if (value > EdgeThreshold)
                {
                    map.terrainGrid.SetTerrain(allCell, TerrainDefOf.Mashed_Ashlands_CoralSand);
                }
            }
        }
    }
}

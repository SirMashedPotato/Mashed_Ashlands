using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_SulphuricCaves : AbstractTileMutatorWorker_Caves
    {
        private const float WaterThreshold = 0.8f;
        private const float SandThreshold = 0.5f;

        public TileMutatorWorker_SulphuricCaves(TileMutatorDef def) : base(def)
        {
        }

        public override void SetTerrain(float num, Map map, IntVec3 item)
        {
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

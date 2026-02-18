using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_SulphuricLake : TileMutatorWorker_Lake
    {
        public TileMutatorWorker_SulphuricLake(TileMutatorDef def) : base(def)
        {
        }

        protected override void ProcessCell(IntVec3 cell, Map map)
        {
            float valAt = GetValAt(cell, map);
            if (GenerateDeepWater && valAt > 0.75f)
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_DeepSulphuricWater);
            }
            else if (valAt > 0.5f)
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_ShallowSulphuricWater);
            }
            else if (valAt > 0.45f)
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_SulphuricSand);
            }
        }
    }
}

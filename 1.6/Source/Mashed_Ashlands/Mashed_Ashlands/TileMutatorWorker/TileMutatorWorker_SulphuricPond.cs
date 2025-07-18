using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_SulphuricPond : TileMutatorWorker_Lake
    {
        protected override float LakeRadius => 0.3f;

        public TileMutatorWorker_SulphuricPond(TileMutatorDef def) : base(def)
        {
        }

        protected override void ProcessCell(IntVec3 cell, Map map)
        {
            float valAt = GetValAt(cell, map);
            if (valAt > 0.5f)
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_ShallowSulphuricWater);
            }
            else if (valAt > 0.45f && MapGenUtility.ShouldGenerateBeachSand(cell, map))
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_SulphuricSand);
            }
        }
    }
}

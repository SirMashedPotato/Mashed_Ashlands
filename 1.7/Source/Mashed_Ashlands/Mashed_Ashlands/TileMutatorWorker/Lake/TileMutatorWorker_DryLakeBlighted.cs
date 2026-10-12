using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_DryLakeBlighted : RimWorld.TileMutatorWorker_DryLake
    {
        public TileMutatorWorker_DryLakeBlighted(TileMutatorDef def) : base(def)
        {
        }

        protected override void ProcessCell(IntVec3 cell, Map map)
        {
            float valAt = GetValAt(cell, map);
            if (valAt > 0.5f)
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_CrackedAshSoilBlighted);
            }
            else if (valAt > 0.45f)
            {
                map.terrainGrid.SetTerrain(cell, TerrainDefOf.Mashed_Ashlands_AshSandBlighted);
            }
        }
    }
}

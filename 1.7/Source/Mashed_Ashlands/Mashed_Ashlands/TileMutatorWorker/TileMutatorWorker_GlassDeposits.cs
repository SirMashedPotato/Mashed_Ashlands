using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_GlassDeposits : TileMutatorWorker
    {
        public TileMutatorWorker_GlassDeposits(TileMutatorDef def) : base(def)
        {
        }

        public override void GeneratePostTerrain(Map map)
        {
            if (ModsConfig.OdysseyActive)
            {
                float num = GenStep_RocksFromGrid.GetResourceBlotchesPer10KCellsForMap(map) * 0.1f;
                GenStep_ScatterLumpsMineable genStep_ScatterLumpsMineable = new GenStep_ScatterLumpsMineable
                {
                    maxValue = float.MaxValue,
                    countPer10kCellsRange = new FloatRange(num, num),
                    forcedDefToScatter = ThingDefOf.Mashed_Ashlands_MineableGlass
                };
                genStep_ScatterLumpsMineable.Generate(map, default);
            }
            base.GeneratePostTerrain(map);
        }
    }
}

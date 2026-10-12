using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_EbonyDeposits : TileMutatorWorker
    {
        public TileMutatorWorker_EbonyDeposits(TileMutatorDef def) : base(def)
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
                    forcedDefToScatter = ThingDefOf.Mashed_Ashlands_MineableEbony
                };
                genStep_ScatterLumpsMineable.Generate(map, default);
            }
            base.GeneratePostTerrain(map);
        }
    }
}

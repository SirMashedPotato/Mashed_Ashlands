using RimWorld;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_UndergroundMine : TileMutatorWorker_UndergroundCave
    {
        protected override float BranchChance => 0.1f;

        protected override float MinTunnelWidth => 2.6f;

        protected override float WidthOffsetPerCell => 0.0001f;

        public TileMutatorWorker_UndergroundMine(TileMutatorDef def) : base(def)
        {
        }
    }
}

using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class AbandonedMineEntrance : MapPortal
    {
        public TileMutatorWorker_AbandonedMine.MineType mineType;

        public AbandonedMineEntrance()
        {
            if (!ModsConfig.OdysseyActive)
            {
                Destroy();
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();
            //Scribe_Defs.Look(ref layout, "layout");
        }

        protected override Map GeneratePocketMapInt()
        {
            mineType = TileMutatorWorker_AbandonedMine.GetMineType(Map.Tile);
            return base.GeneratePocketMapInt();
        }

        protected override IEnumerable<GenStepWithParams> GetExtraGenSteps()
        {
            switch (mineType)
            {
                case TileMutatorWorker_AbandonedMine.MineType.Ebony:
                    yield return 
                    break;
                case TileMutatorWorker_AbandonedMine.MineType.Glass:
                    break;
                case TileMutatorWorker_AbandonedMine.MineType.Kwama:
                    break;
            }

            //return base.GetExtraGenSteps();
        }

        override 
    }
}

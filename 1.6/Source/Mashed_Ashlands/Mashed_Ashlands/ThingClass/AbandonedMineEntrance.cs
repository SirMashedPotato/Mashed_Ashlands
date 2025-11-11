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

        protected override Map GeneratePocketMapInt()
        {
            mineType = TileMutatorWorker_AbandonedMine.GetMineType(Map.Tile);
            return base.GeneratePocketMapInt();
        }

        protected override IEnumerable<GenStepWithParams> GetExtraGenSteps()
        {
            foreach(GenStepWithParams genStep in base.GetExtraGenSteps()) 
            { 
                yield return genStep; 
            }

            switch (mineType)
            {
                case TileMutatorWorker_AbandonedMine.MineType.Ebony:
                    Log.Message(mineType);
                    yield return new GenStepWithParams(GenStepDefOf.Mashed_Ashlands_AbandonedMine_EbonyLumps, new GenStepParams());
                    break;

                case TileMutatorWorker_AbandonedMine.MineType.Glass:
                    Log.Message(mineType);
                    yield return new GenStepWithParams(GenStepDefOf.Mashed_Ashlands_AbandonedMine_GlassLumps, new GenStepParams());
                    break;

                case TileMutatorWorker_AbandonedMine.MineType.Kwama:
                    Log.Message(mineType);
                    break;
            }
        }
    }
}

using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class Building_AbandonedMineEntrance : MapPortal
    {
        public TileMutatorWorker_AbandonedMine.MineType MineType => TileMutatorWorker_AbandonedMine.GetMineType(Map.Tile);

        public Building_AbandonedMineEntrance()
        {
            if (!ModsConfig.OdysseyActive)
            {
                Destroy();
            }
        }

        protected override Map GeneratePocketMapInt()
        {
            MapGeneratorDef mapGeneratorDef;

            switch (MineType)
            {
                case TileMutatorWorker_AbandonedMine.MineType.Kwama:
                    mapGeneratorDef = MapGeneratorDefOf.Mashed_Ashlands_AbandonedKwamaNest;
                    break;

                default:
                    mapGeneratorDef = MapGeneratorDefOf.Mashed_Ashlands_AbandonedMine;
                    break;
            }

            return PocketMapUtility.GeneratePocketMap(new IntVec3(def.portal.pocketMapSize, 1, def.portal.pocketMapSize), mapGeneratorDef, GetExtraGenSteps(), Map);
        }

        protected override IEnumerable<GenStepWithParams> GetExtraGenSteps()
        {
            foreach(GenStepWithParams genStep in base.GetExtraGenSteps()) 
            { 
                yield return genStep; 
            }

            switch (MineType)
            {
                case TileMutatorWorker_AbandonedMine.MineType.Ebony:
                    yield return new GenStepWithParams(GenStepDefOf.Mashed_Ashlands_AbandonedMine_EbonyLumps, new GenStepParams());
                    break;

                case TileMutatorWorker_AbandonedMine.MineType.Glass:
                    yield return new GenStepWithParams(GenStepDefOf.Mashed_Ashlands_AbandonedMine_GlassLumps, new GenStepParams());
                    break;

                case TileMutatorWorker_AbandonedMine.MineType.Kwama:
                    break;
            }
        }
    }
}

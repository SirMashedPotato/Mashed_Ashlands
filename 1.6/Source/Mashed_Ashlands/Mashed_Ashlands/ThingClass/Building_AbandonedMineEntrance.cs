using RimWorld;
using System.Collections.Generic;
using System.Text;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class Building_AbandonedMineEntrance : MapPortal
    {
        public TileMutatorWorker_AbandonedMine.MineType MineType => TileMutatorWorker_AbandonedMine.GetMineType(Map.Tile);

        private Comp_Restorable restorable;
        private CompSealable sealable;
        private GraphicData openGraphicData;
        private const string OpenTexturePath = "Things/Building/Natural/Mashed_Ashlands_CaveEntrance/Mashed_Ashlands_CaveEntrance";
        private GraphicData sealedGraphicData;
        private const string sealedTexturePath = "Things/Building/Natural/Mashed_Ashlands_CaveEntrance/Mashed_Ashlands_CaveEntranceSealed";

        private Comp_Restorable Restorable => restorable ?? (restorable = GetComp<Comp_Restorable>());
        private CompSealable Sealable => sealable ?? (sealable = GetComp<CompSealable>());

        public Building_AbandonedMineEntrance()
        {
            if (!ModsConfig.OdysseyActive)
            {
                Destroy();
            }
        }

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);

            openGraphicData = new GraphicData();
            openGraphicData.CopyFrom(def.graphicData);
            openGraphicData.texPath = OpenTexturePath;

            sealedGraphicData = new GraphicData();
            sealedGraphicData.CopyFrom(def.graphicData);
            sealedGraphicData.texPath = sealedTexturePath;
        }

        public override void Print(SectionLayer layer)
        {
            if (!Sealable.CanEnterPortal())
            {
                sealedGraphicData.Graphic.Print(layer, this, 0f);
            }
            else if (IsEnterable(out var _))
            {
                openGraphicData.Graphic.Print(layer, this, 0f);
            }
            else
            {
                Graphic.Print(layer, this, 0f);
            }
        }

        public override bool IsEnterable(out string reason)
        {
            if (!Restorable.IsRestored)
            {
                reason = Restorable.Props.notRestoredInspectString;
                return false;
            }
            return base.IsEnterable(out reason);
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

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach(Gizmo gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }
        }
    }
}

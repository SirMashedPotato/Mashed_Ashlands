using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_UndercaveEntrance : TileMutatorWorker
    {
        public TileMutatorWorker_UndercaveEntrance(TileMutatorDef def) : base(def)
        {
        }

        public override string GetLabel(PlanetTile tile)
        {
            return GetMineType(tile).label;
        }

        public override string GetDescription(PlanetTile tile)
        {
            return base.GetDescription(tile) + " " + GetMineType(tile).mutatorExtraDescription;
        }

        public static UndercaveTypeDef GetMineType(PlanetTile tile)
        {
            Rand.PushState(tile.tileId);
            UndercaveTypeDef result = OnStartupUtility.randomUndercaveTypes.RandomElementByWeight(x => x.weight);
            Rand.PopState();
            return result;
        }
    }
}

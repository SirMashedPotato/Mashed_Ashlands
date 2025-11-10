using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_AbandonedMine : TileMutatorWorker
    {
        public enum MineType
        {
            Ebony,
            Glass,
            Kwama
        }

        public static readonly List<MineType> GeneratableMineTypes = new List<MineType>
        {
            MineType.Ebony,
            MineType.Glass,
            MineType.Kwama
        };

        public TileMutatorWorker_AbandonedMine(TileMutatorDef def) : base(def)
        {
        }

        public override string GetLabel(PlanetTile tile)
        {
            return ("Mashed_Ashlands_AbandonedMine_" + GetMineType(tile)).Translate();
        }

        public static MineType GetMineType(PlanetTile tile)
        {
            Rand.PushState(tile.tileId);
            MineType result = GeneratableMineTypes.RandomElement();
            Rand.PopState();
            return result;
        }
    }
}

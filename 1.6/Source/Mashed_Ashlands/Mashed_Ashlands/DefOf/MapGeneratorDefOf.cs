using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class MapGeneratorDefOf
    {
        static MapGeneratorDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MapGeneratorDefOf));
        }
        public static GenStepDef SteamGeysers;

        [MayRequireOdyssey]
        public static MapGeneratorDef Mashed_Ashlands_AbandonedMine;
        [MayRequireOdyssey]
        public static MapGeneratorDef Mashed_Ashlands_AbandonedKwamaNest;
    }
}
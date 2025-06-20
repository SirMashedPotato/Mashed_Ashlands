using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class ThinkTreeDefOf
    {
        static ThinkTreeDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThinkTreeDefOf));
        }
        public static ThinkTreeDef Mashed_Ashlands_FeedFromAshlandFlower;
    }
}
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class JobDefOf
    {
        static JobDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
        }
        public static JobDef Mashed_Ashlands_FeedFromAshlandFlower;
    }
}
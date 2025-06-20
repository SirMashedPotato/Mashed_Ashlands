using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class EffecterDefOf
    {
        static EffecterDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(EffecterDefOf));
        }
        public static EffecterDef Mashed_Ashlands_FetcherflySwarmEffecter;
        public static EffecterDef Mashed_Ashlands_EmergeFromAsh;
        public static EffecterDef Mashed_Ashlands_EmergeFromAshLarge;
        public static EffecterDef Mashed_Ashlands_AshCloud;
    }
}
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class TileMutatorDefOf
    {
        static TileMutatorDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(TileMutatorDefOf));
        }

        [MayRequireOdyssey]
        public static TileMutatorDef Mashed_Ashlands_StriderCrossing;
    }
}

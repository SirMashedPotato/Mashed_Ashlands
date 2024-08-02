using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class PawnKindDefOf
    {
        static PawnKindDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PawnKindDefOf));
        }
        public static PawnKindDef Mashed_Ashlands_SiltStrider;
        public static PawnKindDef Mashed_Ashlands_Ogrim;
        public static PawnKindDef Mashed_Ashlands_CliffRacer;
    }
}
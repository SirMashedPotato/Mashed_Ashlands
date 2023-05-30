using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class LetterDefOf
    {
        static LetterDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(LetterDefOf));
        }
        public static LetterDef MorrowRim_VolcanoNegativeEvent;
    }
}

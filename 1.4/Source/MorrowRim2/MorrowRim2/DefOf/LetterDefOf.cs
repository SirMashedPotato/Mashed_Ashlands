using RimWorld;
using Verse;

namespace MorrowRim2
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

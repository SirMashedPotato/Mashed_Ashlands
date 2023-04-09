using RimWorld;

namespace MorrowRim2
{
    [DefOf]
    public static class StatDefOf
    {
        static StatDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StatDefOf));
        }
        public static StatDef MorrowRim_AshResistance;
    }
}
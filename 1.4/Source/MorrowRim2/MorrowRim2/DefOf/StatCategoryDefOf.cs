using RimWorld;

namespace MorrowRim2
{
    [DefOf]
    public static class StatCategoryDefOf
    {
        static StatCategoryDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StatCategoryDefOf));
        }
        public static StatCategoryDef MorrowRim_VolcanoIncidentRadius;
        public static StatCategoryDef MorrowRim_VolcanoPotentialIncidents;
    }
}
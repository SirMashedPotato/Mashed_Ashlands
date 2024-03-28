using RimWorld;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class StatCategoryDefOf
    {
        static StatCategoryDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StatCategoryDefOf));
        }
        public static StatCategoryDef Mashed_Ashlands_VolcanoIncidentRadius;
        public static StatCategoryDef Mashed_Ashlands_VolcanoPotentialIncidents;
    }
}
using RimWorld;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class HistoryEventDefOf
    {
        static HistoryEventDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HistoryEventDefOf));
        }
        public static HistoryEventDef Mashed_Ashlands_CliffRacerExtinction;
        public static HistoryEventDef Mashed_Ashlands_CliffRacerReturn;
    }
}
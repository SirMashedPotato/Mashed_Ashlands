using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class ThingDefOf
    {
        static ThingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
        }

        public static ThingDef Mashed_Ashlands_VolcanicDebris;
        public static ThingDef Mashed_Ashlands_VolcanicDebrisIncoming;
        public static ThingDef Mashed_Ashlands_AshCastle;
        public static ThingDef Mashed_Ashlands_SiltStrider;
        public static ThingDef Mashed_Ashlands_CliffRacer;
        public static ThingDef Mashed_Ashlands_Egg_CliffRacerFertilized;
    }
}
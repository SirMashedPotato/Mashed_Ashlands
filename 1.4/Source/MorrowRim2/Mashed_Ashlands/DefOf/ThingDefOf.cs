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
    }
}
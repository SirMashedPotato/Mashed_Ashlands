using RimWorld;
using Verse;

namespace MorrowRim2
{
    [DefOf]
    public static class ThingDefOf
    {
        static ThingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
        }

        public static ThingDef MorrowRim_VolcanicDebris;
        public static ThingDef MorrowRim_VolcanicDebrisIncoming;
        public static ThingDef MorrowRim_AshCastle;
    }
}
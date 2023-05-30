using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class HediffDefOf
    {
        static HediffDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
        }
        public static HediffDef MorrowRim_AshBuildup;
        public static HediffDef MorrowRim_AshCloggedServo;
        public static HediffDef MorrowRim_AshInEyes;
        public static HediffDef MorrowRim_AshBlight;
    }
}
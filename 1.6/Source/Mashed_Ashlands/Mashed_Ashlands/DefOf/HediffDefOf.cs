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
        public static HediffDef Mashed_Ashlands_AshBuildup;
        public static HediffDef Mashed_Ashlands_AshCloggedServo;
        public static HediffDef Mashed_Ashlands_AshInEyes;
        public static HediffDef Mashed_Ashlands_AshBlight;
        public static HediffDef Mashed_Ashlands_XylariaDreamPowderHigh;
    }
}
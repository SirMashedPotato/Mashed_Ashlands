using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class GenStepDefOf
    {
        static GenStepDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(GenStepDefOf));
        }
        public static GenStepDef SteamGeysers;

        [MayRequireOdyssey]
        public static GenStepDef Mashed_Ashlands_AbandonedMine_EbonyLumps;
        [MayRequireOdyssey]
        public static GenStepDef Mashed_Ashlands_AbandonedMine_EbonyLumpLarge;
        [MayRequireOdyssey]
        public static GenStepDef Mashed_Ashlands_AbandonedMine_GlassLumps;
        [MayRequireOdyssey]
        public static GenStepDef Mashed_Ashlands_AbandonedMine_GlassLumpLarge;
    }
}
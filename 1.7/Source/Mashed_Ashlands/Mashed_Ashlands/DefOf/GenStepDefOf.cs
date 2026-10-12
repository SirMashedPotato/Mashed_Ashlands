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
    }
}
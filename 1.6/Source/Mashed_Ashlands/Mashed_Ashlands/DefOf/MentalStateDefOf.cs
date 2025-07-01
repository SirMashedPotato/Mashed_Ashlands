using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class MentalStateDefOf
    {
        static MentalStateDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MentalStateDefOf));
        }
        public static MentalStateDef Mashed_Ashlands_BlightedPermanent;
    }
}

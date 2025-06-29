using RimWorld;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class TraderKindDefOf
    {
        static TraderKindDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(TraderKindDefOf));
        }
        public static TraderKindDef Mashed_Ashlands_MudcrabMerchant;
    }
}
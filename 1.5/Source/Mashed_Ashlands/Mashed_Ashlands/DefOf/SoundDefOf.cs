using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class SoundDefOf
    {
        static SoundDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(SoundDefOf));
        }

        [MayRequireRoyalty]
        public static SoundDef AnimaTreeScream;
    }
}
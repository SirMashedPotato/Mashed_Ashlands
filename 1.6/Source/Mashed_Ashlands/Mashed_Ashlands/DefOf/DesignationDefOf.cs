using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class DesignationDefOf
    {
        static DesignationDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(DesignationDefOf));
        }
        public static DesignationDef Mashed_Ashlands_Restore;
    }
}
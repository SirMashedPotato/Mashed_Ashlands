using RimWorld;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class BiomeDefOf
    {
        static BiomeDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BiomeDefOf));
        }
        public static BiomeDef Mashed_Ashlands_Ashlands;
        public static BiomeDef Mashed_Ashlands_ForestAshlands;
        public static BiomeDef Mashed_Ashlands_BlightedAshlands;
        public static BiomeDef Mashed_Ashlands_VolcanicAshlands;
    }
}
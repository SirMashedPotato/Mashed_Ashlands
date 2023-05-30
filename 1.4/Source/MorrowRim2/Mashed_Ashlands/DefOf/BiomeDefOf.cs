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
        public static BiomeDef MorrowRim_Ashlands;
        public static BiomeDef MorrowRim_ForestAshlands;
        public static BiomeDef MorrowRim_CoralCoastAshlands;

        public static BiomeDef MorrowRim_BlightedAshlands;

        public static BiomeDef MorrowRim_VolcanicAshlands;
        public static BiomeDef MorrowRim_VolcanicCoralCoastAshlands;

        public static BiomeDef MorrowRim_CragIslandAshlands;
        public static BiomeDef MorrowRim_BlightedCragIslandAshlands;
        public static BiomeDef MorrowRim_SwampIslandAshlands;
        public static BiomeDef MorrowRim_VolcanicCragIslandAshlands;
    }
}
using RimWorld;

namespace MorrowRim2
{
    [DefOf]
    public static class BiomeDefOf
    {
        static BiomeDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BiomeDefOf));
        }
        public static BiomeDef MorrowRim_Ashlands;
        public static BiomeDef MorrowRim_BlightedAshlands;
        public static BiomeDef MorrowRim_VolcanicAshlands;
        public static BiomeDef MorrowRim_SwampAshlands;
        public static BiomeDef MorrowRim_CoastalAshlands;
        public static BiomeDef MorrowRim_VolcanicCoastalAshlands;
        public static BiomeDef MorrowRim_GrazelandAshlands;
        public static BiomeDef MorrowRim_SaltplainAshlands;
        public static BiomeDef MorrowRim_HighlandAshlands;
        public static BiomeDef MorrowRim_CragIslandAshlands;
    }
}
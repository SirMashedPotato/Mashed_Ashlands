using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class TerrainDefOf
    {
        static TerrainDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(TerrainDefOf));
        }

        public static TerrainDef Mashed_Ashlands_SulphuricSand;
        public static TerrainDef Mashed_Ashlands_ShallowSulphuricWater;
        public static TerrainDef Mashed_Ashlands_DeepSulphuricWater;
        public static TerrainDef Mashed_Ashlands_AshMudBlighted;
        public static TerrainDef Mashed_Ashlands_BlightedSludge;
    }
}
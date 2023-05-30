using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class TerrainAffordanceDefOf
    {
        static TerrainAffordanceDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(TerrainAffordanceDefOf));
        }

        public static TerrainAffordanceDef MorrowRim_AshCastle;
    }
}
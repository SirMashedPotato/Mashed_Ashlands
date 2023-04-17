using RimWorld;
using Verse;

namespace MorrowRim2
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
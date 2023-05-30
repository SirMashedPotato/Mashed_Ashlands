using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_SwampAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableSwampAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.MorrowRim_Ashlands && tile.biome != BiomeDefOf.MorrowRim_ForestAshlands)
            {
                return -100f;
            }
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }
            if (tile.temperature < 15f)
            {
                return 0f;
            }
            if (tile.rainfall < 1500f)
            {
                return 0f;
            }
            return 15 + (tile.swampiness * 15);
        }
    }
}

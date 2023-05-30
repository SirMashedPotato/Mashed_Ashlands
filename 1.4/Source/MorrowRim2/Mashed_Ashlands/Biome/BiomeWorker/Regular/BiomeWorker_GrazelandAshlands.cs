using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_GrazelandAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableGrazelandAshlands)
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
            if (tile.swampiness > 0.2f)
            {
                return 0f;
            }
            if (tile.temperature < 0f)
            {
                return 0f;
            }
            if (tile.rainfall < 600f || tile.rainfall >= 1800f)
            {
                return 0f;
            }
            if (tile.elevation <= 600f || tile.elevation >= 1000f)
            {
                return 0f;
            }
            return 15 + (tile.rainfall / 100) + (tile.elevation / 100) + (tile.temperature / 100);
        }
    }
}

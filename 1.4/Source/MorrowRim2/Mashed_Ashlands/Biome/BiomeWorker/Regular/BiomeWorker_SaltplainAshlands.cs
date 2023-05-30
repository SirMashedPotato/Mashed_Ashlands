using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_SaltplainAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableSaltplainAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_Ashlands && tile.biome != BiomeDefOf.Mashed_Ashlands_ForestAshlands)
            {
                return -100f;
            }
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }
            if (tile.rainfall > 250f)
            {
                return 0f;
            }
            return 15 + (tile.rainfall / 50);
        }
    }
}

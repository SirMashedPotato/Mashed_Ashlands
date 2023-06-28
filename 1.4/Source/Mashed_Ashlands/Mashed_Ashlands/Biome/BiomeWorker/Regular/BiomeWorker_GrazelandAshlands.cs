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
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_Ashlands)
            {
                return -100f;
            }

            return GrasslandBiomeWorker(tile);
        }
    }
}

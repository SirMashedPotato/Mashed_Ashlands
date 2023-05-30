using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_CoralCoastAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableCoralCoastAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.MorrowRim_Ashlands)
            {
                return -100f;
            }
            if (tile.temperature < 10f)
            {
                return 0f;
            }
            return CoastBiomeWorker(tileID, BiomeDefOf.MorrowRim_CoralCoastAshlands);
        }
    }
}

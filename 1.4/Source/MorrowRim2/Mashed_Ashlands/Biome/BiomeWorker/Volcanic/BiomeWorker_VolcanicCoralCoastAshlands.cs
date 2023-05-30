using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_VolcanicCoralCoastAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableVolcanicCoralCoastAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_VolcanicAshlands)
            {
                return -100f;
            }
            return CoastBiomeWorker(tileID, BiomeDefOf.Mashed_Ashlands_VolcanicCoralCoastAshlands);
        }
    }
}

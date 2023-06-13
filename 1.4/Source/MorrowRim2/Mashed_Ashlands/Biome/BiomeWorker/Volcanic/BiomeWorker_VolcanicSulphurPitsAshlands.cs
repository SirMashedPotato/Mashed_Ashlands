using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_VolcanicSulphurPitsAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableVolcanicSulphurPitsAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_VolcanicAshlands)
            {
                return -100f;
            }

            return SwampBiomeWorker(tile);
        }
    }
}

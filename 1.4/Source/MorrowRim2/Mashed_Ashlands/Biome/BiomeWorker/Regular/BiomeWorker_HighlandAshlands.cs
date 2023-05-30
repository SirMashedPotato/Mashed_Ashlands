using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_HighlandAshlands : AshlandBiomeWorker
    {
        /// <summary>
        /// Only here to prevent gen through standard methods
        /// Possibly add in alternative gen, with setting to disable volcano based gen
        /// </summary>
        public override float GetScore(Tile tile, int tileID)
        {
            if (Mashed_Ashlands_ModSettings.OldBiomeGen)
            {

            }

            return 0;
        }

        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableHighlandAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.MorrowRim_Ashlands && tile.biome != BiomeDefOf.MorrowRim_ForestAshlands)
            {
                return -100f;
            }
            if (tile.hilliness == Hilliness.Flat)
            {
                return 0f;
            }
            if (tile.temperature > 10f)
            {
                return 0f;
            }
            return 15 + (tile.elevation / 100);
        }
    }
}

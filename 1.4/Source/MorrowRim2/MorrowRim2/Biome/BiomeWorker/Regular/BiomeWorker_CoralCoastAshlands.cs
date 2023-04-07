using RimWorld.Planet;

namespace MorrowRim2
{
    public class BiomeWorker_CoralCoastAshlands : AshlandBiomeWorker
    {
        /// <summary>
        /// Only here to prevent gen through standard methods
        /// Possibly add in alternative gen, with setting to disable volcano based gen
        /// </summary>
        public override float GetScore(Tile tile, int tileID)
        {
            if (MorrowRim_ModSettings.OldBiomeGen)
            {

            }

            return 0;
        }

        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!MorrowRim_ModSettings.EnableCoralCoastAshlands)
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

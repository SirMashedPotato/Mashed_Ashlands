using RimWorld.Planet;

namespace MorrowRim2
{
    public class BiomeWorker_SwampAshlands : AshlandBiomeWorker
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
            if (!MorrowRim_ModSettings.EnableSwampAshlands)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            if (tile.swampiness < 0.5f)
            {
                return 0f;
            }
            if (tile.rainfall < 600f)
            {
                return 0f;
            }
            if (tile.biome != BiomeDefOf.MorrowRim_Ashlands)
            {
                return 0f;
            }
            return tile.swampiness * 30;
        }
    }
}

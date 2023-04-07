using RimWorld.Planet;
using Verse;

namespace MorrowRim2
{
    public class BiomeWorker_HighlandAshlands : AshlandBiomeWorker
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
            if (!MorrowRim_ModSettings.EnableHighlandAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.MorrowRim_Ashlands)
            {
                return -100f;
            }
            if (tile.hilliness == Hilliness.Flat)
            {
                return 0f;
            }
            if (tile.temperature > 15f)
            {
                return 0f;
            }
            if (tile.elevation < 1000f)
            {
                return 0f;
            }
            return Rand.Range(10, 15) + (tile.elevation / 100);
        }
    }
}

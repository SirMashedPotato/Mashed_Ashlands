using RimWorld.Planet;

namespace MorrowRim2
{
    public class BiomeWorker_SaltplainAshlands : AshlandBiomeWorker
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
            if (!MorrowRim_ModSettings.EnableSaltplainAshlands)
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
            if (tile.rainfall > 250f)
            {
                return 0f;
            }
            return 15 + (tile.rainfall / 50);
        }
    }
}

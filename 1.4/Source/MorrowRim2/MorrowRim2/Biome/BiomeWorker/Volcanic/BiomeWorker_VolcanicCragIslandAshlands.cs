using RimWorld.Planet;

namespace MorrowRim2
{
    public class BiomeWorker_VolcanicCragIslandAshlands : AshlandBiomeWorker
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
            if (!MorrowRim_ModSettings.EnableVolcanicCragIslandAshlands)
            {
                return -100f;
            }
            if (!tile.WaterCovered)
            {
                return -100f;
            }
            return IslandBiomeWorker(tileID, WorldObjectDefOf.MorrowRim_VolcanoActive, BiomeDefOf.MorrowRim_VolcanicCragIslandAshlands);
        }
    }
}

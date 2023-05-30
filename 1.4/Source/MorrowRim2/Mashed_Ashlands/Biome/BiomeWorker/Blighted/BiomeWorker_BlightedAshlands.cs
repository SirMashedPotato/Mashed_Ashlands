using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_BlightedAshlands : AshlandBiomeWorker
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
            if (!Mashed_Ashlands_ModSettings.EnableBlightedAshlands)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            return BaseBiomeWorker(tileID, WorldObjectDefOf.MorrowRim_VolcanoBlighted);
        }
    }
}

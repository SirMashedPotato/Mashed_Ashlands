using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_ForestAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableForestAshlands)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            return BaseBiomeWorker(tileID, WorldObjectDefOf.MorrowRim_VolcanoExtinct);
        }
    }
}

using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_BlightedCragIslandAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableBlightedCragIslandAshlands)
            {
                return -100f;
            }
            if (!tile.WaterCovered)
            {
                return -100f;
            }
            return IslandBiomeWorker(tileID, WorldObjectDefOf.MorrowRim_VolcanoBlighted, BiomeDefOf.MorrowRim_BlightedCragIslandAshlands);
        }
    }
}

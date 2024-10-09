using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_BlightedPetrifiedForestAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID, WorldObject sourceObject = null)
        {
            if (!Mashed_Ashlands_ModSettings.EnableBlightedPetrifiedForestAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_BlightedAshlands)
            {
                return -100f;
            }

            return ExtraBiomeWorker(tile, tileID);
        }
    }
}

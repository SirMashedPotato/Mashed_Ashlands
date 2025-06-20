using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_BlightedBogAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID, WorldObject sourceObject = null)
        {
            if (!Mashed_Ashlands_ModSettings.EnableBlightedBogAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_BlightedAshlands)
            {
                return -100f;
            }

            return SwampBiomeWorker(tile);
        }
    }
}

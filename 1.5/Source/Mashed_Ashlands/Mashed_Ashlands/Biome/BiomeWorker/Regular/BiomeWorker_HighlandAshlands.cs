using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_HighlandAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID, WorldObject sourceObject = null)
        {
            if (!Mashed_Ashlands_ModSettings.EnableDustplainAshlands) //TODO
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_Ashlands)
            {
                return -100f;
            }

            return MountainBiomeWorker(tile);
        }
    }
}

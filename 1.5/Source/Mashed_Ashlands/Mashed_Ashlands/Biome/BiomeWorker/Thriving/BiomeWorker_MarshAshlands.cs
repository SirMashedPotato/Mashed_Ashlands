using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_MarshAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID, WorldObject sourceObject = null)
        {
            if (!Mashed_Ashlands_ModSettings.EnableMarshAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_ForestAshlands)
            {
                return -100f;
            }

            return SwampBiomeWorker(tile);
        }
    }
}

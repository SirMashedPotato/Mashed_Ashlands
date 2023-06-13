using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_SaltmarshAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableSaltmarshAshlands)
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

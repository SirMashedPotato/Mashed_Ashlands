using RimWorld;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_MeadowAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject = null)
        {
            if (!Mashed_Ashlands_ModSettings.EnableMeadowAshlands)
            {
                return -100f;
            }
            if (tile.PrimaryBiome != BiomeDefOf.Mashed_Ashlands_ForestAshlands)
            {
                return -100f;
            }

            return GrasslandBiomeWorker(biome, tile, planetTile);
        }
    }
}

using RimWorld.Planet;
using RimWorld;

namespace Mashed_Ashlands
{
    public class BiomeWorker_ThrivingCoralCoastAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject)
        {
            if (!Mashed_Ashlands_ModSettings.EnableMeadowAshlands) //TODO
            {
                return -100f;
            }
            if (tile.PrimaryBiome != BiomeDefOf.Mashed_Ashlands_ForestAshlands)
            {
                return -100f;
            }

            return CoastBiomeWorker(biome, tile, planetTile, biome);
        }
    }
}

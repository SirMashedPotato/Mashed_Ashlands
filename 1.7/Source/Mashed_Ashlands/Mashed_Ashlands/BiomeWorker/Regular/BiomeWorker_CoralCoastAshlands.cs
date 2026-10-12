using RimWorld.Planet;
using RimWorld;

namespace Mashed_Ashlands
{
    public class BiomeWorker_CoralCoastAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject)
        {
            if (!Mashed_Ashlands_ModSettings.EnableMeadowAshlands) //TODO
            {
                return -100f;
            }
            if (tile.PrimaryBiome != BiomeDefOf.Mashed_Ashlands_Ashlands)
            {
                return -100f;
            }

            return CoastBiomeWorker(biome, tile, planetTile, biome);
        }
    }
}

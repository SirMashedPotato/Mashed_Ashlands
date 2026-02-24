using RimWorld;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_VolcanicGroveAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject = null)
        {
            if (!Mashed_Ashlands_ModSettings.EnableVolcanicBadlandsAshlands) //todo
            {
                return -100f;
            }
            if (tile.PrimaryBiome != BiomeDefOf.Mashed_Ashlands_VolcanicAshlands)
            {
                return -100f;
            }

            return JungleBiomeWorker(biome, tile, planetTile);
        }
    }
}

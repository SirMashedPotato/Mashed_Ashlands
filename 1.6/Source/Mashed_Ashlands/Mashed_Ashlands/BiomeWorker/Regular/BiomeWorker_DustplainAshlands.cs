using RimWorld;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_DustplainAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject = null)
        {
            if ((Mashed_Ashlands_ModSettings.EnableDustplainAshlands && tile.PrimaryBiome == BiomeDefOf.Mashed_Ashlands_Ashlands) ||
                (Mashed_Ashlands_ModSettings.EnableDustplainAshlandsThriving && tile.PrimaryBiome == BiomeDefOf.Mashed_Ashlands_ForestAshlands))
            {
                return AridBiomeWorker(biome, tile, planetTile);
            }

            return -100f;
        }
    }
}

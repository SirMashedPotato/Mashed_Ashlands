using RimWorld;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_VolcanicSulphurPitsAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject = null)
        {
            if (!Mashed_Ashlands_ModSettings.EnableVolcanicSulphurPitsAshlands)
            {
                return -100f;
            }
            if (tile.PrimaryBiome != BiomeDefOf.Mashed_Ashlands_VolcanicAshlands)
            {
                return -100f;
            }

            return SwampBiomeWorker(biome, tile, planetTile);
        }
    }
}

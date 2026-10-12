using RimWorld;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_Ashlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject)
        {
            if (!Mashed_Ashlands_ModSettings.EnableStandardAshlands)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            if (sourceObject.def != WorldObjectDefOf.Mashed_Ashlands_VolcanoDormant)
            {
                return -100f;
            }
            return BaseBiomeWorker(biome, tile, planetTile, sourceObject);
        }
    }
}

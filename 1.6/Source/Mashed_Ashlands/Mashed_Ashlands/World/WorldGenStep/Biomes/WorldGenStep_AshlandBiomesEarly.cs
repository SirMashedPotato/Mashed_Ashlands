using Verse;
using RimWorld.Planet;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class WorldGenStep_AshlandBiomesEarly : WorldGenStep_AshlandBiomes
    {
        public override int SeedPart => 48151623;

        public static void DebugGenerate(string seed, PlanetLayer layer)
        {
            WorldGenStep_AshlandBiomesEarly instance = new WorldGenStep_AshlandBiomesEarly();
            instance.GenerateFresh(seed, layer);
        }

        public override void GenerateFresh(string seed, PlanetLayer layer)
        {
            List<WorldObject> worldVolcanos = WorldGenUtility.GetWorldVolcanosForLayer(layer);
            foreach (WorldObject volcano in worldVolcanos)
            {
                layer.Filler.FloodFill(volcano.Tile, (PlanetTile tile) => true, delegate (PlanetTile index, int dist)
                {
                    Tile tile = layer.Tiles[index];
                    if (PreventAshlandOverride.Get(tile.PrimaryBiome) == null)
                    {
                        return false;
                    }
                    tile.PrimaryBiome = AshlandBiomeFrom(tile, index, layer, OnStartupUtility.earlyAshlandBiomeDefs, volcano);
                    return true;
                }
                , Find.WorldGrid.TilesNumWithinTraversalDistance(WorldGenUtility.BiomeMaxDistanceForWorld() + 1)
                );
            }
        }
    }
}

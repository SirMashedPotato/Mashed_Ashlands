using Verse;
using RimWorld.Planet;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class WorldGenStep_AshlandBiomesEarly : WorldGenStep_AshlandBiomes
    {
        public override int SeedPart => 48151623;

        public static void DebugGenerate(string seed)
        {
            WorldGenStep_AshlandBiomesEarly instance = new WorldGenStep_AshlandBiomesEarly();
            instance.GenerateFresh(seed);
        }

        public override void GenerateFresh(string seed)
        {
            WorldGrid grid = Find.WorldGrid;
            List<WorldObject> worldVolcanos = WorldGenUtility.GetWorldVolcanos();
            foreach (WorldObject volcano in worldVolcanos)
            {
                Find.WorldFloodFiller.FloodFill(volcano.Tile, (int tile) => true, delegate (int index, int dist)
                {
                    Tile tile = Find.WorldGrid.tiles[index];
                    if (PreventAshlandOverride.Get(tile.biome) != null)
                    {
                        return;
                    }
                    tile.biome = AshlandBiomeFrom(tile, index, OnStartupUtility.earlyAshlandBiomeDefs, volcano);
                }
                , Find.WorldGrid.TilesNumWithinTraversalDistance(WorldGenUtility.BiomeMaxDistanceForWorld() + 1)
                );
            }
        }
    }
}

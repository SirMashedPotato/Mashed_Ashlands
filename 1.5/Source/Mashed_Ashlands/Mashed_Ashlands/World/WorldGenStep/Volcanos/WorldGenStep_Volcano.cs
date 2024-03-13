using Verse;
using RimWorld.Planet;
using RimWorld;

namespace Mashed_Ashlands
{
    public abstract class WorldGenStep_Volcano : WorldGenStep
    {
        private const int coastalVolcanoDistance = 6;

        public void GenerateVolcanos(WorldObjectDef volcanoDef, float initialMaxNum)
        {
            int numGenerated = 0;
            int maxNumber = (int)initialMaxNum;
            if (Mashed_Ashlands_ModSettings.VolcanoScaleWithWorldSize)
            {
                maxNumber = (int)(initialMaxNum * ((Find.World.PlanetCoverage * 2) + 0.4f));
                if (maxNumber < 1)
                {
                    maxNumber = 1;
                }
            }
            WorldGrid grid = Find.WorldGrid;
            for (int i = 0; i < grid.TilesCount; i++)
            {
                if (numGenerated >= maxNumber)
                {
                    return;
                }

                bool validTile = false;

                if (grid[i].hilliness == Hilliness.Impassable && !Find.WorldObjects.AnyWorldObjectAt(i))
                {
                    if (grid[i].biome != RimWorld.BiomeDefOf.IceSheet && grid[i].biome != RimWorld.BiomeDefOf.SeaIce)
                    {
                        validTile = true;
                    }
                }

                else
                {
                    if (Mashed_Ashlands_ModSettings.EnableCoastalVolcano)
                    {
                        if (grid[i].biome == RimWorld.BiomeDefOf.Ocean)
                        {
                            Find.WorldFloodFiller.FloodFill(i, (int tile) => true, delegate (int tile, int dist)
                            {
                                if (dist < coastalVolcanoDistance)
                                {
                                    if (!grid[tile].WaterCovered)
                                    {
                                        validTile = false;
                                        return;
                                    }
                                }
                                if (dist == coastalVolcanoDistance + 1)
                                {
                                    if (!grid[tile].WaterCovered)
                                    {
                                        validTile = true;
                                    }
                                }
                            });
                        }
                    }
                }

                if (validTile)
                {
                    float distanceToClosestVolcano = WorldGenUtility.DistanceToClosestVolcano(i);
                    if (distanceToClosestVolcano >= Mashed_Ashlands_ModSettings.VolcanoMinDistance)
                    {
                        WorldObject volcano = WorldObjectMaker.MakeWorldObject(volcanoDef);
                        volcano.Tile = i;
                        Find.WorldObjects.Add(volcano);
                        numGenerated++;

                        ///For coastal volcano gen
                        if (grid[i].biome == RimWorld.BiomeDefOf.Ocean)
                        {
                            grid[i].biome = RimWorld.BiomeDefOf.TemperateForest;
                            grid[i].hilliness = Hilliness.Impassable;
                            grid[i].elevation = Rand.Range(100, 300);

                            Find.WorldFloodFiller.FloodFill(i, (int tile) => true, delegate (int tile, int dist)
                            {
                                if (dist >= coastalVolcanoDistance)
                                {
                                    return;
                                }
                                if (Rand.RangeInclusive(3, 6) - dist >= 1)
                                {
                                    Tile neighbourTile = Find.WorldGrid.tiles[tile];
                                    if (neighbourTile.biome == RimWorld.BiomeDefOf.Ocean)
                                    {
                                        neighbourTile.biome = RimWorld.BiomeDefOf.TemperateForest;
                                        neighbourTile.elevation = grid[i].elevation - (dist * 10);
                                        neighbourTile.hilliness = Rand.RangeInclusive(1, 3) - dist >= 0 ? Hilliness.Mountainous : Rand.RangeInclusive(3, 6) - dist >= 1 ? Hilliness.LargeHills : Rand.RangeInclusive(3, 9) - dist >= 1 ? Hilliness.SmallHills : Hilliness.Flat;
                                    }
                                }
                            });
                        }
                    }
                }

            }
        }
    }
}

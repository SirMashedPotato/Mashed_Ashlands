using Verse;
using RimWorld.Planet;
using RimWorld;

namespace Mashed_Ashlands
{
    public abstract class WorldGenStep_Volcano : WorldGenStep
    {
        private const int coastalVolcanoDistance = 6;

        public void GenerateVolcanos(PlanetLayer layer, WorldObjectDef volcanoDef, float initialMaxNum)
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
            for (int i = 0; i < layer.TilesCount; i++)
            {
                if (numGenerated >= maxNumber)
                {
                    return;
                }

                bool validTile = false;

                if (layer[i].hilliness == Hilliness.Impassable && !Find.WorldObjects.AnyWorldObjectAt(i))
                {
                    if (layer[i].PrimaryBiome != RimWorld.BiomeDefOf.IceSheet && layer[i].PrimaryBiome != RimWorld.BiomeDefOf.SeaIce)
                    {
                        validTile = true;
                    }
                }

                else
                {
                    if (Mashed_Ashlands_ModSettings.EnableCoastalVolcano)
                    {
                        if (layer[i].PrimaryBiome == RimWorld.BiomeDefOf.Ocean)
                        {
                            layer.Filler.FloodFill(i, (PlanetTile tile) => true, delegate (PlanetTile tile, int dist)
                            {
                                if (dist < coastalVolcanoDistance)
                                {
                                    if (!layer[tile].WaterCovered)
                                    {
                                        validTile = false;
                                        return;
                                    }
                                }
                                if (dist == coastalVolcanoDistance + 1)
                                {
                                    if (!layer[tile].WaterCovered)
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
                        if (layer[i].PrimaryBiome == RimWorld.BiomeDefOf.Ocean)
                        {
                            layer[i].PrimaryBiome = RimWorld.BiomeDefOf.TemperateForest;
                            layer[i].hilliness = Hilliness.Impassable;
                            layer[i].elevation = Rand.Range(100, 300);

                            layer.Filler.FloodFill(i, (PlanetTile tile) => true, delegate (PlanetTile tile, int dist)
                            {
                                if (dist >= coastalVolcanoDistance)
                                {
                                    return;
                                }
                                if (Rand.RangeInclusive(3, 6) - dist >= 1)
                                {
                                    Tile neighbourTile = layer[tile];
                                    if (neighbourTile.PrimaryBiome == RimWorld.BiomeDefOf.Ocean)
                                    {
                                        neighbourTile.PrimaryBiome = RimWorld.BiomeDefOf.TemperateForest;
                                        neighbourTile.elevation = layer[i].elevation - (dist * 10);
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

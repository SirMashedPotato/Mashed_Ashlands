using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;
using Verse.Noise;

namespace Mashed_Ashlands
{
    public abstract class AshlandBiomeWorker : BiomeWorker
    {
        /// <summary>
        /// Ensure biomes only spawn my way, not the vanilla way 
        /// </summary>
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile)
        {
            return -100;
        }

        public override bool CanPlaceOnLayer(BiomeDef biome, PlanetLayer layer)
        {
            return layer.Def == PlanetLayerDefOf.Surface;
        }

        public abstract float GetScore_Main(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject = null);

        /// <summary>
        /// Used for all Base type biomes
        /// </summary>
        public float BaseBiomeWorker(BiomeDef biome, Tile tile, PlanetTile planetTile, WorldObject sourceObject)
        {
            int maxDistance = WorldGenUtility.BiomeMaxDistanceForWorld();
            float distanceToSourceObject = WorldGenUtility.DistanceToWorldObject(planetTile, sourceObject.Tile);
            if (distanceToSourceObject > maxDistance)
            {
                return 0;
            }

            if (!Mashed_Ashlands_ModSettings.EnableLegacyRegions)
            {
                Perlin perlin = new Perlin(0.1, 2, 0.5, 6, 793900035, QualityMode.Medium);
                float perlinValue = perlin.GetValue(Find.WorldGrid.GetTileCenter(planetTile));
                int extra = 0;

                if (distanceToSourceObject > maxDistance / 2)
                {
                    List<PlanetTile> neighbourTiles = new List<PlanetTile>();
                    Find.WorldGrid.GetTileNeighbors(planetTile, neighbourTiles);
                    foreach (PlanetTile neighbourID in neighbourTiles)
                    {
                        Tile neighbourTile = planetTile.Layer.Tiles[neighbourID];
                        if (neighbourTile != null && neighbourTile.PrimaryBiome == biome)
                        {
                            extra++;
                        }
                    }
                    if (distanceToSourceObject >= maxDistance - 2)
                    {
                        extra -= Rand.RangeInclusive(3, 6);
                    }
                }
                else
                {
                    extra = 6;
                }

                return (((extra - Rand.RangeInclusive(0, 3) + (perlinValue + 1) * 7) * maxDistance) + maxDistance) / distanceToSourceObject;
            }
            return Rand.Range(8, 16) * maxDistance / distanceToSourceObject;
        }

        /// <summary>
        /// Used for all Extra type biomes, these use perlin to generate
        /// </summary>
        public float ExtraBiomeWorker(BiomeDef biome, Tile tile, PlanetTile planetTile, int perlinSeed = 35, float perlinCulling = 0.75f)
        {
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }

            Perlin perlin = new Perlin(0.1, 10, 0.6, 12, perlinSeed, QualityMode.Low);
            float perlinValue = perlin.GetValue(Find.WorldGrid.GetTileCenter(planetTile));

            if (perlinValue <= perlinCulling)
            {
                return 0f;
            }

            return 16;
        }

        /// <summary>
        /// Used for all Arid type biomes
        /// </summary>
        public float AridBiomeWorker(BiomeDef biome, Tile tile, PlanetTile planetTile)
        {
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }
            if (tile.rainfall > 250f)
            {
                return 0f;
            }
            return 15 + (tile.rainfall / 50);
        }

        /// <summary>
        /// Used for all Grassland type biomes
        /// </summary>
        public float GrasslandBiomeWorker(BiomeDef biome, Tile tile, PlanetTile planetTile)
        {
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }
            if (tile.swampiness > 0.2f)
            {
                return 0f;
            }
            if (tile.temperature < 0f)
            {
                return 0f;
            }
            if (tile.rainfall < 300f || tile.rainfall >= 1500f)
            {
                return 0f;
            }
            return 13 + (tile.rainfall / 100) + (tile.temperature / 100);
        }

        /// <summary>
        /// Used for all Swamp type biomes
        /// </summary>
        public float SwampBiomeWorker(BiomeDef biome, Tile tile, PlanetTile planetTile)
        {
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }
            if (tile.temperature < 15f)
            {
                return 0f;
            }
            if (tile.rainfall < 1500f)
            {
                return 0f;
            }
            return 13 + (tile.swampiness * 15);
        }

        /// <summary>
        /// Used for all Mountain type biomes
        /// </summary>
        public float MountainBiomeWorker(BiomeDef biome, Tile tile, PlanetTile planetTilee)
        {
            if (tile.hilliness == Hilliness.Flat || tile.hilliness == Hilliness.SmallHills)
            {
                return 0f;
            }
            return 13 + (tile.elevation / 300);
        }

        /// <summary>
        /// Used for all Jungle type biomes
        /// </summary>
        public float JungleBiomeWorker(BiomeDef biome, Tile tile, PlanetTile planetTile)
        {
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }
            if (tile.temperature < 15f)
            {
                return 0f;
            }
            if (tile.rainfall < 2000f)
            {
                return 0f;
            }
            return 13 + (tile.rainfall / 300);
        }

        /// <summary>
        /// Used for all Coast type biomes
        /// </summary>
        public float CoastBiomeWorker(BiomeDef biome, Tile tile, PlanetTile planetTile, BiomeDef extraBiomeDef)
        {
            int numberCoastalTiles = 0;
            List<PlanetTile> neighbourTiles = new List<PlanetTile>();
            Find.WorldGrid.GetTileNeighbors(planetTile, neighbourTiles);
            foreach (PlanetTile neighbourID in neighbourTiles)
            {
                Tile neighbourTile = planetTile.Layer.Tiles[neighbourID];
                if (neighbourTile != null)
                {
                    if (neighbourTile.WaterCovered || neighbourTile.PrimaryBiome == extraBiomeDef)
                    {
                        numberCoastalTiles++;
                    }
                }
            }
            if (numberCoastalTiles < 2)
            {
                return 0;
            }
            return Rand.Range(12, 18) + numberCoastalTiles;
        }
    }
}

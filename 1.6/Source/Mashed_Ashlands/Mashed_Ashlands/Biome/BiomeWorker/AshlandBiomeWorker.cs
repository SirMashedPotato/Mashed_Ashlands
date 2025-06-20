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
        public override float GetScore(Tile tile, int tileID)
        {
            return -100;
        }

        public abstract float GetScore_Main(Tile tile, int tileID, WorldObject sourceObject = null);

        /// <summary>
        /// Used for all Base type biomes
        /// </summary>
        public float BaseBiomeWorker(int tileID, WorldObject sourceObject, BiomeDef biomeDef)
        {
            int maxDistance = WorldGenUtility.BiomeMaxDistanceForWorld();
            float distanceToSourceObject = WorldGenUtility.DistanceToWorldObject(tileID, sourceObject.Tile);
            if (distanceToSourceObject > maxDistance)
            {
                return 0;
            }

            if (!Mashed_Ashlands_ModSettings.EnableLegacyRegions)
            {
                Perlin perlin = new Perlin(0.1, 2, 0.5, 6, 793900035, QualityMode.Medium);
                float perlinValue = perlin.GetValue(Find.WorldGrid.GetTileCenter(tileID));
                int extra = 0;

                if (distanceToSourceObject > maxDistance / 2)
                {
                    List<int> neighbourTiles = new List<int>();
                    Find.WorldGrid.GetTileNeighbors(tileID, neighbourTiles);
                    foreach (int neighbourID in neighbourTiles)
                    {
                        Tile neighbourTile = Find.WorldGrid.tiles[neighbourID];
                        if (neighbourTile != null && neighbourTile.biome == biomeDef)
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
        /// Used for all Coast type biomes
        /// </summary>
        public float CoastBiomeWorker(int tileID, BiomeDef extraBiomeDef)
        {
            int numberCoastalTiles = 0;
            List<int> neighbourTiles = new List<int>();
            Find.WorldGrid.GetTileNeighbors(tileID, neighbourTiles);
            foreach (int neighbourID in neighbourTiles)
            {
                Tile neighbourTile = Find.WorldGrid.tiles[neighbourID];
                if (neighbourTile != null)
                {
                    if (neighbourTile.WaterCovered || neighbourTile.biome == extraBiomeDef)
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

        /// <summary>
        /// Used for all Island type biomes
        /// </summary>
        public float IslandBiomeWorker(int tileID, WorldObjectDef requiredVolcanoDef, BiomeDef biomeDef)
        {
            int maxDistance = Mashed_Ashlands_ModSettings.BiomesMaxDistance;
            if (Mashed_Ashlands_ModSettings.BiomeScaleWithWorldSize)
            {
                maxDistance = (int)(maxDistance * ((Find.World.PlanetCoverage * 3) + 0.1f));
                if (maxDistance < 10)
                {
                    maxDistance = 10;
                }
            }

            float distanceToClosestVolcano = WorldGenUtility.DistanceToClosestWorldObject(tileID, requiredVolcanoDef);
            if (distanceToClosestVolcano > maxDistance || distanceToClosestVolcano == -1)
            {
                return 0;
            }
            List<int> neighbourTiles = new List<int>();
            Find.WorldGrid.GetTileNeighbors(tileID, neighbourTiles);
            foreach (int neighbourID in neighbourTiles)
            {
                Tile neighbourTile = Find.WorldGrid.tiles[neighbourID];
                if (neighbourTile != null)
                {
                    if (!neighbourTile.WaterCovered && neighbourTile.biome != biomeDef)
                    {
                        return 0;
                    }
                }
            }
            return Rand.Range(2, 8) * maxDistance / distanceToClosestVolcano;
        }

        /// <summary>
        /// Used for all Extra type biomes
        /// </summary>
        public float ExtraBiomeWorker(Tile tile, int tileID, int perlinSeed = 35, float perlinCulling = 0.75f)
        {
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }

            Perlin perlin = new Perlin(0.1, 10, 0.6, 12, perlinSeed, QualityMode.Low);
            float perlinValue = perlin.GetValue(Find.WorldGrid.GetTileCenter(tileID));

            if (perlinValue <= perlinCulling)
            {
                return 0f;
            }

            return 16;
        }

        /// <summary>
        /// Used for all Arid type biomes
        /// </summary>
        public float AridBiomeWorker(Tile tile)
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
        public float GrasslandBiomeWorker(Tile tile)
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
        public float SwampBiomeWorker(Tile tile)
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
        public float MountainBiomeWorker(Tile tile)
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
        public float JungleBiomeWorker(Tile tile)
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
    }
}

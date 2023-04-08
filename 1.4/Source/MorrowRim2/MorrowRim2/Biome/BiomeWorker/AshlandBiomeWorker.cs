using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    public abstract class AshlandBiomeWorker : BiomeWorker
    {
        public abstract float GetScore_Main(Tile tile, int tileID);

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
        public float IslandBiomeWorker(int tileID, WorldObjectDef requiredVolcanoDef)
        {
            int maxDistance = MorrowRim_ModSettings.BiomesMaxDistance;
            if (MorrowRim_ModSettings.BiomeScaleWithWorldSize)
            {
                maxDistance = (int)(maxDistance * ((Find.World.PlanetCoverage * 3) + 0.1f));
                if (maxDistance < 10)
                {
                    maxDistance = 10;
                }
            }

            float distanceToClosestVolcano = BiomeWorkerUtility.DistanceToClosestVolcano(tileID, requiredVolcanoDef);
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
                    if (!neighbourTile.WaterCovered)
                    {
                        return 0;
                    }
                }
            }
            return Rand.Range(2, 8) * maxDistance / distanceToClosestVolcano;
        }

        /// <summary>
        /// Used for all Base type biomes
        /// </summary>
        public float BaseBiomeWorker(int tileID, WorldObjectDef requiredVolcanoDef)
        {
            int maxDistance = MorrowRim_ModSettings.BiomesMaxDistance;
            if (MorrowRim_ModSettings.BiomeScaleWithWorldSize)
            {
                maxDistance = (int)(maxDistance * ((Find.World.PlanetCoverage * 3) + 0.1f));
                if (maxDistance < 10)
                {
                    maxDistance = 10;
                }
            }

            float distanceToClosestVolcano = BiomeWorkerUtility.DistanceToClosestVolcano(tileID, requiredVolcanoDef);
            if (distanceToClosestVolcano > maxDistance || distanceToClosestVolcano == -1)
            {
                return 0;
            }
           
            return Rand.Range(8, 16) * maxDistance / distanceToClosestVolcano;
        }
    }
}

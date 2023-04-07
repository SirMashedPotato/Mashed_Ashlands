using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    public class BiomeWorker_CoralCoastAshlands : AshlandBiomeWorker
    {
        /// <summary>
        /// Only here to prevent gen through standard methods
        /// Possibly add in alternative gen, with setting to disable volcano based gen
        /// </summary>
        public override float GetScore(Tile tile, int tileID)
        {
            if (MorrowRim_ModSettings.OldBiomeGen)
            {

            }

            return 0;
        }

        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!MorrowRim_ModSettings.EnableCoralCoastAshlands)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            if (tile.temperature < 0f)
            {
                return 0f;
            }
            float distanceToClosestVolcano = BiomeWorkerUtility.DistanceToClosestVolcano(tileID, WorldObjectDefOf.MorrowRim_VolcanoDormant);
            if (distanceToClosestVolcano > MorrowRim_ModSettings.BiomesMaxDistance || distanceToClosestVolcano == -1)
            {
                return 0;
            }
            int numberCoastalTiles = 0;
            List<int> neighbourTiles = new List<int>();
            Find.WorldGrid.GetTileNeighbors(tileID, neighbourTiles);
            foreach (int neighbourID in neighbourTiles)
            {
                Tile neighbourTile = Find.WorldGrid.tiles[neighbourID];
                if (neighbourTile != null)
                {
                    if (neighbourTile.WaterCovered && Rand.Chance(0.8f))
                    {
                        numberCoastalTiles++;
                    }
                    if (neighbourTile.biome != null && neighbourTile.biome == BiomeDefOf.MorrowRim_CoralCoastAshlands && Rand.Bool)
                    {
                        numberCoastalTiles++;
                    }
                }
            }
            if (numberCoastalTiles == 0)
            {
                return 0;
            }
            return (Rand.Range(6, 10) + numberCoastalTiles) * (MorrowRim_ModSettings.BiomesMaxDistance / 2) / distanceToClosestVolcano;
        }
    }
}

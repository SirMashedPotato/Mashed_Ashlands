﻿using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    public class BiomeWorker_CragIslandAshlands : AshlandBiomeWorker
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
            if (!MorrowRim_ModSettings.EnableCragIslandAshlands)
            {
                return -100f;
            }
            if (!tile.WaterCovered)
            {
                return -100f;
            }
            float distanceToClosestVolcano = BiomeWorkerUtility.DistanceToClosestVolcano(tileID, new List<WorldObjectDef> { WorldObjectDefOf.MorrowRim_VolcanoDormant, WorldObjectDefOf.MorrowRim_VolcanoExtinct });
            if (distanceToClosestVolcano > MorrowRim_ModSettings.BiomesMaxDistance || distanceToClosestVolcano == -1)
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
            return Rand.Range(2, 8) * (MorrowRim_ModSettings.BiomesMaxDistance / 2) / distanceToClosestVolcano;
        }
    }
}
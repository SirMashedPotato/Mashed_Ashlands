﻿using Verse;
using RimWorld.Planet;
using RimWorld;

namespace MorrowRim2
{
    public abstract class WorldGenStep_Volcano : WorldGenStep
    {
        public void GenerateVolcanos(WorldObjectDef volcanoDef, int maxNumber)
        {
            int numGenerated = 0;
            WorldGrid grid = Find.WorldGrid;
            for (int i = 0; i < grid.TilesCount; i++)
            {
                if (numGenerated >= maxNumber)
                {
                    return;
                }
                if (grid[i].hilliness == Hilliness.Impassable)
                {
                    if (grid[i].biome != RimWorld.BiomeDefOf.IceSheet && grid[i].biome != RimWorld.BiomeDefOf.SeaIce)
                    {
                        float distanceToClosestVolcano = WorldGenUtility.DistanceToClosestVolcano(i);
                        if (distanceToClosestVolcano >= MorrowRim_ModSettings.VolcanoMinDistance)
                        {
                            WorldObject volcano = WorldObjectMaker.MakeWorldObject(volcanoDef);
                            volcano.Tile = i;
                            Find.WorldObjects.Add(volcano);
                            numGenerated++;
                        }
                    }
                }
            }
        }
    }
}
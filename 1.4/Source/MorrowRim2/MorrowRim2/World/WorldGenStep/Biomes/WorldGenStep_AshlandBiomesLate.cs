﻿using Verse;
using RimWorld.Planet;

namespace MorrowRim2
{
    public class WorldGenStep_AshlandBiomesLate : WorldGenStep_AshlandBiomes
    {
        public override int SeedPart => 48151623;

        public override void GenerateFresh(string seed)
        {
            if (!MorrowRim_ModSettings.OldBiomeGen)
            {
                WorldGrid grid = Find.WorldGrid;
                for (int i = 0; i < grid.TilesCount; i++)
                {
                    if (!grid[i].WaterCovered && OnStartupUtility.baseAshlandBiomeDefs.Contains(grid[i].biome))
                    {
                        grid[i].biome = AshlandBiomeFrom(grid[i], i, OnStartupUtility.lateAshlandBiomeDefs);
                    }
                }
            }
        }
    }
}
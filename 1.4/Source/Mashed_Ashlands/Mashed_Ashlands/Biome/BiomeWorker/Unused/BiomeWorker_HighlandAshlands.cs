﻿using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_HighlandAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableHighlandAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_Ashlands && tile.biome != BiomeDefOf.Mashed_Ashlands_ForestAshlands)
            {
                return -100f;
            }
            if (tile.hilliness == Hilliness.Flat)
            {
                return 0f;
            }
            if (tile.temperature > 10f)
            {
                return 0f;
            }
            return 15 + (tile.elevation / 100);
        }
    }
}
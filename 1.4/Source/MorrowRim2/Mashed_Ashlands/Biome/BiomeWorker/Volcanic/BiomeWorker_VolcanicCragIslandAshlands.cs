﻿using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_VolcanicCragIslandAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableVolcanicCragIslandAshlands)
            {
                return -100f;
            }
            if (!tile.WaterCovered)
            {
                return -100f;
            }
            return IslandBiomeWorker(tileID, WorldObjectDefOf.Mashed_Ashlands_VolcanoActive, BiomeDefOf.Mashed_Ashlands_VolcanicCragIslandAshlands);
        }
    }
}
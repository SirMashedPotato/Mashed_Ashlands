﻿using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_CragIslandAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableCragIslandAshlands)
            {
                return -100f;
            }
            if (!tile.WaterCovered)
            {
                return -100f;
            }
            return IslandBiomeWorker(tileID, WorldObjectDefOf.Mashed_Ashlands_VolcanoDormant, BiomeDefOf.Mashed_Ashlands_CragIslandAshlands);
        }
    }
}
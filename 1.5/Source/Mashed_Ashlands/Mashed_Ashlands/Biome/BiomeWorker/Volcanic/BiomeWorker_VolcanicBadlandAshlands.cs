﻿using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_VolcanicBadlandAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID, WorldObject sourceObject = null)
        {
            if (!Mashed_Ashlands_ModSettings.EnableVolcanicBadlandsAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.Mashed_Ashlands_VolcanicAshlands)
            {
                return -100f;
            }

            return AridBiomeWorker(tile);
        }
    }
}

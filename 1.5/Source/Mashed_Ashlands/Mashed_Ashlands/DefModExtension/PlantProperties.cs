﻿using Verse;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class PlantProperties : DefModExtension
    {
        public bool ashlandFlowerPlant = false;
        public float cavePlantCommonality = 0.5f;

        public ThingDef secondaryDrop = null;
        public IntRange secondaryDropAmountRange;
        public float secondaryDropChance = 1f;
        public bool secondaryNotWhenLeafless = false;

        public List<TerrainDef> allowedTerrainForWild = new List<TerrainDef>();
        public List<TerrainDef> disallowedTerrainForWild = new List<TerrainDef>();

        public bool requireWaterForWild = false;
        public int minTilesToWaterForWild = 3;

        //currently don't do anything
        public bool growthBoostDuringAsh = false;
        public float growthBoostDuringAshDegree = 0.1f;
        public static PlantProperties Get(Def def)
        {
            return def.GetModExtension<PlantProperties>();
        }
    }
}

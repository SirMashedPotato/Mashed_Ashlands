using Verse;
using System.Collections.Generic;

namespace MorrowRim2
{
    class PlantProperties : DefModExtension
    {
        public ThingDef secondaryDrop;
        public IntRange secondaryDropAmountRange;
        public float secondaryDropChance = 1f;

        public List<TerrainDef> allowedTerrainForWild = new List<TerrainDef>();
        public List<TerrainDef> disallowedTerrainForWild = new List<TerrainDef>();
        public List<TerrainAffordanceDef> terrainAffordancesToSow = new List<TerrainAffordanceDef>();

        public bool growthBoostDuringAsh = false;
        public float growthBoostDuringAshDegree = 0.1f;
        public static PlantProperties Get(Def def)
        {
            return def.GetModExtension<PlantProperties>();
        }
    }
}

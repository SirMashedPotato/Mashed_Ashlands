using Verse;
using System.Collections.Generic;

namespace MorrowRim2
{
    class PlantProperties : DefModExtension
    {
        public List<TerrainDef> allowedTerrain = new List<TerrainDef>();
        public List<TerrainDef> disallowedTerrain = new List<TerrainDef>();

        public List<TerrainAffordanceDef> terrainAffordancesToSow = new List<TerrainAffordanceDef>();

        public bool growthBoostDuringAsh = false;
        public float growthBoostDuringAshDegree = 0.1f;
        public static PlantProperties Get(Def def)
        {
            return def.GetModExtension<PlantProperties>();
        }
    }
}

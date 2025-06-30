using System;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class PlantProperties : DefModExtension
    {
        public bool ashlandFlowerPlant = false;
        [Obsolete]
        public float cavePlantCommonality = 0.5f; //todo???

        public ThingDef secondaryDrop = null;
        public IntRange secondaryDropAmountRange;
        public float secondaryDropChance = 1f;
        public bool secondaryNotWhenLeafless = false;

        [NoTranslate]
        public List<TerrainDef> allowedTerrainDefsForWild = new List<TerrainDef>();
        [NoTranslate]
        public List<TerrainDef> disallowedTerrainDefsForWild = new List<TerrainDef>();
        public bool requireWaterForWild = false;
        public int minTilesToWaterForWild = 3;

        private readonly HashSet<TerrainDef> allowedTerrainDefsForWildSet = new HashSet<TerrainDef>();
        private readonly HashSet<TerrainDef> disallowedTerrainDefsForWildSet = new HashSet<TerrainDef>();

        public static PlantProperties Get(Def planetDef) => planetDef.GetModExtension<PlantProperties>();

        private HashSet<TerrainDef> AllowedTerrainDefsForWildSet
        {
            get
            {
                if (allowedTerrainDefsForWildSet.NullOrEmpty())
                {
                    foreach(TerrainDef def in allowedTerrainDefsForWild)
                    {
                        allowedTerrainDefsForWildSet.Add(def);
                    }
                }
                return allowedTerrainDefsForWildSet;
            }
        }

        private HashSet<TerrainDef> DisallowedTerrainDefsForWildSet
        {
            get
            {
                if (disallowedTerrainDefsForWildSet.NullOrEmpty())
                {
                    foreach (TerrainDef def in disallowedTerrainDefsForWild)
                    {
                        disallowedTerrainDefsForWildSet.Add(def);
                    }
                }
                return disallowedTerrainDefsForWildSet;
            }
        }

        public bool WildPlantSpawnChecker(Map map, IntVec3 c)
        {
            if (!requireWaterForWild && allowedTerrainDefsForWild.NullOrEmpty() && disallowedTerrainDefsForWild.NullOrEmpty())
            {
                return true;
            }

            if (!allowedTerrainDefsForWild.NullOrEmpty())
            {
                if (!AllowedTerrainDefsForWildSet.Contains(c.GetTerrain(map)))
                {
                    return false;
                }
            }

            if (!disallowedTerrainDefsForWild.NullOrEmpty())
            {
                if (DisallowedTerrainDefsForWildSet.Contains(c.GetTerrain(map)))
                {
                    return false;
                }
            }

            if (requireWaterForWild)
            {
                bool waterFlag = false;
                foreach (IntVec3 neighbour in GenAdj.CellsAdjacent8Way(c, Rot4.North, new IntVec2(minTilesToWaterForWild, minTilesToWaterForWild)))
                {
                    if (neighbour.InBounds(map))
                    {
                        TerrainDef neighbourTerrain = neighbour.GetTerrain(map);
                        if (neighbourTerrain != null && neighbourTerrain.IsWater)
                        {
                            waterFlag = true;
                            break;
                        }
                    }
                }
                return waterFlag;
            }

            return true;
        }
    }
}


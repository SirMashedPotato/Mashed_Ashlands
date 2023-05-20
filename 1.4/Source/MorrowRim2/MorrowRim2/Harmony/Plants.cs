using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    /// <summary>
    /// Prefixes allows for custom cave plants for specific biomes.
    /// Postfix forces wild plants to spawn on specific terrain, and prevents them from spawning on specific terrain.
    /// </summary>
    [HarmonyPatch(typeof(WildPlantSpawner))]
    [HarmonyPatch("CalculatePlantsWhichCanGrowAt")]
    public static class WildPlantSpawner_CalculatePlantsWhichCanGrowAt_Patch
    {
        [HarmonyPrefix]
        public static bool MorrowRim_CustomCavePlants_Patch(IntVec3 c, bool cavePlants, List<ThingDef> outPlants, Map ___map)
        {
            if (cavePlants && OnStartupUtility.ashlandCavePlantsBiomes.Contains(___map.Biome))
            {
                outPlants.Clear();
                for (int i = 0; i < OnStartupUtility.ashlandCavePlants.Count; i++)
                {
                    if (OnStartupUtility.ashlandCavePlants[i].CanEverPlantAt(c, ___map, false))
                    {
                        outPlants.Add(OnStartupUtility.ashlandCavePlants[i]);
                    }
                }
                return false;
            }
            return true;
        }

        [HarmonyPostfix]
        public static void MorrowRim_CalculatePlantsWhichCanGrowAt_Patch(IntVec3 c, bool cavePlants, List<ThingDef> outPlants, Map ___map)
        {
            if (!cavePlants && !outPlants.NullOrEmpty() && OnStartupUtility.restrictedTerrainPlantsBiomes.Contains(___map.Biome))
            {
                List<ThingDef> PlantsToRemove = new List<ThingDef>();
                foreach (ThingDef plant in outPlants)
                {
                    PlantProperties props = PlantProperties.Get(plant);
                    if (props != null)
                    {
                        TerrainDef terrainDef = c.GetTerrain(___map);
                        if ((!props.allowedTerrainForWild.NullOrEmpty() && !props.allowedTerrainForWild.Contains(terrainDef))
                            || !props.disallowedTerrainForWild.NullOrEmpty() && props.disallowedTerrainForWild.Contains(terrainDef))
                        {
                            PlantsToRemove.Add(plant);
                        }
                        else
                        {
                            if (props.requireWaterForWild)
                            {
                                bool waterFlag = false;
                                foreach (IntVec3 neighbour in GenAdj.CellsAdjacent8Way(c, Rot4.North, new IntVec2(props.minTilesToWaterForWild, props.minTilesToWaterForWild)))
                                {
                                    if (neighbour.InBounds(___map))
                                    {
                                        TerrainDef neighbourTerrain = neighbour.GetTerrain(___map);
                                        if (neighbourTerrain != null && neighbourTerrain.IsWater)
                                        {
                                            waterFlag = true;
                                            break;
                                        }
                                    }
                                }
                                if (!waterFlag)
                                {
                                    PlantsToRemove.Add(plant);
                                }
                            }
                        }
                    }
                }
                foreach (ThingDef plant in PlantsToRemove)
                {
                    outPlants.Remove(plant);
                }
                PlantsToRemove.Clear();
            }
        }
    }

    /// <summary>
    /// Increases the weight of ashland cave plants in ashland biomes, specifically for cave tiles
    /// </summary>
    [HarmonyPatch(typeof(WildPlantSpawner))]
    [HarmonyPatch("PlantChoiceWeight")]
    public static class WildPlantSpawner_PlantChoiceWeight_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_PlantChoiceWeight_Patch(ThingDef plantDef, IntVec3 c, ref float __result, Map ___map)
        {
            BiomeProperties biomeProps = BiomeProperties.Get(___map.Biome);
            if (biomeProps != null && biomeProps.useAshlandCavePlants)
            {
                RoofDef roof = c.GetRoof(___map);
                if (roof != null && roof.isNatural)
                {
                    {
                        PlantProperties plantProps = PlantProperties.Get(plantDef);
                        if (plantProps != null && plantProps.ashlandCavePlant)
                        {
                            __result = plantProps.cavePlantCommonality;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Forces specific plants to only be sowable on specific terrain
    /// This one prevents unsowable plants from being sown
    /// </summary>
    [HarmonyPatch(typeof(PlantUtility))]
    [HarmonyPatch("CanNowPlantAt")]
    public static class PlantUtility_CanNowPlantAt_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_CanEverPlantAt_Patch(ThingDef plantDef, IntVec3 c, Map map, ref bool __result)
        {
            if (__result && MorrowRim_ModSettings.TheAshlands_OnlySowOnAsh)
            {
                PlantProperties props = PlantProperties.Get(plantDef);
                if (props != null && !props.terrainAffordancesToSow.NullOrEmpty())
                {
                    TerrainDef terrainDef = c.GetTerrain(map);
                    if (!terrainDef.affordances.NullOrEmpty())
                    {
                        foreach (TerrainAffordanceDef affordanceDef in props.terrainAffordancesToSow)
                        {
                            if (terrainDef.affordances.Contains(affordanceDef))
                            {
                                return;
                            }
                        }
                        __result = false;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Forces specific plants to only be sowable on specific terrain
    /// This one prevents unsowable plants from showing up as an option
    /// </summary>
    [HarmonyPatch(typeof(PlantUtility))]
    [HarmonyPatch("CanSowOnGrower")]
    public static class PlantUtility_CanSowOnGrower_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_CanSowOnGrower_Patch(ThingDef plantDef, object obj, ref bool __result)
        {
            if (__result && MorrowRim_ModSettings.TheAshlands_OnlySowOnAsh)
            {
                PlantProperties props = PlantProperties.Get(plantDef);
                if (props != null && !props.terrainAffordancesToSow.NullOrEmpty())
                {
                    if (obj is IPlantToGrowSettable settable)
                    {
                        using (IEnumerator<IntVec3> enumerator = settable.Cells.GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                foreach (TerrainAffordanceDef affordanceDef in props.terrainAffordancesToSow)
                                {
                                    if (enumerator.Current.GetTerrain(settable.Map).affordances.Contains(affordanceDef))
                                    {
                                        return;
                                    }
                                }
                            }
                            __result = false;
                        }
                    }
                }
            }
        }
    }
}

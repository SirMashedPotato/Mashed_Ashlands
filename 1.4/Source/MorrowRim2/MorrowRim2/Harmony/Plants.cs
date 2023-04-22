using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    /// <summary>
    /// Reduces the fertilty loss caused by pollution for specific biomes
    /// It makes the polluted regions of the map look less like a wasteland
    /// ~0.1ms tick impact
    /// </summary>
    [HarmonyPatch(typeof(FertilityGrid))]
    [HarmonyPatch("CalculateFertilityAt")]
    public static class FertilityGrid_CalculateFertilityAt_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_CalculateFertilityAt_Patch(IntVec3 loc, ref float __result, Map ___map)
        {
            if (ModsConfig.BiotechActive)
            {
                if (loc.IsPolluted(___map))
                {
                    BiomeProperties props = BiomeProperties.Get(___map.Biome);
                    if (props != null && props.ignorePollutionForPlantCommonality)
                    {
                        __result = loc.GetTerrain(___map).fertility * 0.8f;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Forces wild plants to spawn on specific terrain, and prevents them from spawning on specific terrain.
    /// </summary>
    [HarmonyPatch(typeof(WildPlantSpawner))]
    [HarmonyPatch("CalculatePlantsWhichCanGrowAt")]
    public static class WildPlantSpawner_CalculatePlantsWhichCanGrowAt_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_CalculatePlantsWhichCanGrowAt_Patch(IntVec3 c, List<ThingDef> outPlants, Map ___map)
        {
            if (!outPlants.NullOrEmpty())
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
    /// Forces specific plants to only be sowable on specific terrain
    /// </summary>
    [HarmonyPatch(typeof(PlantUtility))]
    [HarmonyPatch("CanNowPlantAt")]
    public static class PlantUtility_CanNowPlantAt_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_CanEverPlantAt_Patch(ThingDef plantDef, IntVec3 c, Map map, ref bool __result)
        {
            if (__result)
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
}

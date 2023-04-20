using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
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

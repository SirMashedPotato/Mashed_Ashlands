using HarmonyLib;
using Verse;
using RimWorld;
using System.Collections.Generic;

namespace MorrowRim2
{
    /// <summary>
    /// Forces plants to spawn on specific terrain, and prevents them from spawning on specific terrain.
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
    /// Replaces terrain with different terrain.
    /// </summary>
    [HarmonyPatch(typeof(GenStep_Terrain))]
    [HarmonyPatch("TerrainFrom")]
    public static class GenStep_Terrain_TerrainFrom_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_TerrainFrom_Patch(Map map, ref TerrainDef __result)
        {
            BiomeProperties props = BiomeProperties.Get(map.Biome);
            if (props != null && !props.terrainReplacers.NullOrEmpty())
            {
                foreach (TerrainReplacer replacer in props.terrainReplacers)
                {
                    if (replacer.originalTerrain == __result)
                    {
                        __result = replacer.replacedTerrain;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Replaces terrain with different terrain.
    /// </summary>
    [HarmonyPatch(typeof(CompTerrainPumpDry))]
    [HarmonyPatch("GetTerrainToDryTo")]
    public static class GetTerrainToDryTo_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_GetTerrainToDryTo_Patch(Map map, TerrainDef terrainDef, ref TerrainDef __result)
        {
            BiomeProperties props = BiomeProperties.Get(map.Biome);
            if (props != null && !props.dryToReplacers.NullOrEmpty())
            {
                foreach (TerrainReplacer replacer in props.dryToReplacers)
                {
                    if (replacer.originalTerrain == terrainDef.driesTo)
                    {
                        __result = replacer.replacedTerrain;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Replaces road terrain with different terrain.
    /// </summary>
    [HarmonyPatch(typeof(RoadDefGenStep_Place))]
    [HarmonyPatch("Place")]
    public static class RoadDefGenStep_Place_Place_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_RoadDefGenStep_Place_Patch(Map map, IntVec3 position)
        {
            BiomeProperties props = BiomeProperties.Get(map.Biome);
            if (props != null && !props.roadReplacers.NullOrEmpty())
            {
                foreach (TerrainReplacer replacer in props.roadReplacers)
                {
                    if (replacer.originalTerrain == position.GetTerrain(map))
                    {
                        map.terrainGrid.SetTerrain(position, replacer.replacedTerrain);
                    }
                }
            }
        }
    }
}

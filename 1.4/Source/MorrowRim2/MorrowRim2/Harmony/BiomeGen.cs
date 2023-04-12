using HarmonyLib;
using Verse;
using RimWorld;
using System.Collections.Generic;

namespace MorrowRim2
{
    public static class BiomeGen
    {
        /// <summary>
        /// Forces plants to spawn on specific terrain, and prevents them from spawning on specific terrain.
        /// </summary>
        /* Currently completely fucks map gen, go back to how it was in MorrowRim
        [HarmonyPatch(typeof(WildPlantSpawner))]
        [HarmonyPatch("CalculatePlantsWhichCanGrowAt")]
        public static class WildPlantSpawner_CalculatePlantsWhichCanGrowAt_Patch
        {
            [HarmonyPostfix]
            public static void MorrowRim_CalculatePlantsWhichCanGrowAt_Patch(IntVec3 c, List<ThingDef> outPlants, Map ___map)
            {
                if (!outPlants.NullOrEmpty())
                {
                    for (int i = outPlants.Count - 1; i >= 0; )
                    {
                        PlantProperties props = PlantProperties.Get(outPlants[i]);
                        if (props != null)
                        {
                            TerrainDef terrainDef = c.GetTerrain(___map);
                            if ((!props.allowedTerrain.NullOrEmpty() && !props.allowedTerrain.Contains(terrainDef))
                                || !props.disallowedTerrain.NullOrEmpty() && props.allowedTerrain.Contains(terrainDef))
                            {
                                outPlants.Remove(outPlants[i]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                }
            }
        }
        */
 
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
                    foreach(TerrainReplacer replacer in props.terrainReplacers)
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
    }
}

using HarmonyLib;
using Verse;
using RimWorld;

namespace MorrowRim2
{
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
    /// Replaces the gravel in caves with a custom terrain.
    /// </summary>
    [HarmonyPatch(typeof(GenStep_CavesTerrain))]
    [HarmonyPatch("Generate")]
    public static class GenStep_CavesTerrain_Generate_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_CaveTerrain_Patch(Map map)
        {
            BiomeProperties props = BiomeProperties.Get(map.Biome);
            if (props != null && props.caveGravelReplacer != null)
            {
                MapGenFloatGrid caves = MapGenerator.Caves;
                foreach (IntVec3 intVec in map.AllCells)
                {
                    if (caves[intVec] > 0f && !intVec.GetTerrain(map).IsRiver)
                    {
                        if (map.terrainGrid.TerrainAt(intVec) == TerrainDefOf.Gravel)
                        {
                            map.terrainGrid.SetTerrain(intVec, props.caveGravelReplacer);
                        }
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

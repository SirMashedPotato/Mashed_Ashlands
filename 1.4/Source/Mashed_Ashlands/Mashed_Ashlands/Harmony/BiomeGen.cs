using HarmonyLib;
using Verse;
using RimWorld;
using Verse.Noise;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Replaces terrain with different terrain.
    /// </summary>
    [HarmonyPatch(typeof(GenStep_Terrain))]
    [HarmonyPatch("TerrainFrom")]
    public static class GenStep_Terrain_TerrainFrom_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_TerrainFrom_Patch(Map map, ref TerrainDef __result)
        {
            ///TODO patch only if not enabled possibly
            if (!OnStartupUtility.geologicalLandformsEnabled)
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
    }

    /// <summary>
    /// Replaces terrain with different terrain.
    /// </summary>
    [HarmonyPatch(typeof(CompTerrainPumpDry))]
    [HarmonyPatch("GetTerrainToDryTo")]
    public static class GetTerrainToDryTo_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_GetTerrainToDryTo_Patch(Map map, TerrainDef terrainDef, ref TerrainDef __result)
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
    /// Allows for custom terrain gen
    /// Largely copy pasta of GenStep_CavesTerrain.Generate
    /// </summary>
    [HarmonyPatch(typeof(GenStep_CavesTerrain))]
    [HarmonyPatch("Generate")]
    public static class GenStep_CavesTerrain_Generate_Patch
    {
        [HarmonyPrefix]
        public static bool Mashed_Ashlands_CaveTerrain_Patch(Map map)
        {
            if (Find.World.HasCaves(map.Tile))
            {
                BiomeProperties props = BiomeProperties.Get(map.Biome);
                if (props != null && props.useCustomCaveTerrain)
                {
                    Perlin perlin = new Perlin(0.079999998211860657, 2.0, 0.5, 6, Rand.Int, QualityMode.Medium);
                    Perlin perlin2 = new Perlin(0.15999999642372131, 2.0, 0.5, 6, Rand.Int, QualityMode.Medium);
                    MapGenFloatGrid caves = MapGenerator.Caves;
                    foreach (IntVec3 intVec in map.AllCells)
                    {
                        if (caves[intVec] > 0f && !intVec.GetTerrain(map).IsRiver)
                        {
                            float num = (float)perlin.GetValue(intVec.x, 0.0, intVec.z);
                            float num2 = (float)perlin2.GetValue(intVec.x, 0.0, intVec.z);
                            if (num > props.waterThreshold)
                            {
                                map.terrainGrid.SetTerrain(intVec, props.waterTerrainDef);
                            }
                            else if (num2 > props.otherTerrainThreshold)
                            {
                                map.terrainGrid.SetTerrain(intVec, props.otherTerrainDef);
                            }
                        }
                    }
                    return false;
                }
            }
            return true;
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
        public static void Mashed_Ashlands_RoadDefGenStep_Place_Patch(Map map, IntVec3 position)
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


    /// <summary>
    /// Disables the generation of beaches for specific biomes
    /// </summary>
    [HarmonyPatch(typeof(BeachMaker))]
    [HarmonyPatch("Init")]
    public static class BeachMaker_Init_Patch
    {
        [HarmonyPrefix]
        public static bool Mashed_Ashlands_BeachMaker_Init_Patch(Map map)
        {
            BiomeProperties props = BiomeProperties.Get(map.Biome);
            if (props != null && props.disableBeaches)
            {
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Prevents BeachMaker placing sand for specific biomes
    /// </summary>
    [HarmonyPatch(typeof(BeachMaker))]
    [HarmonyPatch("BeachTerrainAt")]
    public static class BeachMaker_BeachTerrainAt_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_BeachMaker_BeachTerrainAt_Patch(BiomeDef biome, ref TerrainDef __result)
        {
            BiomeProperties props = BiomeProperties.Get(biome);
            if (props != null && props.nullifyBeachTerrain)
            {
                if (__result == TerrainDefOf.Sand)
                {
                    __result = null;
                }
            }
        }
    }

    /// <summary>
    /// Increases the number of geysers for specific biomes.
    /// </summary>
    [HarmonyPatch(typeof(GenStep_Scatterer))]
    [HarmonyPatch("CalculateFinalCount")]
    public static class GenStep_Scatterer_CalculateFinalCount_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_SteamGeyserNumber_Patch(Map map, ref GenStepDef ___def, ref int __result)
        {
            if (Mashed_Ashlands_ModSettings.EnableExtraGeysers && ___def == GenStepDefOf.SteamGeysers)
            {
                BiomeProperties props = BiomeProperties.Get(map.Biome);
                if (props != null && props.steamGeyserMultiplier != 1f)
                {
                    __result = (int)(__result * props.steamGeyserMultiplier);
                }
            }
        }
    }
}

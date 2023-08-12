using HarmonyLib;
using Verse;
using System.Reflection;
using RimWorld.Planet;
using System.Collections.Generic;
using System;
using RimWorld;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            Harmony harmony = new Harmony("com.Mashed_Ashlands");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ///Prventing beehives producing honey during ash storms
            if (ModsConfig.IsActive("sarg.rimbees"))
            {
                harmony.Patch(AccessTools.Method(AccessTools.TypeByName("Building_Beehouse"), "CheckRainLevels"), prefix: new HarmonyMethod(typeof(ConditionalHarmonyPatches), nameof(ConditionalHarmonyPatches.RimBees_Beehouse_AshStormPatch)));
            }

            ///Patching in support for SeedsPlease Lite, otherwise seeds are required to select plants, but never used when sowing them
            if (ModsConfig.IsActive("owlchemist.seedspleaselite"))
            {
                harmony.Patch(AccessTools.Method(typeof(WorkGiver_GrowerSowAsh), nameof(WorkGiver_GrowerSowAsh.JobOnCell)), postfix: new HarmonyMethod(AccessTools.Method(AccessTools.TypeByName("Patch_WorkGiver_GrowerSow_JobOnCell"), "Postfix")));
            }

            ///If geological landforms is not enabled, patch, otherwise geological landforms sand/gravel replacement is used
            if (!ModsConfig.IsActive("m00nl1ght.geologicallandforms"))
            {
                harmony.Patch(AccessTools.Method(AccessTools.TypeByName("GenStep_Terrain"), "TerrainFrom"), postfix: new HarmonyMethod(typeof(ConditionalHarmonyPatches), nameof(ConditionalHarmonyPatches.GenStep_Terrain_TerrainFrom_Patch)));
            }

            ///If biome transitions is enabled, swap to version with more overhead, but with better compatability
            if (ModsConfig.IsActive("m00nl1ght.geologicallandforms.biometransitions"))
            {
                harmony.Patch(AccessTools.Method(typeof(PlantUtility), nameof(PlantUtility.CanEverPlantAt), new Type[] { typeof(ThingDef), typeof(IntVec3), typeof(Map), typeof(bool) }), postfix: new HarmonyMethod(typeof(ConditionalHarmonyPatches), nameof(ConditionalHarmonyPatches.PlantUtility_CanEverPlantAt_Patch)));
            }
            else
            {
                harmony.Patch(AccessTools.Method(AccessTools.TypeByName("WildPlantSpawner"), "CalculatePlantsWhichCanGrowAt"), postfix: new HarmonyMethod(typeof(ConditionalHarmonyPatches), nameof(ConditionalHarmonyPatches.WildPlantSpawner_CalculatePlantsWhichCanGrowAt_Patch)));
            }
        }
    }

    public static class ConditionalHarmonyPatches
    {
        /// <summary>
        /// Patch for RimBees, prevents beehives producing honey during ash storms 
        /// </summary>
        public static bool RimBees_Beehouse_AshStormPatch(ref Building __instance, ref bool __result, ref bool ___flagRain)
        {
            if (Utility.MapHasUnsafeCondition(__instance))
            {
                __result = false;
                ___flagRain = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Only used if Geological Landforms is not enabled, as that mod includes it's own sand/gravel replacement that works with biome transitions
        /// </summary>
        public static void GenStep_Terrain_TerrainFrom_Patch(Map map, ref TerrainDef __result)
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
        
        /// <summary>
        /// Forces wild plants to only spawn on certain terrain, or near water.
        /// Doesn't play nice on a map with a biome transition.
        /// </summary>
        public static void WildPlantSpawner_CalculatePlantsWhichCanGrowAt_Patch(IntVec3 c, bool cavePlants, List<ThingDef> outPlants, Map ___map)
        {
            if (!cavePlants && !outPlants.NullOrEmpty() && OnStartupUtility.restrictedTerrainPlantsBiomes.Contains(___map.Biome))
            {
                List<ThingDef> PlantsToRemove = new List<ThingDef>();
                foreach (ThingDef plant in outPlants)
                {
                    PlantProperties props = PlantProperties.Get(plant);
                    if (props != null)
                    {
                        if (!PlantPropsUtility.WildPlantSpawnChecker(props, ___map, c))
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

        /// <summary>
        /// Forces wild plants to only spawn on certain terrain, or near water.
        /// Patching PlantUtility.CanEverPlantAt allows this to work with Biome Transitions.
        /// More overhead, so only used if Biome Transitions is enabled.
        /// </summary>
        public static void PlantUtility_CanEverPlantAt_Patch(ThingDef plantDef, IntVec3 c, Map map, ref bool __result)
        {
            if (__result)
            {
                PlantProperties props = PlantProperties.Get(plantDef);
                if (props != null)
                {
                    ///Don't worry about checking this for unsowable plants
                    if (!plantDef.plant.sowTags.NullOrEmpty())
                    {
                        ///checking for zone and grower building
                        if (map.zoneManager.ZoneAt(c) is Zone_GrowingAsh)
                        {
                            return;
                        }

                        List<Thing> list = map.thingGrid.ThingsListAt(c);
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] is Building_PlantGrower)
                            {
                                return;
                            }
                        }
                    }

                    ///Roughly the same as the other version after here
                    __result = PlantPropsUtility.WildPlantSpawnChecker(props, map, c);
                }
            }
        }
    }
}

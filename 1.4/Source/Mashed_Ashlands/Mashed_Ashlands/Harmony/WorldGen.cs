using HarmonyLib;
using Verse;
using System.Collections.Generic;
using RimWorld.Planet;
using RimWorld;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Forces biomes to have a specific rock type.
    /// </summary>
    [HarmonyPatch(typeof(World))]
    [HarmonyPatch("NaturalRockTypesIn")]
    public static class World_NaturalRockTypesIn_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_NaturalRockTypesIn_Patch(int tile, ref IEnumerable<ThingDef> __result, World __instance)
        {
            if (Mashed_Ashlands_ModSettings.EnableExclusiveRocks)
            {
                BiomeProperties props = BiomeProperties.Get(__instance.grid[tile].biome);
                if (props != null && props.forcedRockType != null)
                {
                    __result = new List<ThingDef> { props.forcedRockType };
                    return;
                }
            }

            List<ThingDef> newList = new List<ThingDef>();
            foreach (ThingDef rockDef in __result)
            {
                RockProperties rockProps = RockProperties.Get(rockDef);
                if (rockProps == null || !rockProps.onlyAllowIfForced)
                {
                    newList.Add(rockDef);
                }
            }
            __result = newList;
        }
    }

    /// <summary>
    /// Used Zombieland as a starting point, thanks Andreas Pardeike!
    /// Adds a new page during scenario setup, specifically for ashland world gen settings
    /// </summary>
    [HarmonyPatch(typeof(PageUtility))]
    [HarmonyPatch("StitchedPages")]
    public static class CreateWorldParams_DoWindowContents_Patch
    {
        [HarmonyPrefix]
        public static void Patch(List<Page> pages)
        {
            if (Mashed_Ashlands_ModSettings.EnableSettingBeforeWorldGen)
            {
                pages.Insert(pages.FindIndex(x => x is Page_CreateWorldParams), new Page_AshlandWorldGenSettings());
            }
        }
    }
}

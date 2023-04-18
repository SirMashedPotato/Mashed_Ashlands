using HarmonyLib;
using Verse;
using System.Collections.Generic;
using RimWorld.Planet;

namespace MorrowRim2
{
    /// <summary>
    /// Forces biomes to have a specific rock type.
    /// </summary>
    [HarmonyPatch(typeof(World))]
    [HarmonyPatch("NaturalRockTypesIn")]
    public static class World_NaturalRockTypesIn_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_NaturalRockTypesIn_Patch(int tile, ref IEnumerable<ThingDef> __result, World __instance)
        {
            if (MorrowRim_ModSettings.EnableExclusiveRocks)
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
}

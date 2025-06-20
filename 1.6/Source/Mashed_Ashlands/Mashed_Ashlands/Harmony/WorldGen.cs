using HarmonyLib;
using Verse;
using System.Collections.Generic;
using RimWorld.Planet;
using RimWorld;
using System.Linq;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Restricts basalt to Ashland biomes.
    /// </summary>
    [HarmonyPatch(typeof(World))]
    [HarmonyPatch("NaturalRockTypesIn")]
    public static class World_NaturalRockTypesIn_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_NaturalRockTypesIn_Patch(int tile, ref IEnumerable<ThingDef> __result, World __instance)
        {
            if (tile > -1)
            {
                BiomeProperties biomeProps = BiomeProperties.Get(__instance.grid[tile].biome);
                if (biomeProps != null && biomeProps.forceBasalt)
                {
                    __result = new List<ThingDef>() { ThingDefOf.Mashed_Ashlands_Basalt };
                    return;
                }
                if (__result.Contains(ThingDefOf.Mashed_Ashlands_Basalt))
                {
                    
                    if (biomeProps == null || !biomeProps.canHaveBasalt)
                    {
                        List<ThingDef> newList = new List<ThingDef>();
                        foreach (ThingDef rockDef in __result)
                        {
                            if (rockDef != ThingDefOf.Mashed_Ashlands_Basalt)
                            {
                                newList.Add(rockDef);
                            }
                        }
                        if (newList.NullOrEmpty())
                        {
                            ///May cause issues based on how many things call World.NaturalRockTypesIn
                            newList.Add(DefDatabase<ThingDef>.AllDefs.Where(x => x.IsNonResourceNaturalRock && x.modContentPack.IsCoreMod).RandomElement());
                        }
                        __result = newList;
                    }
                }
            }
           
        }
    }

    /// <summary>
    /// Actually prevents rivers from generating on certain ashland biomes on the world map.
    /// Unlike the vanilla field that just prevents them on the player map.
    /// </summary>
    [HarmonyPatch(typeof(WorldGenStep_Rivers))]
    [HarmonyPatch("ExtendRiver")]
    public static class WorldGenStep_Rivers_ExtendRiver_Patch
    {
        [HarmonyPrefix]
        public static bool Mashed_Ashlands_ExtendRiver_Patch(int index)
        {
            Tile tile = Find.WorldGrid.tiles[index];
            BiomeProperties props = BiomeProperties.Get(tile.biome);
            if (props != null && props.preventRivers)
            {
                return false;
            }
            return true;
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

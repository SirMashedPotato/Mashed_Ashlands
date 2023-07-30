using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    
    /// <summary>
    /// Allows for custom cave plants for specific biomes.
    /// </summary>
    [HarmonyPatch(typeof(WildPlantSpawner))]
    [HarmonyPatch("CalculatePlantsWhichCanGrowAt")]
    public static class WildPlantSpawner_CalculatePlantsWhichCanGrowAt_Patch
    {

        [HarmonyPrefix]
        public static bool Mashed_Ashlands_CustomCavePlants_Patch(IntVec3 c, bool cavePlants, List<ThingDef> outPlants, Map ___map)
        {
            if (cavePlants && Mashed_Ashlands_ModSettings.EnableCavePlants && OnStartupUtility.ashlandCavePlantsBiomes.Contains(___map.Biome))
            {
                outPlants.Clear();
                for (int i = 0; i < OnStartupUtility.ashlandCavePlants.Count; i++)
                {
                    if (OnStartupUtility.ashlandCavePlants[i].CanEverPlantAt(c, ___map, false))
                    {
                        outPlants.Add(OnStartupUtility.ashlandCavePlants[i]);
                    }
                }
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Increases the weight of ashland cave plants in ashland biomes, specifically for cave tiles
    /// </summary>
    [HarmonyPatch(typeof(WildPlantSpawner))]
    [HarmonyPatch("PlantChoiceWeight")]
    public static class WildPlantSpawner_PlantChoiceWeight_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_PlantChoiceWeight_Patch(ThingDef plantDef, IntVec3 c, ref float __result, Map ___map)
        {
            BiomeProperties biomeProps = BiomeProperties.Get(___map.Biome);
            if (biomeProps != null && biomeProps.useAshlandCavePlants)
            {
                RoofDef roof = c.GetRoof(___map);
                if (roof != null && roof.isNatural)
                {
                    {
                        PlantProperties plantProps = PlantProperties.Get(plantDef);
                        if (plantProps != null && plantProps.ashlandCavePlant)
                        {
                            __result = plantProps.cavePlantCommonality;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Ensures only ashland plants show up in the ashland growing zone
    /// And that exclusive ashland plants do not show up in the regular growing zone
    /// </summary>
    [HarmonyPatch(typeof(PlantUtility))]
    [HarmonyPatch("CanSowOnGrower")]
    public static class PlantUtility_CanSowOnGrower_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_CanSowOnGrower_Patch(ThingDef plantDef, object obj, ref bool __result)
        {
            if (__result)
            {
                if (obj is Zone_GrowingAsh)
                {
                    __result = plantDef.plant.sowTags.Contains("Mashed_Ashlands_Ash");
                }
                if (obj is Zone_Growing && Mashed_Ashlands_ModSettings.OnlySowOnAsh)
                {
                    __result = !plantDef.plant.sowTags.Contains("Mashed_Ashlands_AshExclusive");
                }
            }
        }
    }
}

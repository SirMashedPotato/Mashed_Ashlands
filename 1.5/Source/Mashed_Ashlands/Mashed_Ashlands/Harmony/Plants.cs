using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;

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
            if (cavePlants)
            {
                BiomeProperties props = BiomeProperties.Get(___map.Biome);
                if (props != null && !props.cavePlants.NullOrEmpty() && (Mashed_Ashlands_ModSettings.EnableCavePlants || props.forceCustomCavePlants))
                {
                    outPlants.Clear();
                    foreach (BiomePlantRecord record in props.cavePlants)
                    {
                        if (record.plant.CanEverPlantAt(c, ___map))
                        {
                            outPlants.Add(record.plant);
                        }
                    }
                    return false;
                }
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
            BiomeProperties props = BiomeProperties.Get(___map.Biome);
            if (props != null && props.increaseCavePlantWeight && !props.cavePlants.NullOrEmpty())
            {
                RoofDef roof = c.GetRoof(___map);
                if (roof != null && roof.isNatural)
                {
                    BiomePlantRecord plantRecord = props.cavePlants.Find(x => x.plant == plantDef);
                    if (plantRecord != null)
                    {
                        __result = plantRecord.commonality;

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

    /// <summary>
    /// Ensures only ashland plants show up in the ashland growing zone
    /// And that exclusive ashland plants do not show up in the regular growing zone
    /// </summary>
    [HarmonyPatch(typeof(HaulAIUtility))]
    [HarmonyPatch("HaulablePlaceValidator")]
    public static class HaulAIUtility_HaulablePlaceValidator_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_HaulablePlaceValidator_Patch(Thing haulable, Pawn worker, IntVec3 c, ref bool __result)
        {
            if (__result)
            {
                if (haulable != null && haulable.def.BlocksPlanting(false) && worker.Map.zoneManager.ZoneAt(c) is Zone_GrowingAsh)
                {
                    __result = false;
                }
            }
        }
    }
}

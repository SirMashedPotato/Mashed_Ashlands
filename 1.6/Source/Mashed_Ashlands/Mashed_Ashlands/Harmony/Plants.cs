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
    /*[HarmonyPatch(typeof(WildPlantSpawner))]
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
    }*/

    /// <summary>
    /// Increases the weight of ashland cave plants in ashland biomes, specifically for cave tiles
    /// </summary>
    /*[HarmonyPatch(typeof(WildPlantSpawner))]
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
    }*/

    
}

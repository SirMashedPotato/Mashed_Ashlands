using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Forces wild plants to only spawn near water
    /// And enables custom cave plants for ashlands biomes
    /// </summary>
    [HarmonyPatch(typeof(WildPlantSpawner))]
    [HarmonyPatch("CalculatePlantsWhichCanGrowAt")]
    public static class WildPlantSpawner_CalculatePlantsWhichCanGrowAt_Patch
    {
        public static bool Prefix(IntVec3 c, bool cavePlants, List<ThingDef> outPlants, Map ___map)
        {
            if (cavePlants && OnStartupUtility.restrictedTerrainPlantsBiomes.Contains(___map.BiomeAt(c)))
            {
                BiomeCaveProperties props = BiomeCaveProperties.GetProps(___map, c);
                if (props != null && !props.cavePlants.NullOrEmpty())
                {
                    outPlants.Clear();
                    foreach (BiomePlantRecord record in props.cavePlants)
                    {
                        if (record.plant.CanEverPlantAt(c, ___map))
                        {
                            outPlants.Add(record.plant);
                        }
                    }

                    foreach(ThingDef plant in outPlants)
                    {
                        Log.Message(plant);
                    }
                    return false;
                }
            }

            return true;
        }

        public static void Postfix(IntVec3 c, bool cavePlants, List<ThingDef> outPlants, Map ___map)
        {
            if (!cavePlants && !outPlants.NullOrEmpty() && OnStartupUtility.restrictedTerrainPlantsBiomes.Contains(___map.BiomeAt(c)))
            {
                List<ThingDef> PlantsToRemove = new List<ThingDef>();
                foreach (ThingDef plant in outPlants)
                {
                    PlantProperties props = PlantProperties.Get(plant);
                    if (props != null)
                    {
                        if (!props.WildPlantSpawnChecker(___map, c))
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
    }

    /// <summary>
    /// Increases the weight of ashland cave plants in ashland biomes, specifically for cave tiles
    /// </summary>
    [HarmonyPatch(typeof(WildPlantSpawner))]
    [HarmonyPatch("PlantChoiceWeight")]
    public static class WildPlantSpawner_PlantChoiceWeight_Patch
    {
        public static void Postfix(ThingDef plantDef, IntVec3 c, ref float __result, Map ___map)
        {
            RoofDef roof = c.GetRoof(___map);
            if (roof != null && roof.isNatural)
            {
                BiomeCaveProperties props = BiomeCaveProperties.GetProps(___map, c);
                if (props != null && !props.cavePlants.NullOrEmpty())
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
}

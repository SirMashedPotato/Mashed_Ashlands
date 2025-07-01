using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Forces wild plants to only spawn near water
    /// TODO, may be a workaround with terrain
    /// </summary>
    [HarmonyPatch(typeof(WildPlantSpawner))]
    [HarmonyPatch("CalculatePlantsWhichCanGrowAt")]
    public static class WildPlantSpawner_CalculatePlantsWhichCanGrowAt_Patch
    {
        public static void Postfix(IntVec3 c, bool cavePlants, List<ThingDef> outPlants, Map ___map)
        {
            if (!cavePlants && !outPlants.NullOrEmpty() && OnStartupUtility.restrictedTerrainPlantsBiomes.Contains(___map.Biome))
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
}

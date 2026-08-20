using HarmonyLib;
using RimWorld;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Adds permanent conditions only when a specific setting is enabled
    /// </summary>
    [HarmonyPatch(typeof(BiomeConditionMapComponent))]
    [HarmonyPatch("MapGenerated")]
    public static class BiomeConditionMapComponent_MapGenerated_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_MapGenerated_Patch(BiomeConditionMapComponent __instance)
        {
            if (Mashed_Ashlands_ModSettings.EnableVolcanoRemovalChanges && __instance.map != null)
            {
                BiomeProperties props =  BiomeProperties.Get(__instance.map.Biome);
                if (props != null && props.optionalPermanentCondition != null)
                {
                    __instance.map.GameConditionManager.RegisterCondition(GameConditionMaker.MakeConditionPermanent(props.optionalPermanentCondition));
                }
            }
        }
    }
}

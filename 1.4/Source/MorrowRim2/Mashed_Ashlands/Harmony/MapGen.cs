using HarmonyLib;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Increases the number of geysers for specific biomes.
    /// </summary>
    [HarmonyPatch(typeof(GenStep_Scatterer))]
    [HarmonyPatch("CalculateFinalCount")]
    public static class GenStep_Scatterer_CalculateFinalCount_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_SteamGeyserNumber_Patch(Map map, ref GenStepDef ___def, ref int __result)
        {
            if (Mashed_Ashlands_ModSettings.EnableExtraGeysers && ___def == GenStepDefOf.SteamGeysers)
            {
                BiomeProperties props = BiomeProperties.Get(map.Biome);
                if (props != null && props.steamGeyserMultiplier != 1f)
                {
                    __result = (int)(__result * props.steamGeyserMultiplier);
                }
            }
        }
    }
}

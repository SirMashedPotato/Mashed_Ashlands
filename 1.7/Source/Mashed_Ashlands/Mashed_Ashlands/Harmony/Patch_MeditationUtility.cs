using HarmonyLib;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Disables meditation outside during an ash storm
    /// </summary>
    [HarmonyPatch(typeof(MeditationUtility))]
    [HarmonyPatch("SafeEnvironmentalConditions")]
    public static class MeditationUtility_SafeEnvironmentalConditions_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_SafeEnvironmentalConditions_Patch(IntVec3 cell, Map map, ref bool __result)
        {
            if (__result)
            {
                if (!cell.Roofed(map))
                {
                    __result = !Utility.MapHasUnsafeCondition(map);
                }
            }
        }
    }
}

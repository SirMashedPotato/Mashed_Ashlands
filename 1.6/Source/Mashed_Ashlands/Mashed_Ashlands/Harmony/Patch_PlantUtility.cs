using HarmonyLib;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Ensures only ashland plants show up in the ashland growing zone
    /// And that exclusive ashland plants do not show up in the regular growing zone
    /// </summary>
    [HarmonyPatch(typeof(PlantUtility))]
    [HarmonyPatch("CanSowOnGrower")]
    public static class PlantUtility_CanSowOnGrower_Patch
    {
        public static void Postfix(ThingDef plantDef, object obj, ref bool __result)
        {
            if (__result && obj is Zone)
            {
                if (obj is Zone_GrowingAsh)
                {
                    __result = plantDef.plant.sowTags.Contains("Mashed_Ashlands_Ash");
                }
                else if (Mashed_Ashlands_ModSettings.OnlySowOnAsh)
                {
                    Log.Message(obj);
                    __result = !plantDef.plant.sowTags.Contains("Mashed_Ashlands_AshExclusive");
                }
            }
        }
    }
}

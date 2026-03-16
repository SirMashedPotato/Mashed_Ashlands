using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public static class Compat_NicePlantsMenu
    {
        /// <summary>
        /// Patch for Nice Plants Menu so that plants are restricted to the correct growing zones
        /// </summary>
        public static void NicePlantsMenu_PlantBrowser_SewAvailable(ThingDef plantDef, IPlantToGrowSettable s, ref bool __result)
        {
            if (__result && s is Zone)
            {
                __result = PlantUtility_CanSowOnGrower_Patch.CanSowPlantInZone(plantDef, s as Zone);
            }
        }
    }
}

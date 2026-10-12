using Verse;

namespace Mashed_Ashlands
{
    public static class Compat_AlphaBees
    {
        /// <summary>
        /// Patch for RimBees, prevents beehives producing honey during ash storms 
        /// </summary>
        public static bool RimBees_Beehouse_AshStormPatch(ref Building __instance, ref bool __result, ref bool ___flagRain)
        {
            if (Utility.MapHasUnsafeCondition(__instance))
            {
                __result = false;
                ___flagRain = false;
                return false;
            }
            return true;
        }
    }
}

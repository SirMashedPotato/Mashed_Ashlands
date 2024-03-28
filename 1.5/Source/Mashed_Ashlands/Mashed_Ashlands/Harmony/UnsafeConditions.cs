using HarmonyLib;
using Verse;
using RimWorld;
using Verse.AI;

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

    /// <summary>
    /// Prevents the run wild mental break during an ash storm
    /// </summary>
    [HarmonyPatch(typeof(MentalBreakWorker_RunWild))]
    [HarmonyPatch("BreakCanOccur")]
    public static class MentalBreakWorker_RunWild_BreakCanOccur_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_MentalBreakWorker_RunWild_Patch(Pawn pawn, ref bool __result)
        {
            if (__result)
            {
                float resistance = pawn.GetStatValue(StatDefOf.Mashed_Ashlands_AshResistance);
                if (resistance < 1f)
                {
                    __result = !Utility.MapHasUnsafeCondition(pawn);
                }
            }
        }
    }

    /// <summary>
    /// Prevents pawns arriving during an ash storm
    /// caravans and such
    /// </summary>
    [HarmonyPatch(typeof(IncidentWorker_PawnsArrive))]
    [HarmonyPatch("CanFireNowSub")]
    public static class IncidentWorker_PawnsArrive_CanFireNowSub_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_MentalBreakWorker_RunWild_Patch(IncidentParms parms, ref bool __result)
        {
            if (__result)
            {
                if (parms.target is Map map)
                {
                    __result = !Utility.MapHasUnsafeCondition(map);
                }
            }
        }
    }
}

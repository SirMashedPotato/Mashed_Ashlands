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
        public static void MorrowRim_SafeEnvironmentalConditions_Patch(IntVec3 cell, Map map, ref bool __result)
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
    /// Forces animals to wander inside during an ash storm
    /// </summary>
    [HarmonyPatch(typeof(JobGiver_WanderInRoofedCellsInPen))]
    [HarmonyPatch("ShouldSeekRoofedCells")]
    public static class JobGiver_WanderInRoofedCellsInPen_ShouldSeekRoofedCells_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_SafeEnvironmentalConditions_Patch(Pawn pawn, ref bool __result)
        {
            if (!__result)
            {
                float resistance = pawn.GetStatValue(StatDefOf.MorrowRim_AshResistance);
                if (resistance < 1f)
                {
                    __result = Utility.MapHasUnsafeCondition(pawn);
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
        public static void MorrowRim_MentalBreakWorker_RunWild_Patch(Pawn pawn, ref bool __result)
        {
            if (__result)
            {
                float resistance = pawn.GetStatValue(StatDefOf.MorrowRim_AshResistance);
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
        public static void MorrowRim_MentalBreakWorker_RunWild_Patch(IncidentParms parms, ref bool __result)
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

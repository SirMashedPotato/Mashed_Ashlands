using HarmonyLib;
using Verse.AI;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{

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
}

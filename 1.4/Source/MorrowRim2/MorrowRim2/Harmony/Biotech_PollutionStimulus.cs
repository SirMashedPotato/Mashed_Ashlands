using HarmonyLib;
using Verse;

namespace MorrowRim2
{
    /// <summary>
    /// Allows setting animals that should recieve/not recieve pollution stimulus
    /// </summary>
    [HarmonyPatch(typeof(PollutionUtility))]
    [HarmonyPatch("StimulatedByPollution")]
    public static class PollutionUtility_StimulatedByPollution_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_StimulatedByPollution_Patch(Pawn pawn, ref bool __result)
        {
            PollutionProperties props = PollutionProperties.Get(pawn.def);
            if (props != null)
            {
                __result = (__result && props.AllowPollutionStimulis);
            }
        }
    }

    /// <summary>
    /// Allows adding an alternative pollution stimulus hediff
    /// </summary>
    [HarmonyPatch(typeof(PollutionUtility))]
    [HarmonyPatch("PawnPollutionTick")]
    public static class PollutionUtility_PawnPollutionTick_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_AlternativePollutionStimulus_Patch(Pawn pawn)
        {
            if (!pawn.Spawned)
            {
                return;
            }
            PollutionProperties props = PollutionProperties.Get(pawn.def);
            if (props != null && props.alternativePollutionStimulis != null)
            {
                if (pawn.IsHashIntervalTick(60) && pawn.Position.IsPolluted(pawn.Map) && !pawn.health.hediffSet.HasHediff(props.alternativePollutionStimulis, false))
                {
                    pawn.health.AddHediff(props.alternativePollutionStimulis, null, null, null);
                }
            }
        }
    }
}

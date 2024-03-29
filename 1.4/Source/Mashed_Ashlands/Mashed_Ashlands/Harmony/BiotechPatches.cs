﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Reduces the fertilty loss caused by pollution for specific biomes
    /// It makes the polluted regions of the map look less like a wasteland
    /// ~0.005ms tick impact on average at speed 1
    /// </summary>
    [HarmonyPatch(typeof(FertilityGrid))]
    [HarmonyPatch("CalculateFertilityAt")]
    public static class FertilityGrid_CalculateFertilityAt_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_CalculateFertilityAt_Patch(IntVec3 loc, ref float __result, Map ___map)
        {
            if (ModsConfig.BiotechActive)
            {
                if (loc.IsPolluted(___map))
                {
                    if (OnStartupUtility.modifiedPollutionFertilityBiomes.Contains(___map.Biome))
                    {
                        __result = loc.GetTerrain(___map).fertility * 0.8f;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Allows setting animals that should recieve/not recieve pollution stimulus
    /// </summary>
    [HarmonyPatch(typeof(PollutionUtility))]
    [HarmonyPatch("StimulatedByPollution")]
    public static class PollutionUtility_StimulatedByPollution_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_StimulatedByPollution_Patch(Pawn pawn, ref bool __result)
        {
            if (OnStartupUtility.hasPollutionPropsAnimals.Contains(pawn.def))
            {
                PollutionProperties props = PollutionProperties.Get(pawn.def);
                __result = __result && props.AllowPollutionStimulis;
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
        public static void Mashed_Ashlands_AlternativePollutionStimulus_Patch(Pawn pawn)
        {
            if (!pawn.Spawned)
            {
                return;
            }
            
            if (OnStartupUtility.alternateStimulisAnimals.Contains(pawn.def))
            {
                PollutionProperties props = PollutionProperties.Get(pawn.def);
                if (pawn.IsHashIntervalTick(60) && pawn.Position.IsPolluted(pawn.Map) && !pawn.health.hediffSet.HasHediff(props.alternativePollutionStimulis, false))
                {
                    pawn.health.AddHediff(props.alternativePollutionStimulis, null, null, null);
                }
            }
        }
    }
}

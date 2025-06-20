using Verse;

namespace Mashed_Ashlands
{
    public static class BiotechHarmonyPatches
    {
        /// <summary>
        /// Reduces the fertilty loss caused by pollution for specific biomes
        /// It makes the polluted regions of the map look less like a wasteland
        /// ~0.005ms tick impact on average at speed 1
        /// </summary>
        public static void FertilityGrid_CalculateFertilityAt_Patch(IntVec3 loc, ref float __result, Map ___map)
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

        /// <summary>
        /// Allows setting animals that should recieve/not recieve pollution stimulus
        /// </summary>
        public static void PollutionUtility_StimulatedByPollution_Patch(Pawn pawn, ref bool __result)
        {
            if (OnStartupUtility.hasPollutionPropsAnimals.Contains(pawn.def))
            {
                PollutionProperties props = PollutionProperties.Get(pawn.def);
                __result = __result && props.AllowPollutionStimulis;
            }
        }

        /// <summary>
        /// Allows adding an alternative pollution stimulus hediff
        /// </summary>
        public static void PollutionUtility_PawnPollutionTick_Patch(Pawn pawn)
        {
            if (!pawn.Spawned || pawn.Map == null)
            {
                return;
            }

            if (OnStartupUtility.alternateStimulisAnimals.Contains(pawn.def))
            {
                PollutionProperties props = PollutionProperties.Get(pawn.def);
                if (pawn.IsHashIntervalTick(60) && pawn.Position.IsPolluted(pawn.Map) && !pawn.health.hediffSet.HasHediff(props.alternativePollutionStimulis, false))
                {
                    pawn.health.AddHediff(props.alternativePollutionStimulis);
                }
            }
        }
    }
}

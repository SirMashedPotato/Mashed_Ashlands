using HarmonyLib;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [HarmonyPatch(typeof(CompHatcher))]
    [HarmonyPatch("Hatch")]
    public static class CompHatcher_Hatch_Patch
    {
        /// <summary>
        /// Increases the wild population if a factionless cliff racer egg hatches
        /// </summary>
        [HarmonyPostfix]
        public static void Mashed_Ashlands_Hatch_Patch(ref CompHatcher __instance, ref Faction ___hatcheeFaction)
        {
            if (Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction)
            {
                if (___hatcheeFaction == null && __instance.parent.def == ThingDefOf.Mashed_Ashlands_Egg_CliffRacerFertilized)
                {
                    CliffRacerTrackerUtility.ModifyProgress(1);
                }
            }
        }
    }

    /// <summary>
    /// Increases the wild population if a cliff racer is released into the wild
    /// </summary>
    [HarmonyPatch(typeof(ReleaseAnimalToWildUtility))]
    [HarmonyPatch("DoReleaseAnimal")]
    public static class ReleaseAnimalToWildUtility_DoReleaseAnimal_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_ReleaseAnimal_Patch(Pawn animal)
        {
            if (Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction)
            {
                if (animal.def == ThingDefOf.Mashed_Ashlands_CliffRacer)
                {
                    CliffRacerTrackerUtility.ModifyProgress(1);
                }
            }
        }
    }

    /// <summary>
    /// Decreases the wild population if a cliff racer is tamed
    /// </summary>
    [HarmonyPatch(typeof(RecruitUtility))]
    [HarmonyPatch("Recruit")]
    public static class InteractionWorker_RecruitAttempt_DoRecruit_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_TameAnimal_Patch(Pawn pawn)
        {
            if (Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction)
            {
                if (pawn.def == ThingDefOf.Mashed_Ashlands_CliffRacer)
                {
                    CliffRacerTrackerUtility.ModifyProgress(-1);
                }
            }
        }
    }

    /// <summary>
    /// Used as it affects both normal and polluted animals
    /// Prevents cliff racers from spawning if they are extinct
    /// </summary>
    [HarmonyPatch(typeof(WildAnimalSpawner))]
    [HarmonyPatch("CommonalityOfAnimalNow")]
    public static class WildAnimalSpawner_CommonalityOfAnimalNow_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_CliffRacerCommonality_Patch(PawnKindDef def, ref float __result)
        {
            if (def.race == ThingDefOf.Mashed_Ashlands_CliffRacer && Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction && CliffRacerTrackerUtility.ExtinctionReached())
            {
                __result = 0;
            }
        }
    }

    /// <summary>
    /// Allows male cliff racers to lay eggs, if they have the asexual mutation
    /// Only adults will ever have the mutation, so don't need to check lifestages
    /// </summary>
    [HarmonyPatch(typeof(CompEggLayer))]
    [HarmonyPatch("Active", MethodType.Getter)]
    public static class CompEggLayer_Active_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_CliffRacerCanLayEggs_Patch(CompEggLayer __instance, ref bool __result)
        {
            if (!__result)
            {
                Pawn pawn = __instance.parent as Pawn;
                if (pawn.def == ThingDefOf.Mashed_Ashlands_CliffRacer && !pawn.Sterile() && pawn.GetComp<Comp_CliffRacerMutation>().hasAsexualMutation)
                {
                    __result = true;
                }
            }
        }
    }

    /// <summary>
    /// Allows cliff racers to lay unfertilised eggs, if they have the asexual mutation
    /// </summary>
    [HarmonyPatch(typeof(CompEggLayer))]
    [HarmonyPatch("ProgressStoppedBecauseUnfertilized", MethodType.Getter)]
    public static class CompEggLayer_ProgressStoppedBecauseUnfertilized_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_CliffRacerCanLayEggs_Patch(CompEggLayer __instance, ref bool __result)
        {
            if (__result)
            {
                Pawn pawn = __instance.parent as Pawn;
                if (pawn.def == ThingDefOf.Mashed_Ashlands_CliffRacer && pawn.GetComp<Comp_CliffRacerMutation>().hasAsexualMutation)
                {
                    __result = false;
                }
            }
        }
    }
}

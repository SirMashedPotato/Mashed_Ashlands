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
        [HarmonyPrefix]
        public static void Mashed_Ashlands_Hatch_Patch(ref CompHatcher __instance, ref Faction ___hatcheeFaction)
        {
            if (Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction)
            {
                if (___hatcheeFaction == null && __instance.parent.def == ThingDefOf.Mashed_Ashlands_Egg_CliffRacerFertilized)
                {
                    CliffRacerTrackerUtility.ModifyProgress(__instance.parent.stackCount);
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
                Comp_EggLayerMutant eggLayerComp = pawn.GetComp<Comp_EggLayerMutant>();
                if (eggLayerComp == null || !eggLayerComp.AsexualMutation)
                {
                    return;
                }
                if (!pawn.Sterile())
                {
                    __result = true;
                }
            }
        }
    }
}

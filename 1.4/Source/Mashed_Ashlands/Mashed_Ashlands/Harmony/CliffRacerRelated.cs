using HarmonyLib;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [HarmonyPatch(typeof(CompHatcher))]
    [HarmonyPatch("Hatch")]
    public static class CompHatcher_Hatch_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_Hatch_Patch(ref CompHatcher __instance, ref Faction ___hatcheeFaction)
        {
            if (Mashed_Ashlands_ModSettings.EnableCliffRacerExtinction)
            {
                if (___hatcheeFaction == null && __instance.parent.def == ThingDefOf.Mashed_Ashlands_Egg_CliffRacerFertilized)
                {
                    CliffRacerTrackerUtility.ModifyProgress(1);
                }
            }
        }
    }

    [HarmonyPatch(typeof(ReleaseAnimalToWildUtility))]
    [HarmonyPatch("DoReleaseAnimal")]
    public static class ReleaseAnimalToWildUtility_DoReleaseAnimal_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_ReleaseAnimal_Patch(Pawn animal)
        {
            if (Mashed_Ashlands_ModSettings.EnableCliffRacerExtinction)
            {
                if (animal.def == ThingDefOf.Mashed_Ashlands_CliffRacer)
                {
                    CliffRacerTrackerUtility.ModifyProgress(1);
                }
            }
        }
    }

    [HarmonyPatch(typeof(RecruitUtility))]
    [HarmonyPatch("Recruit")]
    public static class InteractionWorker_RecruitAttempt_DoRecruit_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_TameAnimal_Patch(Pawn pawn)
        {
            if (Mashed_Ashlands_ModSettings.EnableCliffRacerExtinction)
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
    /// </summary>
    [HarmonyPatch(typeof(WildAnimalSpawner))]
    [HarmonyPatch("CommonalityOfAnimalNow")]
    public static class WildAnimalSpawner_CommonalityOfAnimalNow_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_CliffRacerCommonality_Patch(PawnKindDef def, ref float __result)
        {
            if (def.race == ThingDefOf.Mashed_Ashlands_CliffRacer && Mashed_Ashlands_ModSettings.EnableCliffRacerExtinction && CliffRacerTrackerUtility.ExtinctionReached())
            {
                __result = 0;
            }
        }
    }
}

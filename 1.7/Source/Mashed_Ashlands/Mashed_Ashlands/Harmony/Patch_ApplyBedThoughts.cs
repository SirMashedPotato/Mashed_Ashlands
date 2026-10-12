using HarmonyLib;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [HarmonyPatch(typeof(Toils_LayDown))]
    [HarmonyPatch("ApplyBedThoughts")]
    public static class Toils_LayDown_ApplyBedThoughts_Patch
    {
        public static void Postfix(Pawn actor, Building_Bed bed)
        {
            if (actor.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.Mashed_Ashlands_XylariaDreamPowderHigh) != null)
            {
                if (actor.needs.mood == null)
                {
                    return;
                }

                actor.needs.mood.thoughts.memories.TryGainMemory(ThoughtMaker.MakeThought(ThoughtDefOf.Mashed_Ashlands_XylariaDreamPowderDreams, 0));
            }
        }
    }
}

using HarmonyLib;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Adds a random ability to specific pawns during generation.
    /// </summary>
    [HarmonyPatch(typeof(PawnGenerator))]
    [HarmonyPatch("GenerateInitialHediffs")]
    public static class PawnGenerator_GenerateInitialHediffs_Patch
    {
        public static void Postfix(Pawn pawn)
        {
            AnimalProperties props = AnimalProperties.Get(pawn.def);
            if (props != null)
            {
                if (!props.randomAbility.NullOrEmpty())
                {
                    if (pawn.abilities == null)
                    {
                        pawn.abilities = new Pawn_AbilityTracker(pawn);
                    }
                    pawn.abilities.GainAbility(props.randomAbility.RandomElement());
                }
            }
        }
    }
}

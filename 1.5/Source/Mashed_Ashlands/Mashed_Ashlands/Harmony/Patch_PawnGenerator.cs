using HarmonyLib;
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
        [HarmonyPostfix]
        public static void Mashed_Ashlands_GenerateInitialHediffs_Patch(Pawn pawn)
        {
            AnimalProperties props = AnimalProperties.Get(pawn.def);
            if (props != null)
            {
                if (!props.randomAbility.NullOrEmpty())
                {
                    pawn.abilities.GainAbility(props.randomAbility.RandomElement());
                }
            }
        }
    }
}

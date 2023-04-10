using RimWorld;
using Verse;

namespace MorrowRim2
{
    [DefOf]
    public static class GameConditionDefOf
    {
        static GameConditionDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(GameConditionDefOf));
        }
        public static GameConditionDef MorrowRim_AshStorm;
    }
}
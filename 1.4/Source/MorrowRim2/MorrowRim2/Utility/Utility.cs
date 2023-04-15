using Verse;
using RimWorld;

namespace MorrowRim2
{
    public static class Utility
    {

        public static bool MapHasUnsafeCondition(Thing thing)
        {
            return MapHasAshStorm(thing.MapHeld);
        }

        public static bool MapHasUnsafeCondition(Map map)
        {
            return MapHasAshStorm(map);
        }

        public static bool MapHasAshStorm(Thing thing)
        {
            return MapHasAshStorm(thing.MapHeld);
        }

        ///If terrible performance, swap to: map.gameConditionManager.ConditionIsActive(GameConditionDefOf.MorrowRim_AshStorm))
        ///And then check for each individual def I guess
        public static bool MapHasAshStorm(Map map)
        {
            return map.gameConditionManager.ActiveConditions.Any((GameCondition x) => x.def.conditionClass == typeof(GameCondition_AshStorm));
        }
    }
}

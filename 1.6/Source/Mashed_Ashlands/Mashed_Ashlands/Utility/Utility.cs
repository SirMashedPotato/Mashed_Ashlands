using Verse;
using RimWorld;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public static class Utility
    {
        public static List<PawnKindDef> BlightedKindDefs()
        {
            return new List<PawnKindDef> 
            { 
                PawnKindDefOf.Mashed_Ashlands_Alit, 
                PawnKindDefOf.Mashed_Ashlands_Kagouti, 
                PawnKindDefOf.Mashed_Ashlands_Netch,
                PawnKindDefOf.Mashed_Ashlands_NixHound, 
                PawnKindDefOf.Mashed_Ashlands_Shalk
            };
        }

        public static bool MapHasUnsafeCondition(Thing thing)
        {
            return MapHasUnsafeCondition(thing.MapHeld);
        }

        public static bool MapHasUnsafeCondition(Map map)
        {
            return MapHasAshStorm(map) || MapHasOtherUnsafeCondition(map);
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

        public static bool MapHasOtherUnsafeCondition(Map map)
        {
            return map.gameConditionManager.ConditionIsActive(GameConditionDefOf.Mashed_Ashlands_VolcanicMiasma);
        }

        public static bool MapHasDustStorm(Thing thing)
        {
            return MapHasDustStorm(thing.MapHeld);
        }

        public static bool MapHasDustStorm(Map map)
        {
            WeatherDef curWeather = map.weatherManager.curWeather;
            return curWeather == WeatherDefOf.Mashed_Ashlands_DustStorm || curWeather == WeatherDefOf.Mashed_Ashlands_DustThunderstorm;
        }

        public static bool CaveInCellValidator(Map map, IntVec3 c)
        {
            if (!c.Standable(map))
            {
                return false;
            }

            c.TryGetFirstThing(map, out Thing thing);
            if (thing != null && !(thing is Filth))
            {
                return false;
            }

            return true;
        }
    }
}

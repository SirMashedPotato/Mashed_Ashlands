using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class WeatherDefOf
    {
        static WeatherDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(WeatherDefOf));
        }

        public static WeatherDef Mashed_Ashlands_DustStorm;
        public static WeatherDef Mashed_Ashlands_DustThunderstorm;
    }
}

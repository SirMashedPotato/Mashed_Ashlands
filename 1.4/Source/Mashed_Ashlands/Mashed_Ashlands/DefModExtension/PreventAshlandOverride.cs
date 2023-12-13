using Verse;

namespace Mashed_Ashlands
{
    public class PreventAshlandOverride : DefModExtension
    {
        /// <summary>
        /// Dummy mod extension that can be patched into biome defs to prevent ashland biomes from overriding them during world gen
        /// Only checked in WorldGenStep_AshlandBiomesEarly, shouldn't need to be checked anywhere else
        /// </summary>
        public static PreventAshlandOverride Get(Def def)
        {
            return def.GetModExtension<PreventAshlandOverride>();
        }
    }
}

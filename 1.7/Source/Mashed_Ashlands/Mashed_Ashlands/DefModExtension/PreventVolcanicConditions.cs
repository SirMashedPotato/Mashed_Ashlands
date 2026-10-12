using Verse;

namespace Mashed_Ashlands
{
    public class PreventVolcanicConditions : DefModExtension
    {
        /// <summary>
        /// Dummy mod extension that can be patched into biome defs to prevent them being affected by conditions from volcanos
        /// Mostly meant for stuff with outer space biomes, pocket maps are already handled without needing this
        /// </summary>
        public static PreventVolcanicConditions Get(Def def) => def.GetModExtension<PreventVolcanicConditions>();
    }
}

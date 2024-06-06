using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_ScatterAshlandsSpecific : GenStep_ScatterThings
    {
        public override void Generate(Map map, GenStepParams parms)
        {
            BiomeProperties properties = BiomeProperties.Get(map.Biome);
            if (properties != null && properties.useAshlandsGenSteps)
            {
                base.Generate(map, parms);
            }
        }
    }
}

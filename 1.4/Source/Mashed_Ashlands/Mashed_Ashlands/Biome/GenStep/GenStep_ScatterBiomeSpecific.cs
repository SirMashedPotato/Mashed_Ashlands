using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_ScatterBiomeSpecific : GenStep_ScatterThings
    {
        public override void Generate(Map map, GenStepParams parms)
        {
            if (allowedBiomes.Contains(map.Biome))
            {
                base.Generate(map, parms);
            }
        }

        public List<BiomeDef> allowedBiomes;
    }
}

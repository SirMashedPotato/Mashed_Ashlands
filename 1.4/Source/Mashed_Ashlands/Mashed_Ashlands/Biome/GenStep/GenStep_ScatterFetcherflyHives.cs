using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_ScatterFetcherflyHives : GenStep_ScatterThings
    {
        protected override bool ShouldSkipMap(Map map)
        {
            if (Mashed_Ashlands_ModSettings.EnableFetcherflyHives && allowedBiomes.Contains(map.Biome))
            {
                return base.ShouldSkipMap(map);
            }
            return true;
        }

        public List<BiomeDef> allowedBiomes;
    }
}

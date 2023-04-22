using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    public class BiomeProperties : DefModExtension
    {
        /* For world gen */
        public bool earlyLoader = false;
        public bool lateLoader = false;
        public bool baseBiome = false;

        /* for biome gen */
        public bool disableBeaches = false;
        public TerrainDef caveGravelReplacer;
        public List<TerrainReplacer> terrainReplacers;
        public List<TerrainReplacer> roadReplacers;
        public ThingDef forcedRockType;
        public bool increasePollutedFertility = false;
        public bool useAshlandCavePlants = false;

        /* general use */
        public List<TerrainReplacer> dryToReplacers;

        public static BiomeProperties Get(Def def)
        {
            return def.GetModExtension<BiomeProperties>();
        }
    }

    public class TerrainReplacer
    {
        public TerrainDef originalTerrain;
        public TerrainDef replacedTerrain;
    }
}

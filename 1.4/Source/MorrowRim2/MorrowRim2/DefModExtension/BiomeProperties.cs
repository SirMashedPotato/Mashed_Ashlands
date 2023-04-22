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
        
        public List<TerrainReplacer> terrainReplacers;
        public List<TerrainReplacer> roadReplacers;
        public ThingDef forcedRockType;
        public bool increasePollutedFertility = false;

        /* for cave gen */
        public bool useAshlandCavePlants = false;
        public bool useCustomCaveTerrain = false;
        public TerrainDef otherTerrainDef;
        public TerrainDef waterTerrainDef;
        public float otherTerrainThreshold = 0.55f;
        public float waterThreshold = 0.93f;

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

using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class BiomeProperties : DefModExtension
    {
        /* For world gen */
        public bool earlyLoader = false;
        public bool lateLoader = false;
        public bool baseBiome = false;
        public bool canHaveBasalt = true;
        public bool preventRivers = false;

        /* for biome gen */
        public bool disableBeaches = false;
        public bool nullifyBeachTerrain = false;
        public bool forceHilliness = false;
        public bool useAshlandsGenSteps = false;

        public List<TerrainReplacer> terrainReplacers;
        public List<TerrainReplacer> roadReplacers;
        public float steamGeyserMultiplier = 1f;
        public bool restrictPlantsToTerrain = false;
        public bool increasePollutedFertility = false;

        /* for cave gen */
        public List<BiomePlantRecord> cavePlants;
        public bool forceCustomCavePlants = false;
        public bool increaseCavePlantWeight = true;
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

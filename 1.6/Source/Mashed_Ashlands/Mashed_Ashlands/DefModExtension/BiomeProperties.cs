using RimWorld;
using System.Collections.Generic;
using System.Xml;
using Verse;

namespace Mashed_Ashlands
{
    public class BiomeProperties : DefModExtension
    {
        /* For world gen */
        public bool earlyLoader = false;
        public bool lateLoader = false;
        public bool baseBiome = false;

        /* for biome gen */
        public bool forceHilliness = false;
        public bool useAshlandsGenSteps = true;
        public List<TerrainReplacer> roadReplacers;
        public bool increasePollutedFertility = true;
        public bool restrictPlantsToTerrain = true;
        public BiomeCaveProperties caveProps;

        /* general use */
        public List<TerrainReplacer> dryToReplacers;
        public bool allowAshlandsIncidents = true;
        public bool allowAshRaids = true;

        public static BiomeProperties Get(Def def) => def.GetModExtension<BiomeProperties>();
    }

    public class TerrainReplacer
    {
        public TerrainDef originalTerrain;
        public TerrainDef replacedTerrain;

        public void LoadDataFromXmlCustom(XmlNode xmlRoot)
        {
            DirectXmlCrossRefLoader.RegisterObjectWantsCrossRef(this, "originalTerrain", xmlRoot);
            DirectXmlCrossRefLoader.RegisterObjectWantsCrossRef(this, "replacedTerrain", xmlRoot.InnerText);
        }
    }

    public class BiomeCaveProperties
    {
        public List<BiomePlantRecord> cavePlants;
        public TerrainReplacer caveGravelReplacer;
    }
}

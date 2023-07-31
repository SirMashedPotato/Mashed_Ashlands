using Verse;
using System.Collections.Generic;
using RimWorld;
using System.Linq;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public static class OnStartupUtility
    {
        public static HashSet<BiomeDef> earlyAshlandBiomeDefs = new HashSet<BiomeDef> { };
        public static HashSet<BiomeDef> lateAshlandBiomeDefs = new HashSet<BiomeDef> { };
        public static HashSet<BiomeDef> baseAshlandBiomeDefs = new HashSet<BiomeDef> { };

        public static HashSet<BiomeDef> restrictedTerrainPlantsBiomes = new HashSet<BiomeDef> { };
        public static HashSet<BiomeDef> ashlandCavePlantsBiomes = new HashSet<BiomeDef> { };
        public static HashSet<BiomeDef> modifiedPollutionFertilityBiomes = new HashSet<BiomeDef> { };

        public static List<ThingDef> ashlandCavePlants = new List<ThingDef> { };
        public static List<ThingDef> ashlandFlowerPlants = new List<ThingDef> { };

        static OnStartupUtility()
        {
            FillBiomeLists(DefDatabase<BiomeDef>.AllDefsListForReading);
            FillPlantLists(DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.IsPlant).ToList());
            EditRockTerrain();
        }

        public static void FillBiomeLists(List<BiomeDef> biomeDefs)
        {
            foreach(BiomeDef biomeDef in biomeDefs)
            {
                BiomeProperties props = BiomeProperties.Get(biomeDef);
                if (props != null)
                {
                    if (props.earlyLoader)
                    {
                        earlyAshlandBiomeDefs.Add(biomeDef);
                    }
                    if (props.lateLoader)
                    {
                        lateAshlandBiomeDefs.Add(biomeDef);
                    }
                    if (props.baseBiome)
                    {
                        baseAshlandBiomeDefs.Add(biomeDef);
                    }
                    if (props.restrictPlantsToTerrain)
                    {
                        restrictedTerrainPlantsBiomes.Add(biomeDef);
                    }
                    if (props.useAshlandCavePlants)
                    {
                        ashlandCavePlantsBiomes.Add(biomeDef);
                    }
                    if (props.increasePollutedFertility)
                    {
                        modifiedPollutionFertilityBiomes.Add(biomeDef);
                    }
                }
            }
        }

        public static void FillPlantLists(List<ThingDef> plantDefs)
        {
            foreach(ThingDef thingDef in plantDefs)
            {
                PlantProperties props = PlantProperties.Get(thingDef);
                if (props != null)
                {
                    if (props.ashlandCavePlant)
                    {
                        ashlandCavePlants.Add(thingDef);
                    }
                    if (props.ashlandFlowerPlant)
                    {
                        ashlandFlowerPlants.Add(thingDef);
                    }
                }
            }
        }

        /// <summary>
        /// Edits specific details about implied terrain defs
        /// </summary>
        public static void EditRockTerrain()
        {
            foreach (ThingDef thingDef in from def in DefDatabase<ThingDef>.AllDefs
                                          where RockProperties.Get(def) != null
                                          select def)
            {
                RockProperties props = RockProperties.Get(thingDef);
                if (!props.requireIdeoForTex || ModsConfig.IdeologyActive)
                {
                    if (props.roughTexPathReplacer != null && thingDef.building.naturalTerrain != null)
                    {
                        EditImpliedTerrain(thingDef.building.naturalTerrain, props.roughTexPathReplacer, props.applyToPolluted, props.scatterTypeReplacer);
                    }
                    if (props.roughHewnTexPathReplacer != null && thingDef.building.leaveTerrain != null)
                    {
                        EditImpliedTerrain(thingDef.building.leaveTerrain, props.roughHewnTexPathReplacer, props.applyToPolluted, props.scatterTypeReplacer);
                    }
                    if (props.smoothTexPathReplacer != null && thingDef.building.naturalTerrain.smoothedTerrain != null)
                    {
                        EditImpliedTerrain(thingDef.building.naturalTerrain.smoothedTerrain, props.smoothTexPathReplacer, props.applyToPolluted, props.scatterTypeReplacer);
                    }
                }
            }
        }

        /// <summary>
        /// Need to reset graphic, and call postLoad, to update the terrain texture
        /// </summary>
        public static void EditImpliedTerrain(TerrainDef def, string newTexPath, bool applyToPolluted, string scatterType = null)
        {
            def.texturePath = newTexPath;
            if (scatterType != null)
            {
                def.scatterType = scatterType;
            }
            if (ModsConfig.BiotechActive && applyToPolluted)
            {
                def.pollutedTexturePath = newTexPath;
                def.graphicPolluted = BaseContent.BadGraphic;
            }
            def.graphic = BaseContent.BadGraphic;
            def.PostLoad();
        }
    }
}

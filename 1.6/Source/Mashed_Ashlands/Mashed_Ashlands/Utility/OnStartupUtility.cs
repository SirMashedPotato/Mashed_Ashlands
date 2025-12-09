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
        public static HashSet<BiomeDef> modifiedPollutionFertilityBiomes = new HashSet<BiomeDef> { };

        public static HashSet<ThingDef> ashlandFlowerPlants = new HashSet<ThingDef> { };

        public static HashSet<ThingDef> hasPollutionPropsAnimals = new HashSet<ThingDef> { };
        public static HashSet<ThingDef> alternateStimulisAnimals = new HashSet<ThingDef> { };
        public static HashSet<ThingDef> glowOverlayAnimals = new HashSet<ThingDef> { };

        public static HashSet<UndercaveTypeDef> randomUndercaveTypes = new HashSet<UndercaveTypeDef> { };

        static OnStartupUtility()
        {
            FillAnimalsLists(DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.race != null).ToList());
            FillBiomeLists(DefDatabase<BiomeDef>.AllDefsListForReading);
            FillPlantLists(DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.IsPlant).ToList());
            ModifyFlowerFeederLinks();
            ModifyRockTerrainDefs();
            randomUndercaveTypes = DefDatabase<UndercaveTypeDef>.AllDefsListForReading.Where(x => x.naturallyGenerates).ToHashSet();
        }

        public static void FillAnimalsLists(List<ThingDef> pawnDefs)
        {
            foreach (ThingDef pawnDef in pawnDefs)
            {
                AnimalProperties animalProps = AnimalProperties.Get(pawnDef);
                if (animalProps != null)
                {
                    if (animalProps.glowOverlay)
                    {
                        glowOverlayAnimals.Add(pawnDef);
                    }
                }
                if (ModsConfig.BiotechActive)
                {
                    PollutionProperties pollutionProps = PollutionProperties.Get(pawnDef);
                    if (pollutionProps != null)
                    {
                        hasPollutionPropsAnimals.Add(pawnDef);
                        if (pollutionProps.alternativePollutionStimulis != null)
                        {
                            alternateStimulisAnimals.Add(pawnDef);
                        }
                    }
                }
            }
        }

        public static void ModifyFlowerFeederLinks()
        {
            ThinkNode_ConditionalAshlandFlowerFeeding thinkNode = ThinkTreeDefOf.Mashed_Ashlands_FeedFromAshlandFlower.thinkRoot as ThinkNode_ConditionalAshlandFlowerFeeding;
            foreach (ThingDef animalDef in thinkNode.animalDefs)
            {
                if (animalDef.descriptionHyperlinks.NullOrEmpty())
                {
                    animalDef.descriptionHyperlinks = new List<DefHyperlink> { };
                }
                foreach (ThingDef flower in ashlandFlowerPlants)
                {
                    animalDef.descriptionHyperlinks.Add(flower);
                }
            }
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
                    if (props.ashlandFlowerPlant)
                    {
                        ashlandFlowerPlants.Add(thingDef);
                    }
                }
            }
        }


        public static void ModifyRockTerrainDefs()
        {
            foreach (ThingDef thingDef in from def in DefDatabase<ThingDef>.AllDefs
                                          where RockProperties.Get(def) != null
                                          select def)
            {
                RockProperties props = RockProperties.Get(thingDef);
                if (props.roughTexPathReplacer != null && thingDef.building.naturalTerrain != null)
                {
                    EditImpliedTerrain(thingDef.building.naturalTerrain, props.roughTexPathReplacer, props);
                }
                if (props.roughHewnTexPathReplacer != null && thingDef.building.leaveTerrain != null)
                {
                    EditImpliedTerrain(thingDef.building.leaveTerrain, props.roughHewnTexPathReplacer, props);
                }
                if (props.smoothTexPathReplacer != null && thingDef.building.naturalTerrain.smoothedTerrain != null)
                {
                    EditImpliedTerrain(thingDef.building.naturalTerrain.smoothedTerrain, props.smoothTexPathReplacer, props);
                }
            }
        }

        /// <summary>
        /// Need to reset graphic, and call postLoad, to update the terrain texture
        /// </summary>
        public static void EditImpliedTerrain(TerrainDef def, string newTexPath, RockProperties props)
        {
            def.texturePath = newTexPath;
            if (props.scatterTypeReplacer != null)
            {
                def.scatterType = props.scatterTypeReplacer;
            }
            if (props.overrideFilthAcceptance)
            {
                def.filthAcceptanceMask = (FilthSourceFlags)props.filthAcceptanceOverride;
            }
            if (ModsConfig.BiotechActive && props.applyToPolluted)
            {
                def.pollutedTexturePath = newTexPath;
                def.graphicPolluted = BaseContent.BadGraphic;
            }
            def.graphic = BaseContent.BadGraphic;
            def.PostLoad();
        }
    }
}

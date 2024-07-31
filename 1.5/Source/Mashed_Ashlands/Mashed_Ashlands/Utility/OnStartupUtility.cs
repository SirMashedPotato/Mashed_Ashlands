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

        public static List<ThingDef> ashlandFlowerPlants = new List<ThingDef> { };

        public static List<ThingDef> hasPollutionPropsAnimals = new List<ThingDef> { };
        public static List<ThingDef> alternateStimulisAnimals = new List<ThingDef> { };
        public static List<ThingDef> glowOverlayAnimals = new List<ThingDef> { };

        static OnStartupUtility()
        {
            FillAnimalsLists(DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.race != null).ToList());
            FillBiomeLists(DefDatabase<BiomeDef>.AllDefsListForReading);
            FillPlantLists(DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.IsPlant).ToList());
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
    }
}

using Verse;
using System.Collections.Generic;
using RimWorld;

namespace MorrowRim2
{
    [StaticConstructorOnStartup]
    public static class OnStartupUtility
    {
        public static List<BiomeDef> earlyAshlandBiomeDefs = new List<BiomeDef> { };
        public static List<BiomeDef> lateAshlandBiomeDefs = new List<BiomeDef> { };
        public static List<BiomeDef> baseAshlandBiomeDefs = new List<BiomeDef> { };

        static OnStartupUtility()
        {
            FillBiomeLists(DefDatabase<BiomeDef>.AllDefsListForReading);
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
                }
            }
        }
    }
}

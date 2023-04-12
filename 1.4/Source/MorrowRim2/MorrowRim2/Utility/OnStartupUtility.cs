using Verse;
using System.Collections.Generic;
using RimWorld;
using System.Linq;

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
                if (props.roughTexPathReplacer != null && thingDef.building.naturalTerrain != null)
                {
                    EditImpliedTerrain(thingDef.building.naturalTerrain, props.roughTexPathReplacer, props.scatterTypeReplacer);
                }
                if (props.roughHewnTexPathReplacer != null && thingDef.building.leaveTerrain != null)
                {
                    EditImpliedTerrain(thingDef.building.leaveTerrain, props.roughHewnTexPathReplacer, props.scatterTypeReplacer);
                }
                if (props.smoothTexPathReplacer != null && thingDef.building.naturalTerrain.smoothedTerrain != null)
                {
                    EditImpliedTerrain(thingDef.building.naturalTerrain.smoothedTerrain, props.smoothTexPathReplacer, props.scatterTypeReplacer);
                }
            }
        }

        /// <summary>
        /// Need to reset graphic, and call postLoad, to update the terrain texture
        /// </summary>
        public static void EditImpliedTerrain(TerrainDef def, string newTexPath, string scatterType = null)
        {
            def.texturePath = newTexPath;
            if (scatterType != null)
            {
                def.scatterType = scatterType;
            }
            def.graphic = BaseContent.BadGraphic;
            def.PostLoad();
        }
    }
}

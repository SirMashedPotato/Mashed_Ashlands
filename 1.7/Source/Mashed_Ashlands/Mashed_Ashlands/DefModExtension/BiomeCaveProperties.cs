using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class BiomeCaveProperties : DefModExtension
    {
        public TerrainDef caveGravelReplacer;
        public float gravelThreshold = 0.55f;
        public float waterThreshold = 0.93f;
        public bool useDefaultCaveGen = false;
        public List<BiomePlantRecord> cavePlants;

        public static BiomeCaveProperties Get(Def def) => def.GetModExtension<BiomeCaveProperties>();

        public static BiomeCaveProperties GetProps(Map map, IntVec3 c) => Get(map.BiomeAt(c));
    }
}

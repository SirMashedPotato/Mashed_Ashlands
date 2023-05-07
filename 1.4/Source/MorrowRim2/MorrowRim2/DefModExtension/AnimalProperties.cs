using RimWorld;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    public class AnimalProperties : DefModExtension
    {
        public bool requireRiver = false;
        public bool requireCoast = false;
        public bool requireWater = false;
        public bool requireCaves = false;
        public bool requireHills = false;
        public List<BiomeDef> ignoreRequirementsInBiomes;

        public static AnimalProperties Get(Def def)
        {
            return def.GetModExtension<AnimalProperties>();
        }
    }
}

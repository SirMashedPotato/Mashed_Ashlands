using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MorrowRim2
{
    public class WorldObjectCompProperties_VolcanoDetails : WorldObjectCompProperties
    {
        public RulePackDef nameNamer;
        public List<CategoryWeights> categoryWeights;
            
        public WorldObjectCompProperties_VolcanoDetails()
        {
            compClass = typeof(WorldObjectComp_VolcanoDetails);
        }
    }

    public class CategoryWeights
    {
        public int category;
        public float weight;
    }
}

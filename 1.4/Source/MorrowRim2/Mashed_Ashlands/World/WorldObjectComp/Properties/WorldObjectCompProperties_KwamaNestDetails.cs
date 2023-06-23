using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class WorldObjectCompProperties_KwamaNestDetails : WorldObjectCompProperties
    {
        public RulePackDef nameNamer;
        public IntRange sizeRange;

        public WorldObjectCompProperties_KwamaNestDetails()
        {
            compClass = typeof(WorldObjectComp_KwamaNestDetails);
        }
    }
}

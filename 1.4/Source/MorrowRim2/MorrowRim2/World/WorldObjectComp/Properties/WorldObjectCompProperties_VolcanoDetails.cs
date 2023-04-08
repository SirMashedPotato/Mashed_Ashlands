using System;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace MorrowRim2
{
    public class WorldObjectCompProperties_VolcanoDetails : WorldObjectCompProperties
    {
        public RulePackDef nameNamer;

        public WorldObjectCompProperties_VolcanoDetails()
        {
            compClass = typeof(WorldObjectComp_VolcanoDetails);
        }
    }
}

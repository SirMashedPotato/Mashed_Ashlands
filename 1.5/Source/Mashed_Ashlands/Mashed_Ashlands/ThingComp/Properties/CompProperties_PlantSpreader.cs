using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_PlantSpreader : CompProperties
    {
        public CompProperties_PlantSpreader()
        {
            compClass = typeof(Comp_PlantSpreader);
        }

        public ThingDef plantDef;
        public int spreadRadius = 2;
        public int tickInterval = 600;
        public bool disableIfPolluted = true;
        public bool spreadOnWater = false;
    }
}

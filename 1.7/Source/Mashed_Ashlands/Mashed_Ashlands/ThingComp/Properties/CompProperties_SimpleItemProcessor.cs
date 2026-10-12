using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_SimpleItemProcessor : CompProperties
    {
        public CompProperties_SimpleItemProcessor() => compClass = typeof(Comp_SimpleItemProcessor);

        public int processDays = 1;
        public ThingDef yieldThingDef;
        public int yieldAmount = 1;
    }
}

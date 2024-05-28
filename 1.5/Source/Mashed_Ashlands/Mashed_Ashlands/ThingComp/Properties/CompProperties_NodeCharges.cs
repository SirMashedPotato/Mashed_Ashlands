using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_NodeCharges : CompProperties
    {
        public CompProperties_NodeCharges()
        {
            compClass = typeof(Comp_NodeCharges);
        }

        public IntRange chargesRange;
        public string resourceName;
    }
}

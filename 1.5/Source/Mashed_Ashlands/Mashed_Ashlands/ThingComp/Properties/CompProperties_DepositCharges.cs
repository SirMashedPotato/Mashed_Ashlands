using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_DepositCharges : CompProperties
    {
        public CompProperties_DepositCharges()
        {
            compClass = typeof(Comp_DepositCharges);
        }

        public IntRange chargesRange;
        public string resourceName;
    }
}

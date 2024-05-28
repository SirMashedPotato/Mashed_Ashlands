using Verse;

namespace Mashed_Ashlands
{
    public class Comp_NodeCharges : ThingComp
    {
        private CompProperties_NodeCharges Props
        {
            get
            {
                return (CompProperties_NodeCharges)props;
            }
        }

        private int chargesLeft = 0;

        public override void Initialize(CompProperties props)
        {
            base.Initialize(props);
            chargesLeft = Props.chargesRange.RandomInRange;
        }

        public void ChargeConsumed()
        {
            chargesLeft--;
            if (chargesLeft <= 0)
            {
                parent.Destroy();
            }
        }

        public override string CompInspectStringExtra()
        {
            return "Mashed_Ashlands_NodeChargesLeft".Translate(chargesLeft, Props.resourceName);
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref chargesLeft, "chargesLeft", 0);
        }
    }
}

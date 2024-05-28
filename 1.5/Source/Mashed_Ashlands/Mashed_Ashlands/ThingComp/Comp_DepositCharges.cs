using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class Comp_DepositCharges : ThingComp
    {
        private CompProperties_DepositCharges Props
        {
            get
            {
                return (CompProperties_DepositCharges)props;
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
                Messages.Message("Mashed_Ashlands_DepositExhausted".Translate(parent), MessageTypeDefOf.NeutralEvent);
                parent.Kill();
            }
        }

        public override string CompInspectStringExtra()
        {
            return "Mashed_Ashlands_DepositChargesLeft".Translate(chargesLeft, Props.resourceName);
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref chargesLeft, "chargesLeft", 0);
        }
    }
}

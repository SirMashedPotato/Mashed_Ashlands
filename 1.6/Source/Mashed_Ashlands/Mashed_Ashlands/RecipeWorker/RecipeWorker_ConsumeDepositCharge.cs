using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class RecipeWorker_ConsumeDepositCharge : RecipeWorker
    {
        public Comp_DepositCharges GetNodeChargeComp(Building b)
        {
            if (nodeChargeComp == null)
            {
                nodeChargeComp = b.GetComp<Comp_DepositCharges>();
            }
            return nodeChargeComp;
        }

        private Comp_DepositCharges nodeChargeComp;

        public override void Notify_IterationCompleted(Pawn billDoer, List<Thing> ingredients)
        {
            if (billDoer.CurJob.targetA != null && billDoer.CurJob.targetA.Thing is Building b)
            {
                GetNodeChargeComp(b).ChargeConsumed();
            }
            base.Notify_IterationCompleted(billDoer, ingredients);
        }
    }
}

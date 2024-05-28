using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class RecipeWorker_ConsumeCharge : RecipeWorker
    {
        public Comp_NodeCharges GetNodeChargeComp(Building b)
        {
            if (nodeChargeComp == null)
            {
                nodeChargeComp = b.GetComp<Comp_NodeCharges>();
            }
            return nodeChargeComp;
        }

        private Comp_NodeCharges nodeChargeComp;

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

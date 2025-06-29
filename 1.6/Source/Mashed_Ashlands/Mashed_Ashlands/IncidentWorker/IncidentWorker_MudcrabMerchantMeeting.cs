using Mashed_Ashlands.Classes;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Mashed_Ashlands
{
    public class IncidentWorker_MudcrabMerchantMeeting : IncidentWorker_AshlandsSpecific
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return base.CanFireNowSub(parms) && parms.target is Caravan;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Caravan caravan = (Caravan)parms.target;
            CameraJumper.TryJumpAndSelect(caravan);
            DiaNode diaNode = new DiaNode(def.letterText.Formatted(caravan.Name).Resolve().CapitalizeFirst());
            Pawn bestPlayerNegotiator = BestCaravanPawnUtility.FindBestNegotiator(caravan, null, TraderKindDefOf.Mashed_Ashlands_MudcrabMerchant);

            TradeEncounter trader = new TradeEncounter(TraderKindDefOf.Mashed_Ashlands_MudcrabMerchant);

            DiaOption diaOptionTrade = new DiaOption("CaravanMeeting_Trade".Translate())
            {
                action = delegate
                {
                    Find.WindowStack.Add(new Dialog_Trade(bestPlayerNegotiator, trader));
                }
            };
            if (bestPlayerNegotiator == null)
            {
                diaOptionTrade.Disable("CaravanMeeting_TradeIncapable".Translate());

            }
            diaNode.options.Add(diaOptionTrade);

            DiaOption diaOptionLeave = new DiaOption("CaravanMeeting_MoveOn".Translate())
            {
                action = delegate
                {
                    trader.GetDirectlyHeldThings().ClearAndDestroyContents();
                },
                resolveTree = true
            };
            diaNode.options.Add(diaOptionLeave);
            string title = def.letterLabel.CapitalizeFirst();
            Find.WindowStack.Add(new Dialog_NodeTree(diaNode, delayInteractivity: true, title: title));
            Find.Archive.Add(new ArchivedDialog(diaNode.text, title));
            return true;
        }
    }
}

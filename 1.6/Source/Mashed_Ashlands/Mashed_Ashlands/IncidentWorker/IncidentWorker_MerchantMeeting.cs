using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Mashed_Ashlands
{
    public class IncidentWorker_MerchantMeeting : IncidentWorker_AshlandsSpecific
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            IncidentProperties incidentProps = IncidentProperties.Get(def);
            return base.CanFireNowSub(parms) && parms.target is Caravan && incidentProps != null && incidentProps.traderKindDef != null;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            IncidentProperties incidentProps = IncidentProperties.Get(def);

            Caravan caravan = (Caravan)parms.target;
            CameraJumper.TryJumpAndSelect(caravan);
            DiaNode diaNode = new DiaNode(def.letterText.Formatted(caravan.Name).Resolve().CapitalizeFirst());
            Pawn bestPlayerNegotiator = BestCaravanPawnUtility.FindBestNegotiator(caravan, null, incidentProps.traderKindDef);

            TradeEncounter trader = new TradeEncounter(incidentProps.traderKindDef);

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

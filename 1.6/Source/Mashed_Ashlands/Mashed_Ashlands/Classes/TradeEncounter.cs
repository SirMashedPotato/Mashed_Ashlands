using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    internal class TradeEncounter : ITrader, IThingHolder
    {
        public TraderKindDef traderKindDef;
        private readonly ThingOwner things;
        private readonly int randomPriceFactorSeed = -1;

        public TradeEncounter(TraderKindDef def) : base()
        {
            things = new ThingOwner<Thing>(this);
            traderKindDef = def;
            GenerateThings();
        }

        public TraderKindDef TraderKind => traderKindDef;

        public IEnumerable<Thing> Goods
        {
            get
            {
                for (int i = 0; i < things.Count; i++)
                {
                    yield return things[i];
                }
            }
        }

        public void GenerateThings()
        {
            ThingSetMakerParams parms = default;
            parms.traderDef = traderKindDef;
            parms.tile = null;
            things.TryAddRangeOrTransfer(ThingSetMakerDefOf.TraderStock.root.Generate(parms));
        }

        public int RandomPriceFactorSeed => randomPriceFactorSeed;

        public string TraderName => traderKindDef.label.CapitalizeFirst();

        public bool CanTradeNow => true;

        public float TradePriceImprovementOffsetForPlayer => 0f;

        public Faction Faction => null;

        public TradeCurrency TradeCurrency => traderKindDef.tradeCurrency;

        public IThingHolder ParentHolder => null;

        public IEnumerable<Thing> ColonyThingsWillingToBuy(Pawn playerNegotiator)
        {
            return playerNegotiator.GetCaravan().ColonyThingsWillingToBuy(playerNegotiator);
        }

        public void GiveSoldThingToPlayer(Thing toGive, int countToGive, Pawn playerNegotiator)
        {
            Caravan caravan = playerNegotiator.GetCaravan();
            Thing thing = toGive.SplitOff(countToGive);
            thing.PreTraded(TradeAction.PlayerBuys, playerNegotiator, this);

            if (toGive is Pawn pawn)
            {
                caravan.AddPawn(pawn, addCarriedPawnToWorldPawnsIfAny: true);
                if (!pawn.IsWorldPawn() && caravan.Spawned)
                {
                    Find.WorldPawns.PassToWorld(pawn);
                }
                return;
            }

            Pawn pawn2 = CaravanInventoryUtility.FindPawnToMoveInventoryTo(thing, caravan.PawnsListForReading, null);
            if (pawn2 == null)
            {
                Log.Error("Could not find pawn to move bought thing to (bought by player). thing=" + thing);
                thing.Destroy();
            }
            else if (!pawn2.inventory.innerContainer.TryAdd(thing))
            {
                Log.Error("Could not add item to inventory.");
                thing.Destroy();
            }
        }

        public void GiveSoldThingToTrader(Thing toGive, int countToGive, Pawn playerNegotiator)
        {
            Thing thing = toGive.SplitOff(countToGive);
            thing.PreTraded(TradeAction.PlayerSells, playerNegotiator, this);

            if (thing is Pawn p)
            {
                Caravan caravan = playerNegotiator.GetCaravan();
                CaravanInventoryUtility.MoveAllInventoryToSomeoneElse(p, caravan.PawnsListForReading);
                if (!p.RaceProps.Humanlike && !things.TryAdd(p, canMergeWithExistingStacks: false))
                {
                    p.Destroy();
                }
                return;
            }

            Thing thing2 = TradeUtility.ThingFromStockToMergeWith(this, thing);
            if (thing2 != null)
            {
                if (!thing2.TryAbsorbStack(thing, respectStackLimit: false))
                {
                    thing.Destroy();
                }
            }
        }

        public void GetChildHolders(List<IThingHolder> outChildren)
        {
            ThingOwnerUtility.AppendThingHoldersFromThings(outChildren, GetDirectlyHeldThings());
        }

        public ThingOwner GetDirectlyHeldThings()
        {
            return things;
        }
    }
}

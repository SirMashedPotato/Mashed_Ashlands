using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Mashed_Ashlands
{
    public class StockGenerator_BuyExpensive : StockGenerator
    {
        public float minValuePerUnit = 100f;

        public override IEnumerable<Thing> GenerateThings(PlanetTile forTile, Faction faction = null)
        {
            return Enumerable.Empty<Thing>();
        }

        public override bool HandlesThingDef(ThingDef thingDef)
        {
            if (thingDef.category != ThingCategory.Item || !thingDef.genericMarketSellable)
            {
                return false;
            }
            return thingDef.BaseMarketValue / thingDef.VolumePerUnit >= minValuePerUnit;
        }

        public override Tradeability TradeabilityFor(ThingDef thingDef)
        {
            if (thingDef.tradeability == Tradeability.None || !HandlesThingDef(thingDef))
            {
                return Tradeability.None;
            }
            return Tradeability.Sellable;
        }
    }
}

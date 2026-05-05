using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class StockGenerator_SingleDefWithStuff : StockGenerator_SingleDef
    {
        public ThingDef stuffDef;

        public override IEnumerable<Thing> GenerateThings(PlanetTile forTile, Faction faction = null)
        {
            foreach (Thing item in base.GenerateThings(forTile, faction))
            {
                item.SetStuffDirect(stuffDef);
                yield return item;
            }
        }
    }
}

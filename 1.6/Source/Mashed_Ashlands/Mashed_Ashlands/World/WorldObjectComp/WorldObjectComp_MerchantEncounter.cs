using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Mashed_Ashlands
{
    public class WorldObjectComp_MerchantEncounter : WorldObjectComp
    {
        private const int tickInterval = GenDate.TicksPerDay / 2;
        public WorldObjectCompProperties_MerchantEncounter Props => (WorldObjectCompProperties_MerchantEncounter)props;

        public override void CompTickInterval(int delta)
        {
            base.CompTickInterval(delta);
            if (parent.IsHashIntervalTick(tickInterval, delta))
            {
                if (parent is Caravan caravan)
                {

                    if (caravan.Faction == null || caravan.Faction != Faction.OfPlayer)
                    {
                        return;
                    }

                    if (caravan.Tile == null || caravan.Tile.Tile.PrimaryBiome == null)
                    {
                        return;
                    }

                    BiomeProperties props = BiomeProperties.Get(caravan.Tile.Tile.PrimaryBiome);
                    if (props == null || !props.allowAshlandsIncidents)
                    {
                        return;
                    }

                    if (!Rand.Chance(Props.chance))
                    {
                        return;
                    }

                    GenerateIncident(caravan);
                }
            }
        }

        private void GenerateIncident(Caravan caravan)
        {
            IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(Props.incidentDef.category, caravan);
            if (Props.incidentDef.Worker.CanFireNow(incidentParms))
            {
                Props.incidentDef.Worker.TryExecute(incidentParms);
            }
        }
    }
}

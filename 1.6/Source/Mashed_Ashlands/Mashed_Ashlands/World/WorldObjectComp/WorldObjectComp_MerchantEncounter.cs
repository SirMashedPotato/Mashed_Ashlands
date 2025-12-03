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

                    foreach(IncidentDef incidentDef in Props.incidentDefs.InRandomOrder())
                    {
                        IncidentParms incidentParms = GetIncidentParms(caravan, incidentDef);
                        if (incidentDef.Worker.CanFireNow(incidentParms))
                        {
                            GenerateIncident(incidentDef, incidentParms);
                            return;
                        }
                    }
                }
            }
        }

        private void GenerateIncident(IncidentDef incidentDef, IncidentParms incidentParms)
        {
            if (incidentDef.Worker.CanFireNow(incidentParms))
            {
                //Done this way so the game can track how long it's been since the incident last fired
                FiringIncident firingIncident = new FiringIncident(incidentDef, null, incidentParms);
                Find.Storyteller.TryFire(firingIncident);
            }
        }

        private IncidentParms GetIncidentParms(Caravan caravan, IncidentDef incidentDef)
        {
            IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(incidentDef.category, caravan);
            incidentParms.forced = false;
            return incidentParms;
        }
    }
}

using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    internal class CaravanEventWorker_BlightedCaravanAmbush : CaravanVolcanicEventWorker
    {
        public override void CaravanEventWorker(Volcano parentVolcano, List<Caravan> targets)
        {
            if (!Mashed_Ashlands_ModSettings.BlightStormCaravanAmbush)
            {
                return;
            }
            if (Rand.Chance(chance))
            {
                foreach (Caravan caravan in targets.InRandomOrder())
                {
                    if (!caravan.pather.MovingNow)
                    {
                        TriggerAmbush(caravan);
                        return;
                    }
                }
            }
        }

        private void TriggerAmbush(Caravan caravan)
        {
            IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(incidentDef.category, caravan);
            incidentParms.forced = true;
            incidentDef.Worker.TryExecute(incidentParms);
        }

        public override IEnumerable<string> ConfigErrors()
        {
            foreach (string item in base.ConfigErrors())
            {
                yield return item;
            }

            if (incidentDef == null)
            {
                yield return "incidentDef is null";
            }
        }

        public IncidentDef incidentDef;
        public float chance = 0.3f;
    }
}

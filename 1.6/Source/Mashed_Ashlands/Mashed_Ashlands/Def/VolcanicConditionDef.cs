using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class VolcanicConditionDef : Def
    {
        public GameConditionDef conditionDef;
        public FloatRange baseDurationDays;
        public FloatRange baseGraceDays;
        public bool isNullCondition = false;
        public bool sendLetter = true;
        public bool sendEndMessage = true;
        public bool countAsIncident = true;
        public int minVolcanoCategory = 1;
        public int forcedCategory = 0;
        public List<CaravanVolcanicEventWorker> caravanVolcanicEventWorkers = new List<CaravanVolcanicEventWorker>();

        public FloatRange GetTrueConditionDuration(float multiplier = 1f)
        {
            return (baseDurationDays * multiplier) * Mashed_Ashlands_ModSettings.VolcanoConditionDurationMultiplier;
        }

        public FloatRange GetTrueGraceDuration(float multiplier = 1f)
        {
            return (baseGraceDays * multiplier) * Mashed_Ashlands_ModSettings.VolcanoConditionGraceMultiplier;
        }

        public void TriggerCaravanEvents(Volcano parentVolcano, List<Caravan> targets)
        {
            if (caravanVolcanicEventWorkers.NullOrEmpty())
            {
                return;
            }
            foreach(CaravanVolcanicEventWorker eventWorker in caravanVolcanicEventWorkers)
            {
                eventWorker.CaravanEventWorker(parentVolcano, targets);
            }
        }

        public override IEnumerable<string> ConfigErrors()
        {
            foreach (string item in base.ConfigErrors())
            {
                yield return item;
            }

            if (!isNullCondition && conditionDef == null)
            {
                yield return "isNullCondition is false but conditionDef is null";
            }
        }
    }
}

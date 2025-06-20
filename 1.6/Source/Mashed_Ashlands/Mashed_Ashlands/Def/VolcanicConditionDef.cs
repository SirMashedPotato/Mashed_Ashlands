using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// TODO switch to using this in 1.6
    /// </summary>
    public class VolcanicConditionDef : Def
    {
        public GameConditionDef conditionDef;
        public FloatRange durationDays;
        public FloatRange graceDaysAfter;
        public bool isNullCondition = false;
        public bool sendLetter = true;
        public bool sendEndMessage = true;
        public bool countAsIncident = true;
        public int minVolcanoCategory = 1;
        public int forcedCategory = 0;
        public List<CaravanVolcanicEventWorker> caravanVolcanicEventWorkers;

        public FloatRange GetTrueConditionDuration => durationDays * Mashed_Ashlands_ModSettings.VolcanoConditionDurationMultiplier;

        public FloatRange GetTrueGraceDuration => graceDaysAfter * Mashed_Ashlands_ModSettings.VolcanoConditionGraceMultiplier;

        public override IEnumerable<string> ConfigErrors()
        {
            foreach (string item in base.ConfigErrors())
            {
                yield return item;
            }
        }
    }
}

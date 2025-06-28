using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class WorldObjectCompProperties_RandomConditionCauser : WorldObjectCompProperties
    {
        public WorldObjectCompProperties_RandomConditionCauser() => compClass = typeof(WorldObjectComp_RandomConditionCauser);

        public bool preventConditionStacking = true;
        public List<PotentialConditions> potentialConditions;
    }

    public class PotentialConditions 
    {
        public VolcanicConditionDef volcanicConditionDef;
        public float weight = 1f;
        public float durationDaysFactor = 1f;
        public float graceDaysFactor = 1f;

        public FloatRange GetTrueConditionDuration => volcanicConditionDef.GetTrueConditionDuration(durationDaysFactor);

        public float GetRandomDurationDays => GetTrueConditionDuration.RandomInRange;

        public FloatRange GetTrueGraceDuration => volcanicConditionDef.GetTrueGraceDuration(graceDaysFactor);
       
        public float GetRandomGraceDays => GetTrueGraceDuration.RandomInRange;
    }
}

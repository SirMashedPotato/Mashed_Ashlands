﻿using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class WorldObjectCompProperties_RandomConditionCauser : WorldObjectCompProperties
    {
        public WorldObjectCompProperties_RandomConditionCauser()
        {
            compClass = typeof(WorldObjectComp_RandomConditionCauser);
        }

        public bool preventConditionStacking = true;
        public List<PotentialConditions> potentialConditions;
    }

    public class PotentialConditions 
    {
        public GameConditionDef conditionDef = null;
        public FloatRange durationDays;
        public FloatRange graceDaysAfter;
        public float weight = 1f;
        public bool sendLetter = true;
        public bool sendEndMessage = true;
        public bool countAsIncident = true;
        public int minVolcanoCategory = 1;
        public int forcedCategory = 0;

        public FloatRange GetTrueConditionDuration => durationDays * Mashed_Ashlands_ModSettings.VolcanoConditionDurationMultiplier;

        public FloatRange GetTrueGraceDuration => graceDaysAfter * Mashed_Ashlands_ModSettings.VolcanoConditionGraceMultiplier;
    }
}

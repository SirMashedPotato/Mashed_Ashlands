﻿using RimWorld;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
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
        public IntRange duration;
        public IntRange gracePeriodAfter;
        public float weight = 1f;
        public bool sendLetter = false;
        public bool sendEndMessage = false;
        public bool countAsIncident = false;
        public bool randomCategory = false;
    }
}
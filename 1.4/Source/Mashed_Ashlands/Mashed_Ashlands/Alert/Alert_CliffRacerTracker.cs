﻿using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class Alert_CliffRacerTracker : Alert
    {
        public Alert_CliffRacerTracker()
        {
            defaultLabel = "Mashed_Ashlands_AlertCliffRacerTracker".Translate();
            defaultPriority = AlertPriority.Medium;
        }

        public override AlertReport GetReport()
        {
            return Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction 
                && Mashed_Ashlands_ModSettings.CliffRacerEnableTracker
                && !CliffRacerTrackerUtility.ExtinctionReached()
                ? AlertReport.Active : AlertReport.Inactive;
        }

        public override TaggedString GetExplanation()
        {
            return "Mashed_Ashlands_AlertCliffRacerTracker_Description".Translate(CliffRacerTrackerUtility.WildPopulation().ToString("N0"));
        }
    }
}

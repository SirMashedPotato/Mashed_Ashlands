using System;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsPage_Incidents
    {
        private static Vector2 scrollPosition = Vector2.zero;

        public static void DoSettingsPage(Rect mainRect, Mashed_Ashlands_ModSettings settings)
        {
            ///Readying listing standard
            Rect scrollRect = mainRect.ContractedBy(5f);
            Rect innerRect = new Rect(0f, 0f, mainRect.width - 30, mainRect.height * 1.8f);
            Widgets.BeginScrollView(scrollRect, ref scrollPosition, innerRect, true);

            innerRect = innerRect.ContractedBy(20f);

            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            ///Settings

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize".Translate(), ref settings.Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize, "Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_VolcanoMaxAffectedArea".Translate(settings.Mashed_Ashlands_VolcanoMaxAffectedArea), -1, "Mashed_Ashlands_VolcanoMaxAffectedArea_Tooltip".Translate());
            settings.Mashed_Ashlands_VolcanoMaxAffectedArea = (int)listing_Standard.Slider(settings.Mashed_Ashlands_VolcanoMaxAffectedArea, 1, 200);

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoEnablePermanentConditions".Translate(), ref settings.Mashed_Ashlands_VolcanoEnablePermanentConditions);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoEnableRandomConditions".Translate(), ref settings.Mashed_Ashlands_VolcanoEnableRandomConditions);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoOnlyLetterIfInRadius".Translate(), ref settings.Mashed_Ashlands_VolcanoOnlyLetterIfInRadius);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_VolcanoConditionDurationMultiplier".Translate(settings.Mashed_Ashlands_VolcanoConditionDurationMultiplier * 100), -1);
            settings.Mashed_Ashlands_VolcanoConditionDurationMultiplier = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_VolcanoConditionDurationMultiplier, 0.5f, 10f) * 2) / 2;

            listing_Standard.Label("Mashed_Ashlands_VolcanoConditionGraceMultiplier".Translate(settings.Mashed_Ashlands_VolcanoConditionGraceMultiplier * 100), -1);
            settings.Mashed_Ashlands_VolcanoConditionGraceMultiplier = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_VolcanoConditionGraceMultiplier, 0f, 10f) * 2) / 2;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoEnableCategoryChange".Translate(settings.Mashed_Ashlands_IncidentsForCategoryChange), ref settings.Mashed_Ashlands_VolcanoEnableCategoryChange, "Mashed_Ashlands_VolcanoEnableCategoryChange_Description".Translate(settings.Mashed_Ashlands_IncidentsForCategoryChange));
            listing_Standard.Gap();
            settings.Mashed_Ashlands_IncidentsForCategoryChange = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_IncidentsForCategoryChange, 1, 50));

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableExtinction".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableExtinction, "Mashed_Ashlands_CliffRacerEnableExtinction_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableTracker".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableTracker);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_CliffRacerWildPopulation".Translate(settings.Mashed_Ashlands_CliffRacerWildPopulation.ToString("N0")), -1f, "Mashed_Ashlands_CliffRacerWildPopulation_Tooltip".Translate());
            settings.Mashed_Ashlands_CliffRacerWildPopulation = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerWildPopulation, 0, 1000000) / 1000) * 1000;

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableReturn".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableReturn, "Mashed_Ashlands_CliffRacerEnableReturn_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_CliffRacerEnableReturnThreshold".Translate(settings.Mashed_Ashlands_CliffRacerEnableReturnThreshold.ToString("N0")));
            settings.Mashed_Ashlands_CliffRacerEnableReturnThreshold = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerEnableReturnThreshold, 10, 10000) / 10) * 10;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableSwarm".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableSwarm);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_CliffRacerSwarmMinSize".Translate(settings.Mashed_Ashlands_CliffRacerSwarmMinSize));
            settings.Mashed_Ashlands_CliffRacerSwarmMinSize = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerSwarmMinSize, 1, settings.Mashed_Ashlands_CliffRacerSwarmMaxSize));

            listing_Standard.Label("Mashed_Ashlands_CliffRacerSwarmMaxSize".Translate(settings.Mashed_Ashlands_CliffRacerSwarmMaxSize));
            settings.Mashed_Ashlands_CliffRacerSwarmMaxSize = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerSwarmMaxSize, settings.Mashed_Ashlands_CliffRacerSwarmMinSize, 200));

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_CliffRacerMutantChance".Translate(settings.Mashed_Ashlands_CliffRacerMutantChance * 100), -1);
            settings.Mashed_Ashlands_CliffRacerMutantChance = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerMutantChance, 0f, 1f) * 20) / 20;

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}

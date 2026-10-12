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
            Rect innerRect = new Rect(0f, 0f, mainRect.width - 30, mainRect.height - 10);
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

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableAshRaids".Translate(), ref settings.Mashed_Ashlands_EnableAshRaids);
            listing_Standard.Gap();

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}

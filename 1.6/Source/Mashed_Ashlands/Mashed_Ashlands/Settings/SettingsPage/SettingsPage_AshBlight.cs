using System;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsPage_AshBlight
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
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshBlightCanSpread".Translate(), ref settings.Mashed_Ashlands_AshBlightCanSpread);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshBlightCanSpreadToPlants".Translate(), ref settings.Mashed_Ashlands_AshBlightCanSpreadToPlants);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshBlightWandersIn".Translate(), ref settings.Mashed_Ashlands_AshBlightWandersIn);
            listing_Standard.Gap();


            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormCaravanAmbush".Translate(), ref settings.Mashed_Ashlands_BlightStormCaravanAmbush);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightAnimals".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightAnimals);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightPlayerAnimals".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightPlayerAnimals);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightNonPlayerAnimals".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightNonPlayerAnimals);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightPlants".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightPlants);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightWildPlants".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightWildPlants);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_BlightStormBlightPlantsNumber".Translate(settings.Mashed_Ashlands_BlightStormBlightPlantsNumber), -1);
            settings.Mashed_Ashlands_BlightStormBlightPlantsNumber = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_BlightStormBlightPlantsNumber, 1, 50));

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}


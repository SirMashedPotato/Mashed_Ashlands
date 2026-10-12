using System;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsPage_General
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

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableSettingBeforeWorldGen".Translate(), ref settings.Mashed_Ashlands_EnableSettingBeforeWorldGen);
            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BaseAshResistance".Translate(), ref settings.Mashed_Ashlands_BaseAshResistance);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_BaseAshResistanceValue".Translate(settings.Mashed_Ashlands_BaseAshResistanceValue * 100), -1);
            settings.Mashed_Ashlands_BaseAshResistanceValue = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_BaseAshResistanceValue, 0.05f, 1f) * 20) / 20;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_OnlySowOnAsh".Translate(), ref settings.Mashed_Ashlands_OnlySowOnAsh);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_FlowerFeeding".Translate(), ref settings.Mashed_Ashlands_FlowerFeeding);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_ScampInsulting".Translate(), ref settings.Mashed_Ashlands_ScampInsulting);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshcanoJoy".Translate(), ref settings.Mashed_Ashlands_AshcanoJoy);
            listing_Standard.Gap();
            
            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}

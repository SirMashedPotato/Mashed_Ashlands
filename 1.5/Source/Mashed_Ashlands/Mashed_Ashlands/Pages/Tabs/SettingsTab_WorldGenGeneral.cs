﻿using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsTab_WorldGenGeneral
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
            listing_Standard.Label("Mashed_Ashlands_PagePreWorldGen1".Translate());
            listing_Standard.Label("Mashed_Ashlands_PagePreWorldGen2".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            SettingsPage_WorldGen.DoSettingsGeneral(ref listing_Standard, settings);

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}
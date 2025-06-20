using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsTab_WorldGenDormant
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
            SettingsPage_WorldGen.DoSettingsDormant(ref listing_Standard, settings);

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}

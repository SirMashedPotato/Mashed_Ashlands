using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsPage_Biome
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

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableColumnarBasalt".Translate(), ref settings.Mashed_Ashlands_EnableColumnarBasalt, "Mashed_Ashlands_EnableColumnarBasalt_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableCavePlants".Translate(), ref settings.Mashed_Ashlands_EnableCavePlants);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableExtraGeysers".Translate(), ref settings.Mashed_Ashlands_EnableExtraGeysers);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableFetcherflyHives".Translate(), ref settings.Mashed_Ashlands_EnableFetcherflyHives);
            listing_Standard.Gap();

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}

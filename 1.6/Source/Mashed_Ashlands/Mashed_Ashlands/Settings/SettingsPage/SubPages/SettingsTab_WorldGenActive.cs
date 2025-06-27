using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsTab_WorldGenActive
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
            DoSettings(ref listing_Standard, settings);

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }

        public static void DoSettings(ref Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableActiveVolcano".Translate(), ref settings.Mashed_Ashlands_EnableActiveVolcano, "Mashed_Ashlands_EnableActiveVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_NumberOfActiveVolcano".Translate(settings.Mashed_Ashlands_NumberOfActiveVolcano));
            settings.Mashed_Ashlands_NumberOfActiveVolcano = (int)listing_Standard.Slider(settings.Mashed_Ashlands_NumberOfActiveVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicAshlands, "Mashed_Ashlands_BaseBiome_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicBadlandsAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicBadlandsAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands);
            listing_Standard.Gap();

            /*
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicCoralCoastAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicCoralCoastAshlands);
            listing_Standard.Gap();
            */
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands);
            listing_Standard.Gap();
        }
    }
}

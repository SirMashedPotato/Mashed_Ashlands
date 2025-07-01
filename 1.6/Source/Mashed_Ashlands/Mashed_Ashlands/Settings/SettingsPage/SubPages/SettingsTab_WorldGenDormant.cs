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
            DoSettings(ref listing_Standard, settings);

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }

        public static void DoSettings(ref Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableDormantVolcano".Translate(), ref settings.Mashed_Ashlands_EnableDormantVolcano, "Mashed_Ashlands_EnableDormantVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_NumberOfDormantVolcano".Translate(settings.Mashed_Ashlands_NumberOfDormantVolcano));
            settings.Mashed_Ashlands_NumberOfDormantVolcano = (int)listing_Standard.Slider(settings.Mashed_Ashlands_NumberOfDormantVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableStandardAshlands".Translate(), ref settings.Mashed_Ashlands_EnableStandardAshlands, "Mashed_Ashlands_BaseBiome_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableDustplainAshlands".Translate(), ref settings.Mashed_Ashlands_EnableDustplainAshlands);
            listing_Standard.Gap();
            /*
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableCoralCoastAshlands".Translate(), ref settings.Mashed_Ashlands_EnableCoralCoastAshlands);
            listing_Standard.Gap();
            */
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableGrazelandAshlands".Translate(), ref settings.Mashed_Ashlands_EnableGrazelandAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableHighlandAshlands".Translate(), ref settings.Mashed_Ashlands_EnableHighlandAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableSwampAshlands".Translate(), ref settings.Mashed_Ashlands_EnableSwampAshlands);
            listing_Standard.Gap();
        }
    }
}

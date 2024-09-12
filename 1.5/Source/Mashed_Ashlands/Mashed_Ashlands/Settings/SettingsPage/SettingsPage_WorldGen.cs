using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsPage_WorldGen
    {
        private static Vector2 scrollPosition = Vector2.zero;

        public static void DoSettingsPage(Rect mainRect, Mashed_Ashlands_ModSettings settings)
        {
            ///Readying listing standard
            Rect scrollRect = mainRect.ContractedBy(5f);
            Rect innerRect = new Rect(0f, 0f, mainRect.width - 30, mainRect.height * 2.4f);
            Widgets.BeginScrollView(scrollRect, ref scrollPosition, innerRect, true);

            innerRect = innerRect.ContractedBy(20f);

            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            ///General
            DoSettingsGeneral(ref listing_Standard, settings);
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Dormant and biomes
            DoSettingsDormant(ref listing_Standard, settings);
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Extinct and biomes
            DoSettingsExtinct(ref listing_Standard, settings);
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Active and biomes
            DoSettingsActive(ref listing_Standard, settings);
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Blighted and biomes
            DoSettingsBlighted(ref listing_Standard, settings);

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }

        public static void DoSettingsGeneral(ref Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableCoastalVolcano".Translate(), ref settings.Mashed_Ashlands_EnableCoastalVolcano, "Mashed_Ashlands_EnableCoastalVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableLegacyRegions".Translate(), ref settings.Mashed_Ashlands_EnableLegacyRegions, "Mashed_Ashlands_EnableLegacyRegions_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoScaleWithWorldSize".Translate(), ref settings.Mashed_Ashlands_VolcanoScaleWithWorldSize, "Mashed_Ashlands_VolcanoScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BiomeScaleWithWorldSize".Translate(), ref settings.Mashed_Ashlands_BiomeScaleWithWorldSize, "Mashed_Ashlands_BiomeScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_VolcanoMinDistance".Translate(settings.Mashed_Ashlands_VolcanoMinDistance));
            settings.Mashed_Ashlands_VolcanoMinDistance = (int)listing_Standard.Slider(settings.Mashed_Ashlands_VolcanoMinDistance, 1, 200);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_BiomesMaxDistance".Translate(settings.Mashed_Ashlands_BiomesMaxDistance));
            settings.Mashed_Ashlands_BiomesMaxDistance = (int)listing_Standard.Slider(settings.Mashed_Ashlands_BiomesMaxDistance, 10, 200);
            listing_Standard.Gap();
        }

        public static void DoSettingsDormant(ref Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
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

        public static void DoSettingsExtinct(ref Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableExtinctVolcano".Translate(), ref settings.Mashed_Ashlands_EnableExtinctVolcano, "Mashed_Ashlands_EnableExtinctVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_NumberOfExtinctVolcano".Translate(settings.Mashed_Ashlands_NumberOfExtinctVolcano));
            settings.Mashed_Ashlands_NumberOfExtinctVolcano = (int)listing_Standard.Slider(settings.Mashed_Ashlands_NumberOfExtinctVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableForestAshlands".Translate(), ref settings.Mashed_Ashlands_EnableForestAshlands, "Mashed_Ashlands_BaseBiome_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableMarshAshlands".Translate(), ref settings.Mashed_Ashlands_EnableMarshAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableMeadowAshlands".Translate(), ref settings.Mashed_Ashlands_EnableMeadowAshlands);
            listing_Standard.Gap();
        }

        public static void DoSettingsActive(ref Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableActiveVolcano".Translate(), ref settings.Mashed_Ashlands_EnableActiveVolcano, "Mashed_Ashlands_EnableActiveVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_NumberOfActiveVolcano".Translate(settings.Mashed_Ashlands_NumberOfActiveVolcano));
            settings.Mashed_Ashlands_NumberOfActiveVolcano = (int)listing_Standard.Slider(settings.Mashed_Ashlands_NumberOfActiveVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicAshlands, "Mashed_Ashlands_BaseBiome_Tooltip".Translate());
            listing_Standard.Gap();
            /*
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicCoralCoastAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicCoralCoastAshlands);
            listing_Standard.Gap();
            */
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableVolcanicBadlandsAshlands".Translate(), ref settings.Mashed_Ashlands_EnableVolcanicBadlandsAshlands);
            listing_Standard.Gap();
        }

        public static void DoSettingsBlighted(ref Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableBlightedVolcano".Translate(), ref settings.Mashed_Ashlands_EnableBlightedVolcano, "Mashed_Ashlands_EnableBlightedVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_NumberOfBlightedVolcano".Translate(settings.Mashed_Ashlands_NumberOfBlightedVolcano));
            settings.Mashed_Ashlands_NumberOfBlightedVolcano = (int)listing_Standard.Slider(settings.Mashed_Ashlands_NumberOfBlightedVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableBlightedAshlands".Translate(), ref settings.Mashed_Ashlands_EnableBlightedAshlands, "Mashed_Ashlands_BaseBiome_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableBlightedBogAshlands".Translate(), ref settings.Mashed_Ashlands_EnableBlightedBogAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands".Translate(), ref settings.Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands);
            listing_Standard.Gap();
        }
    }
}

using System;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsTab_WorldGenGeneral
    {
        private static Vector2 scrollPosition = Vector2.zero;

        public static void DoSettingsPage(Rect mainRect, Mashed_Ashlands_ModSettings settings, bool preWorldGen = false)
        {
            ///Readying listing standard
            Rect scrollRect = mainRect.ContractedBy(5f);
            Rect innerRect = new Rect(0f, 0f, mainRect.width - 30, mainRect.height - 10);
            Widgets.BeginScrollView(scrollRect, ref scrollPosition, innerRect, true);

            innerRect = innerRect.ContractedBy(20f);

            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            ///Settings
            if (preWorldGen)
            {
                listing_Standard.Label("Mashed_Ashlands_PagePreWorldGen1".Translate());
                listing_Standard.Label("Mashed_Ashlands_PagePreWorldGen2".Translate());
                listing_Standard.GapLine();
                listing_Standard.Gap();
            }

            if (ModsConfig.IsActive("oblitus.mylittleplanet"))
            {
                listing_Standard.Label("Mashed_Ashlands_PagePreWorldGenLittlePlanet".Translate().Colorize(Color.yellow));
                listing_Standard.GapLine();
                listing_Standard.Gap();
            }

            DoSettings(ref listing_Standard, settings);

            if (preWorldGen)
            {
                listing_Standard.GapLine();
                listing_Standard.Gap();

                listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableExtinction".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableExtinction, "Mashed_Ashlands_CliffRacerEnableExtinction_Tooltip".Translate());
                listing_Standard.Gap();

                listing_Standard.Label("Mashed_Ashlands_CliffRacerWildPopulation".Translate(settings.Mashed_Ashlands_CliffRacerWildPopulation.ToString("N0")), -1f, "Mashed_Ashlands_CliffRacerWildPopulation_Tooltip".Translate());
                settings.Mashed_Ashlands_CliffRacerWildPopulation = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerWildPopulation, 0, 1000000) / 1000) * 1000;
            }

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }

        public static void DoSettings(ref Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
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
    }
}

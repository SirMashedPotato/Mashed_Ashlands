using System;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsPage_OtherConditions
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

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_MiasmaAffectsCaravan".Translate(), ref settings.Mashed_Ashlands_MiasmaAffectsCaravan);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EarthquakeShake".Translate(), ref settings.Mashed_Ashlands_EarthquakeShake);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EarthquakeCollapseMountains".Translate(), ref settings.Mashed_Ashlands_EarthquakeCollapseMountains);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EarthquakeDamageBuildings".Translate(), ref settings.Mashed_Ashlands_EarthquakeDamageBuildings, "Mashed_Ashlands_EarthquakeDamageBuildings_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer".Translate(), ref settings.Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_EarthquakeDamageBuildingsChance".Translate(settings.Mashed_Ashlands_EarthquakeDamageBuildingsChance * 100), -1);
            settings.Mashed_Ashlands_EarthquakeDamageBuildingsChance = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_EarthquakeDamageBuildingsChance, 0.05f, 1f) * 20) / 20;

            listing_Standard.Label("Mashed_Ashlands_EarthquakeDamageBuildingsDamage".Translate(settings.Mashed_Ashlands_EarthquakeDamageBuildingsDamage), -1);
            settings.Mashed_Ashlands_EarthquakeDamageBuildingsDamage = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_EarthquakeDamageBuildingsDamage, 1, 50));

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}

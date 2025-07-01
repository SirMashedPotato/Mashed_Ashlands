using System;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsPage_AshStorm
    {
        private static Vector2 scrollPosition = Vector2.zero;

        public static void DoSettingsPage(Rect mainRect, Mashed_Ashlands_ModSettings settings)
        {
            ///Readying listing standard
            Rect scrollRect = mainRect.ContractedBy(5f);
            Rect innerRect = new Rect(0f, 0f, mainRect.width - 30, mainRect.height * 1.3f);
            Widgets.BeginScrollView(scrollRect, ref scrollPosition, innerRect, true);

            innerRect = innerRect.ContractedBy(20f);

            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            ///Settings

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshStormCauseBuildup".Translate(), ref settings.Mashed_Ashlands_AshStormCauseBuildup);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshStormAffectsCaravan".Translate(), ref settings.Mashed_Ashlands_AshStormAffectsCaravan);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_AshStormBuildupMult".Translate(settings.Mashed_Ashlands_AshStormBuildupMult * 100), -1);
            settings.Mashed_Ashlands_AshStormBuildupMult = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_AshStormBuildupMult, 0.05f, 5f) * 10) / 10;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshStormCauseBlinded".Translate(), ref settings.Mashed_Ashlands_AshStormCauseBlinded);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_AshStormBlindedChance".Translate(settings.Mashed_Ashlands_AshStormBlindedChance * 100), -1);
            settings.Mashed_Ashlands_AshStormBlindedChance = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_AshStormBlindedChance, 0.05f, 1f) * 20) / 20;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshStormCauseCloggedServo".Translate(), ref settings.Mashed_Ashlands_AshStormCauseCloggedServo);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_AshStormCloggedServoChance".Translate(settings.Mashed_Ashlands_AshStormCloggedServoChance * 100), -1);
            settings.Mashed_Ashlands_AshStormCloggedServoChance = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_AshStormCloggedServoChance, 0.05f, 1f) * 20) / 20;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshStormDamagePlants".Translate(), ref settings.Mashed_Ashlands_AshStormDamagePlants);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_AshStormAvgPlantDamage".Translate(settings.Mashed_Ashlands_AshStormAvgPlantDamage), -1);
            settings.Mashed_Ashlands_AshStormAvgPlantDamage = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_AshStormAvgPlantDamage, 1, 50));

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshStormDamageBuildings".Translate(), ref settings.Mashed_Ashlands_AshStormDamageBuildings);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshStormBreakdownBuildings".Translate(), ref settings.Mashed_Ashlands_AshStormBreakdownBuildings);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_AshStormBreakdownBuildingsChance".Translate(settings.Mashed_Ashlands_AshStormBreakdownBuildingsChance * 100), -1);
            settings.Mashed_Ashlands_AshStormBreakdownBuildingsChance = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_AshStormBreakdownBuildingsChance, 0.05f, 1f) * 20) / 20;

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}

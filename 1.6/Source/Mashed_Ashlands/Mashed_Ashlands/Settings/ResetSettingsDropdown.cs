using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    internal static class ResetSettingsDropdown
    {
        private static List<FloatMenuOption> resetSettingsOptions;

        public static List<FloatMenuOption> ResetSettingsOptions
        {
            get
            {
                if (resetSettingsOptions.NullOrEmpty())
                {
                    resetSettingsOptions = new List<FloatMenuOption>();

                    ///Reset all
                    FloatMenuOption item = new FloatMenuOption("Mashed_Ashlands_Reset".Translate(), delegate
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings();
                    });
                    resetSettingsOptions.Add(item);

                    ///Reset general
                    item = new FloatMenuOption("Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageGeneral".Translate()), delegate
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_General();
                    });
                    resetSettingsOptions.Add(item);

                    ///Reset world gen
                    item = new FloatMenuOption("Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageWorldGen".Translate()), delegate
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_WorldGen();
                    });
                    resetSettingsOptions.Add(item);

                    ///Reset biome gen
                    item = new FloatMenuOption("Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageBiome".Translate()), delegate
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_Biome();
                    });
                    resetSettingsOptions.Add(item);

                    ///Reset ash storm
                    item = new FloatMenuOption("Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageAshStorm".Translate()), delegate
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_AshStorm();
                    });
                    resetSettingsOptions.Add(item);

                    ///Reset ash blight
                    item = new FloatMenuOption("Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageAshBlight".Translate()), delegate
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_AshBlight();
                    });
                    resetSettingsOptions.Add(item);

                    ///Reset conditions
                    item = new FloatMenuOption("Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageOtherConditions".Translate()), delegate
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_OtherConditions();
                    });
                    resetSettingsOptions.Add(item);

                    ///Reset incidents
                    item = new FloatMenuOption("Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageIncident".Translate()), delegate
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_Incident();
                    });
                    resetSettingsOptions.Add(item);

                }
                return resetSettingsOptions;
            }
        }
    }
}

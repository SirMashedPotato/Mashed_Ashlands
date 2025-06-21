using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class Page_AshlandWorldGenSettings : Page
    {
        public override string PageTitle => "Mashed_Ashlands_ModName".Translate() + " " + "Mashed_Ashlands_PageWorldGen".Translate();

        private enum SettingsTab : byte
        {
            General,
            Dormant,
            Extinct,
            Active,
            Blighted
        }

        private void ReadySettingsTabs()
        {
            tabs.Add(new TabRecord("Mashed_Ashlands_PageGeneral".Translate(), delegate
            {
                curTab = SettingsTab.General;
            }, () => curTab == SettingsTab.General));

            tabs.Add(new TabRecord(WorldObjectDefOf.Mashed_Ashlands_VolcanoDormant.label.CapitalizeFirst(), delegate
            {
                curTab = SettingsTab.Dormant;
            }, () => curTab == SettingsTab.Dormant));

            tabs.Add(new TabRecord(WorldObjectDefOf.Mashed_Ashlands_VolcanoExtinct.label.CapitalizeFirst(), delegate
            {
                curTab = SettingsTab.Extinct;
            }, () => curTab == SettingsTab.Extinct));

            tabs.Add(new TabRecord(WorldObjectDefOf.Mashed_Ashlands_VolcanoActive.label.CapitalizeFirst(), delegate
            {
                curTab = SettingsTab.Active;
            }, () => curTab == SettingsTab.Active));

            tabs.Add(new TabRecord(WorldObjectDefOf.Mashed_Ashlands_VolcanoBlighted.label.CapitalizeFirst(), delegate
            {
                curTab = SettingsTab.Blighted;
            }, () => curTab == SettingsTab.Blighted));
        }

        private readonly List<TabRecord> tabs = new List<TabRecord>();
        private static SettingsTab curTab = SettingsTab.General;

        public override void DoWindowContents(Rect inRect)
        {
            DrawPageTitle(inRect);

            if (tabs.NullOrEmpty())
            {
                ReadySettingsTabs();
            }

            Rect mainRect = GetMainRect(inRect, 0f, false);
            mainRect.yMin += 45f;
            Widgets.DrawMenuSection(mainRect);
            TabDrawer.DrawTabs(mainRect, tabs);

            switch (curTab)
            {
                case SettingsTab.General:
                    SettingsTab_WorldGenGeneral.DoSettingsPage(mainRect, Mashed_Ashlands_ModSettings.Instance);
                    break;
                case SettingsTab.Dormant:
                    SettingsTab_WorldGenDormant.DoSettingsPage(mainRect, Mashed_Ashlands_ModSettings.Instance);
                    break;
                case SettingsTab.Extinct:
                    SettingsTab_WorldGenExtinct.DoSettingsPage(mainRect, Mashed_Ashlands_ModSettings.Instance);
                    break;
                case SettingsTab.Active:
                    SettingsTab_WorldGenActive.DoSettingsPage(mainRect, Mashed_Ashlands_ModSettings.Instance);
                    break;
                case SettingsTab.Blighted:
                    SettingsTab_WorldGenBlighted.DoSettingsPage(mainRect, Mashed_Ashlands_ModSettings.Instance);
                    break;
            }

            DoBottomButtons(inRect, null, null, null, true, true);
            DoResetButton(inRect);
        }

        public void DoResetButton(Rect inRect)
        {
            if (Widgets.ButtonText(new Rect(inRect.x + inRect.width / 2f - BottomButSize.x / 2f, inRect.y + inRect.height - 38f, BottomButSize.x, BottomButSize.y),
                "ResetAll".Translate()))
            {
                Mashed_Ashlands_ModSettings.ResetSettings_WorldGen();
            }
        }
    }
}

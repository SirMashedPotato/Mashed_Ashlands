using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    internal static class SettingsPage_WorldGen
    {
        private static Vector2 scrollPosition = Vector2.zero;

        private enum SettingsTab : byte
        {
            General,
            Dormant,
            Extinct,
            Active,
            Blighted
        }

        private static void ReadySettingsTabs()
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

        private static readonly List<TabRecord> tabs = new List<TabRecord>();
        private static SettingsTab curTab = SettingsTab.General;

        public static void DoSettingsPage(Rect mainRect, Mashed_Ashlands_ModSettings settings, bool preWorldGen = false)
        {
            ///Readying tabs
            if (tabs.NullOrEmpty())
            {
                ReadySettingsTabs();
            }
            Rect subRect = mainRect;
            if (!preWorldGen)
            {
                subRect.yMin += 45f;
            }
            Widgets.DrawMenuSection(subRect);
            TabDrawer.DrawTabs(subRect, tabs);

            ///Readying listing standard
            Rect scrollRect = subRect.ContractedBy(5f);
            Rect innerRect = new Rect(0f, 0f, subRect.width - 30, subRect.height - 10);
            Widgets.BeginScrollView(scrollRect, ref scrollPosition, innerRect, true);

            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            switch (curTab)
            {
                case SettingsTab.General:
                    SettingsTab_WorldGenGeneral.DoSettingsPage(innerRect, settings, preWorldGen);
                    break;
                case SettingsTab.Dormant:
                    SettingsTab_WorldGenDormant.DoSettingsPage(innerRect, settings);
                    break;
                case SettingsTab.Extinct:
                    SettingsTab_WorldGenExtinct.DoSettingsPage(innerRect, settings);
                    break;
                case SettingsTab.Active:
                    SettingsTab_WorldGenActive.DoSettingsPage(innerRect, settings);
                    break;
                case SettingsTab.Blighted:
                    SettingsTab_WorldGenBlighted.DoSettingsPage(innerRect, settings);
                    break;
            }

            ///Ending
            listing_Standard.End();
            Widgets.EndScrollView();
        }
    }
}

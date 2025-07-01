using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class Mashed_Ashlands_Mod : Mod
    {
        readonly Mashed_Ashlands_ModSettings settings;

        public Mashed_Ashlands_Mod(ModContentPack contentPack) : base(contentPack)
        {
            settings = GetSettings<Mashed_Ashlands_ModSettings>();
            Log.Message("[Mashed's Ashlands] version " + Content.ModMetaData.ModVersion);
        }

        private enum SettingsTab : byte
        {
            General,
            WorldGen,
            MapGen,
            AshStorm,
            AshBlight,
            Conditions,
            Incidents,
            CliffRacer
        }

        private void ReadySettingsTabs()
        {
            tabs.Add(new TabRecord("Mashed_Ashlands_PageGeneral".Translate(), delegate
            {
                curTab = SettingsTab.General;
            }, () => curTab == SettingsTab.General));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageWorldGen".Translate(), delegate
            {
                curTab = SettingsTab.WorldGen;
            }, () => curTab == SettingsTab.WorldGen));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageBiome".Translate(), delegate
            {
                curTab = SettingsTab.MapGen;
            }, () => curTab == SettingsTab.MapGen));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageAshStorm".Translate(), delegate
            {
                curTab = SettingsTab.AshStorm;
            }, () => curTab == SettingsTab.AshStorm));

            tabs.Add(new TabRecord("Mashed_Ashlands_PageAshBlight".Translate(), delegate
            {
                curTab = SettingsTab.AshBlight;
            }, () => curTab == SettingsTab.AshBlight));

            tabs.Add(new TabRecord("Mashed_Ashlands_PageOtherConditions".Translate(), delegate
            {
                curTab = SettingsTab.Conditions;
            }, () => curTab == SettingsTab.Conditions));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageIncident".Translate(), delegate
            {
                curTab = SettingsTab.Incidents;
            }, () => curTab == SettingsTab.Incidents));

            tabs.Add(new TabRecord("Mashed_Ashlands_PageCliffRacer".Translate(), delegate
            {
                curTab = SettingsTab.CliffRacer;
            }, () => curTab == SettingsTab.CliffRacer));
        }

        private readonly List<TabRecord> tabs = new List<TabRecord>();

        public override string SettingsCategory() => "Mashed_Ashlands_ModName".Translate();
        private static SettingsTab curTab = SettingsTab.General;

        /// <summary>
        /// 
        /// </summary>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            if (tabs.NullOrEmpty())
            {
                ReadySettingsTabs();
            }

            Rect mainRect = inRect;
            mainRect.yMin += 45f;
            Widgets.DrawMenuSection(mainRect);
            TabDrawer.DrawTabs(mainRect, tabs);

            switch (curTab)
            {
                case SettingsTab.General:
                    SettingsPage_General.DoSettingsPage(mainRect, settings);
                    break;
                case SettingsTab.WorldGen:
                    SettingsPage_WorldGen.DoSettingsPage(mainRect, settings);
                    break;
                case SettingsTab.MapGen:
                    SettingsPage_Biome.DoSettingsPage(mainRect, settings);
                    break;
                case SettingsTab.AshStorm:
                    SettingsPage_AshStorm.DoSettingsPage(mainRect, settings);
                    break;
                case SettingsTab.AshBlight:
                    SettingsPage_AshBlight.DoSettingsPage(mainRect, settings);
                    break;
                case SettingsTab.Conditions:
                    SettingsPage_OtherConditions.DoSettingsPage(mainRect, settings);
                    break;
                case SettingsTab.Incidents:
                    SettingsPage_Incidents.DoSettingsPage(mainRect, settings);
                    break;
                case SettingsTab.CliffRacer:
                    SettingsPage_CliffRacer.DoSettingsPage(mainRect, settings);
                    break;
            }

            if (Widgets.ButtonText(new Rect(inRect.x + inRect.width - Window.CloseButSize.x, inRect.y + inRect.height + 2f, Window.CloseButSize.x, Window.CloseButSize.y), "ResetAll".Translate()))
            {
                FloatMenu floatMenu = new FloatMenu(ResetSettingsDropdown.ResetSettingsOptions);
                Find.WindowStack.Add(floatMenu);
            }

            base.DoSettingsWindowContents(inRect);
        }
    }
}

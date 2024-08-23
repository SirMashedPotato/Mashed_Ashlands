using System;
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
            Conditions,
            Incidents
        }

        private void ReadySettingsTabs()
        {
            tabs.Add(new TabRecord("Mashed_Ashlands_PageGeneral".Translate(), delegate
            {
                curTab = SettingsTab.General;
                scrollPosition = Vector2.zero;
            }, () => curTab == SettingsTab.General));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageWorldGen".Translate(), delegate
            {
                curTab = SettingsTab.WorldGen;
                scrollPosition = Vector2.zero;
            }, () => curTab == SettingsTab.WorldGen));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageBiome".Translate(), delegate
            {
                curTab = SettingsTab.MapGen;
                scrollPosition = Vector2.zero;
            }, () => curTab == SettingsTab.MapGen));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageAshStorm".Translate(), delegate
            {
                curTab = SettingsTab.AshStorm;
                scrollPosition = Vector2.zero;
            }, () => curTab == SettingsTab.AshStorm));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageOtherConditions".Translate(), delegate
            {
                curTab = SettingsTab.Conditions;
                scrollPosition = Vector2.zero;
            }, () => curTab == SettingsTab.Conditions));
            
            tabs.Add(new TabRecord("Mashed_Ashlands_PageIncident".Translate(), delegate
            {
                curTab = SettingsTab.Incidents;
                scrollPosition = Vector2.zero;
            }, () => curTab == SettingsTab.Incidents));
        }

        private readonly List<TabRecord> tabs = new List<TabRecord>();

        public override string SettingsCategory() => "Mashed_Ashlands_ModName".Translate();
        private static SettingsTab curTab = SettingsTab.General;
        private static Vector2 scrollPosition = Vector2.zero;

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
                    SettingsPage_General.DoSettingsPage(mainRect, ref scrollPosition, settings);
                    break;
                    /*
                case SettingsTab.WorldGen:
                    listing_Standard = SettingsPage_WorldGen(listing_Standard, settings);
                    break;
                case SettingsTab.MapGen:
                    listing_Standard = SettingsPage_Biome(listing_Standard, settings);
                    break;
                case SettingsTab.AshStorm:
                    listing_Standard = SettingsPage_AshStorm(listing_Standard, settings);
                    break;
                case SettingsTab.Conditions:
                    listing_Standard = SettingsPage_OtherConditions(listing_Standard, settings);
                    break;
                case SettingsTab.Incidents:
                    listing_Standard = SettingsPage_Incidents(listing_Standard, settings);
                    break;
                    */
            }

            if (Widgets.ButtonText(new Rect(inRect.x + inRect.width - Window.CloseButSize.x, inRect.y + inRect.height + 2f, Window.CloseButSize.x, Window.CloseButSize.y), "ResetAll".Translate()))
            {
                FloatMenu floatMenu = new FloatMenu(ResetSettingsDropdown.ResetSettingsOptions);
                Find.WindowStack.Add(floatMenu);
            }

            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Listing_Standard SettingsPage_WorldGen(Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings,  bool alternateHeader = false)
        {
            if (alternateHeader)
            {
                listing_Standard.Label("Mashed_Ashlands_PagePreWorldGen1".Translate());
                listing_Standard.Label("Mashed_Ashlands_PagePreWorldGen2".Translate());
                listing_Standard.GapLine();
                listing_Standard.Gap();
            }
            else
            {
                listing_Standard.Label("Mashed_Ashlands_PageWorldGen".Translate());
                listing_Standard.GapLine();
                listing_Standard.Gap();

                listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableSettingBeforeWorldGen".Translate(), ref settings.Mashed_Ashlands_EnableSettingBeforeWorldGen);
                listing_Standard.GapLine();
                listing_Standard.Gap();
            }

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

            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Dormant and biomes
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

            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Extinct and biomes
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

            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Active and biomes
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

            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Blighted and biomes
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableBlightedVolcano".Translate(), ref settings.Mashed_Ashlands_EnableBlightedVolcano, "Mashed_Ashlands_EnableBlightedVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_NumberOfBlightedVolcano".Translate(settings.Mashed_Ashlands_NumberOfBlightedVolcano));
            settings.Mashed_Ashlands_NumberOfBlightedVolcano = (int)listing_Standard.Slider(settings.Mashed_Ashlands_NumberOfBlightedVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableBlightedAshlands".Translate(), ref settings.Mashed_Ashlands_EnableBlightedAshlands, "Mashed_Ashlands_BaseBiome_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableBlightedBogAshlands".Translate(), ref settings.Mashed_Ashlands_EnableBlightedBogAshlands);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsPage_Incidents(Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.Label("Mashed_Ashlands_PageIncident".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize".Translate(), ref settings.Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize, "Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_VolcanoMaxAffectedArea".Translate(settings.Mashed_Ashlands_VolcanoMaxAffectedArea), -1, "Mashed_Ashlands_VolcanoMaxAffectedArea_Tooltip".Translate());
            settings.Mashed_Ashlands_VolcanoMaxAffectedArea = (int)listing_Standard.Slider(settings.Mashed_Ashlands_VolcanoMaxAffectedArea, 1, 200);

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoEnablePermanentConditions".Translate(), ref settings.Mashed_Ashlands_VolcanoEnablePermanentConditions);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoEnableRandomConditions".Translate(), ref settings.Mashed_Ashlands_VolcanoEnableRandomConditions);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoOnlyLetterIfInRadius".Translate(), ref settings.Mashed_Ashlands_VolcanoOnlyLetterIfInRadius);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_VolcanoConditionDurationMultiplier".Translate(settings.Mashed_Ashlands_VolcanoConditionDurationMultiplier * 100), -1);
            settings.Mashed_Ashlands_VolcanoConditionDurationMultiplier = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_VolcanoConditionDurationMultiplier, 0.5f, 10f) * 2) / 2;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoEnableCategoryChange".Translate(settings.Mashed_Ashlands_IncidentsForCategoryChange), ref settings.Mashed_Ashlands_VolcanoEnableCategoryChange, "Mashed_Ashlands_VolcanoEnableCategoryChange_Description".Translate(settings.Mashed_Ashlands_IncidentsForCategoryChange));
            listing_Standard.Gap();
            settings.Mashed_Ashlands_IncidentsForCategoryChange = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_IncidentsForCategoryChange, 1, 50));

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableExtinction".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableExtinction, "Mashed_Ashlands_CliffRacerEnableExtinction_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableTracker".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableTracker);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_CliffRacerWildPopulation".Translate(settings.Mashed_Ashlands_CliffRacerWildPopulation.ToString("N0")), -1f, "Mashed_Ashlands_CliffRacerWildPopulation_Tooltip".Translate());
            settings.Mashed_Ashlands_CliffRacerWildPopulation = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerWildPopulation, 0, 1000000) / 1000) * 1000;

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableReturn".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableReturn, "Mashed_Ashlands_CliffRacerEnableReturn_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_CliffRacerEnableReturnThreshold".Translate(settings.Mashed_Ashlands_CliffRacerEnableReturnThreshold.ToString("N0")));
            settings.Mashed_Ashlands_CliffRacerEnableReturnThreshold = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerEnableReturnThreshold, 10, 10000) / 10) * 10;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_CliffRacerEnableSwarm".Translate(), ref settings.Mashed_Ashlands_CliffRacerEnableSwarm);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_CliffRacerSwarmMinSize".Translate(settings.Mashed_Ashlands_CliffRacerSwarmMinSize));
            settings.Mashed_Ashlands_CliffRacerSwarmMinSize = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerSwarmMinSize, 1, settings.Mashed_Ashlands_CliffRacerSwarmMaxSize));

            listing_Standard.Label("Mashed_Ashlands_CliffRacerSwarmMaxSize".Translate(settings.Mashed_Ashlands_CliffRacerSwarmMaxSize));
            settings.Mashed_Ashlands_CliffRacerSwarmMaxSize = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerSwarmMaxSize, settings.Mashed_Ashlands_CliffRacerSwarmMinSize, 200));

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_CliffRacerMutantChance".Translate(settings.Mashed_Ashlands_CliffRacerMutantChance * 100), -1);
            settings.Mashed_Ashlands_CliffRacerMutantChance = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_CliffRacerMutantChance, 0f, 1f) * 20) / 20;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsPage_AshStorm(Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.Label("Mashed_Ashlands_PageAshStorm".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

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

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightAnimals".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightAnimals);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightPlayerAnimals".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightPlayerAnimals);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightNonPlayerAnimals".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightNonPlayerAnimals);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightPlants".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightPlants);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BlightStormBlightWildPlants".Translate(), ref settings.Mashed_Ashlands_BlightStormBlightWildPlants);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_BlightStormBlightPlantsNumber".Translate(settings.Mashed_Ashlands_BlightStormBlightPlantsNumber), -1);
            settings.Mashed_Ashlands_BlightStormBlightPlantsNumber = (int)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_BlightStormBlightPlantsNumber, 1, 50));

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsPage_OtherConditions(Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.Label("Mashed_Ashlands_PageOtherConditions".Translate());
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

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsPage_Biome(Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.Label("Mashed_Ashlands_PageBiome".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableColumnarBasalt".Translate(), ref settings.Mashed_Ashlands_EnableColumnarBasalt, "Mashed_Ashlands_EnableColumnarBasalt_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableCavePlants".Translate(), ref settings.Mashed_Ashlands_EnableCavePlants);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableExtraGeysers".Translate(), ref settings.Mashed_Ashlands_EnableExtraGeysers);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableFetcherflyHives".Translate(), ref settings.Mashed_Ashlands_EnableFetcherflyHives);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }
    }
}

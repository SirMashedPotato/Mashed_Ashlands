using System;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class Mashed_Ashlands_Mod : Mod
    {
        Mashed_Ashlands_ModSettings settings;

        public Mashed_Ashlands_Mod(ModContentPack contentPack) : base(contentPack)
        {
            settings = GetSettings<Mashed_Ashlands_ModSettings>();
            Log.Message("[Mashed's Ashlands] version " + Content.ModMetaData.ModVersion);
        }

        public override string SettingsCategory() => "Mashed_Ashlands_ModName".Translate();
        private int page = 0;
        private static Vector2 scrollPosition = Vector2.zero;

        /// <summary>
        /// 
        /// </summary>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            float firstColumnWidth = (inRect.width - Listing.ColumnSpacing) * 3.5f / 5f;
            float secondColumnWidth = inRect.width - Listing.ColumnSpacing - firstColumnWidth;

            Rect outerRect = new Rect(inRect.x, inRect.y, firstColumnWidth, inRect.height);
            Rect innerRect = new Rect(0f, 0f, firstColumnWidth - 24f, inRect.height * 2.5f);
            Widgets.BeginScrollView(outerRect, ref scrollPosition, innerRect, true);

            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            //get page
            switch (page)
            {
                case 1:
                    listing_Standard = SettingsPage_WorldGen(listing_Standard, settings);
                    break;
                case 2:
                    listing_Standard = SettingsPage_Biome(listing_Standard, settings);
                    break;
                case 3:
                    listing_Standard = SettingsPage_AshStorm(listing_Standard, settings);
                    break;
                case 4:
                    listing_Standard = SettingsPage_Incidents(listing_Standard, settings);
                    break;
               

                default:
                    listing_Standard = SettingsPage_General(listing_Standard, settings);
                    break;
            }

            listing_Standard.End();
            Widgets.EndScrollView();
            base.DoSettingsWindowContents(inRect);

            outerRect.x += firstColumnWidth + Listing.ColumnSpacing;
            outerRect.width = secondColumnWidth;

            listing_Standard = new Listing_Standard();
            listing_Standard.Begin(outerRect);
            SettingsButtons(listing_Standard);
            listing_Standard.End();
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsButtons(Listing_Standard listing_Standard)
        {
            listing_Standard.Gap();

            Rect rectPageGeneral = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageGeneral, "Mashed_Ashlands_PageGeneral".Translate());
            if (Widgets.ButtonText(rectPageGeneral, "Mashed_Ashlands_PageGeneral".Translate(), true, true, true))
            {
                page = 0;
            }
            listing_Standard.Gap();

            Rect rectPageWorldGen = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageWorldGen, "Mashed_Ashlands_PageWorldGen".Translate());
            if (Widgets.ButtonText(rectPageWorldGen, "Mashed_Ashlands_PageWorldGen".Translate(), true, true, true))
            {
                page = 1;
            }
            listing_Standard.Gap();

            Rect rectPageBiome = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageBiome, "Mashed_Ashlands_PageBiome".Translate());
            if (Widgets.ButtonText(rectPageBiome, "Mashed_Ashlands_PageBiome".Translate(), true, true, true))
            {
                page = 2;
            }
            listing_Standard.Gap();

            Rect rectPageAshStorm = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageAshStorm, "Mashed_Ashlands_PageAshStorm".Translate());
            if (Widgets.ButtonText(rectPageAshStorm, "Mashed_Ashlands_PageAshStorm".Translate(), true, true, true))
            {
                page = 3;
            }
            listing_Standard.Gap();

            Rect rectPageIncident = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageIncident, "Mashed_Ashlands_PageIncident".Translate());
            if (Widgets.ButtonText(rectPageIncident, "Mashed_Ashlands_PageIncident".Translate(), true, true, true))
            {
                page = 4;
            }
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "Mashed_Ashlands_Reset".Translate());
            if (Widgets.ButtonText(rectDefault, "Mashed_Ashlands_Reset".Translate(), true, true, true))
            {
                Mashed_Ashlands_ModSettings.ResetSettings();
            }
            listing_Standard.Gap();
            ResetButtonForPage(listing_Standard);

            return listing_Standard;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetButtonForPage(Listing_Standard listing_Standard)
        {
            Rect rectDefault = listing_Standard.GetRect(30f);
            switch (page)
            {
                case 0:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageGeneral".Translate()));
                    if (Widgets.ButtonText(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageGeneral".Translate()), true, true, true))
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_General();
                    }
                    break;

                case 1:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageWorldGen".Translate()));
                    if (Widgets.ButtonText(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageWorldGen".Translate()), true, true, true))
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_WorldGen();
                    }
                    break;

                case 2:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageBiome".Translate()));
                    if (Widgets.ButtonText(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageBiome".Translate()), true, true, true))
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_Biome();
                    }
                    break;

                case 3:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageAshStorm".Translate()));
                    if (Widgets.ButtonText(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageAshStorm".Translate()), true, true, true))
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_AshStorm();
                    }
                    break;

                case 4:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageIncident".Translate()));
                    if (Widgets.ButtonText(rectDefault, "Mashed_Ashlands_ResetPage".Translate("Mashed_Ashlands_PageIncident".Translate()), true, true, true))
                    {
                        Mashed_Ashlands_ModSettings.ResetSettings_Incident();
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsPage_General(Listing_Standard listing_Standard, Mashed_Ashlands_ModSettings settings)
        {
            listing_Standard.Label("Mashed_Ashlands_PageGeneral".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BaseAshResistance".Translate(), ref settings.Mashed_Ashlands_BaseAshResistance);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_BaseAshResistanceValue".Translate(settings.Mashed_Ashlands_BaseAshResistanceValue * 100), -1);
            settings.Mashed_Ashlands_BaseAshResistanceValue = (float)Math.Round(listing_Standard.Slider(settings.Mashed_Ashlands_BaseAshResistanceValue, 0.05f, 1f) * 20) / 20;

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_OnlySowOnAsh".Translate(), ref settings.Mashed_Ashlands_OnlySowOnAsh);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_FlowerFeeding".Translate(), ref settings.Mashed_Ashlands_FlowerFeeding);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_ScampInsulting".Translate(), ref settings.Mashed_Ashlands_ScampInsulting);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_AshcanoJoy".Translate(), ref settings.Mashed_Ashlands_AshcanoJoy);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
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

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_VolcanoScaleWithWorldSize".Translate(), ref settings.Mashed_Ashlands_VolcanoScaleWithWorldSize, "Mashed_Ashlands_VolcanoScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Mashed_Ashlands_BiomeScaleWithWorldSize".Translate(), ref settings.Mashed_Ashlands_BiomeScaleWithWorldSize, "Mashed_Ashlands_BiomeScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_VolcanoMinDistance".Translate(settings.Mashed_Ashlands_VolcanoMinDistance));
            settings.Mashed_Ashlands_VolcanoMinDistance = (int)listing_Standard.Slider(settings.Mashed_Ashlands_VolcanoMinDistance, 1, 200);
            listing_Standard.Gap();

            listing_Standard.Label("Mashed_Ashlands_BiomesMaxDistance".Translate(settings.Mashed_Ashlands_BiomesMaxDistance));
            settings.Mashed_Ashlands_BiomesMaxDistance = (int)listing_Standard.Slider(settings.Mashed_Ashlands_BiomesMaxDistance, 1, 200);
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
            /*
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableCoralCoastAshlands".Translate(), ref settings.Mashed_Ashlands_EnableCoralCoastAshlands);
            listing_Standard.Gap();
            */
            listing_Standard.CheckboxLabeled("Mashed_Ashlands_EnableGrazelandAshlands".Translate(), ref settings.Mashed_Ashlands_EnableGrazelandAshlands);
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

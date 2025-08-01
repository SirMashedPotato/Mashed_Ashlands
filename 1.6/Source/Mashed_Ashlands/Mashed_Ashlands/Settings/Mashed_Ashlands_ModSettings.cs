﻿using Verse;

namespace Mashed_Ashlands
{
    public class Mashed_Ashlands_ModSettings : ModSettings
    {
        public static Mashed_Ashlands_ModSettings Instance => _instance;

        private static Mashed_Ashlands_ModSettings _instance;

        /* ==========[GETTERS]========== */
        //general
        public static bool OnlySowOnAsh => _instance.Mashed_Ashlands_OnlySowOnAsh;
        public static bool BaseAshResistance => _instance.Mashed_Ashlands_BaseAshResistance;
        public static float BaseAshResistanceValue => _instance.Mashed_Ashlands_BaseAshResistanceValue;
        public static bool FlowerFeeding => _instance.Mashed_Ashlands_FlowerFeeding;
        public static bool ScampInsulting => _instance.Mashed_Ashlands_ScampInsulting;
        public static bool AshcanoJoy => _instance.Mashed_Ashlands_AshcanoJoy;

        //world gen
        public static bool EnableSettingBeforeWorldGen => _instance.Mashed_Ashlands_EnableSettingBeforeWorldGen;
        public static bool EnableDormantVolcano => _instance.Mashed_Ashlands_EnableDormantVolcano;
        public static int NumberOfDormantVolcano => _instance.Mashed_Ashlands_NumberOfDormantVolcano;
        public static bool EnableActiveVolcano => _instance.Mashed_Ashlands_EnableActiveVolcano;
        public static int NumberOfActiveVolcano => _instance.Mashed_Ashlands_NumberOfActiveVolcano;
        public static bool EnableBlightedVolcano => _instance.Mashed_Ashlands_EnableBlightedVolcano;
        public static int NumberOfBlightedVolcano => _instance.Mashed_Ashlands_NumberOfBlightedVolcano;
        public static bool EnableExtinctVolcano => _instance.Mashed_Ashlands_EnableExtinctVolcano;
        public static int NumberOfExtinctVolcano => _instance.Mashed_Ashlands_NumberOfExtinctVolcano;

        public static bool EnableCoastalVolcano => _instance.Mashed_Ashlands_EnableCoastalVolcano;
        public static bool EnableLegacyRegions => _instance.Mashed_Ashlands_EnableLegacyRegions;
        public static int VolcanoMinDistance => _instance.Mashed_Ashlands_VolcanoMinDistance;
        public static int BiomesMaxDistance => _instance.Mashed_Ashlands_BiomesMaxDistance;
        public static bool VolcanoScaleWithWorldSize => _instance.Mashed_Ashlands_VolcanoScaleWithWorldSize;
        public static bool BiomeScaleWithWorldSize => _instance.Mashed_Ashlands_BiomeScaleWithWorldSize;


        public static bool EnableStandardAshlands => _instance.Mashed_Ashlands_EnableStandardAshlands;
        public static bool EnableBlightedAshlands => _instance.Mashed_Ashlands_EnableBlightedAshlands;
        public static bool EnableVolcanicAshlands => _instance.Mashed_Ashlands_EnableVolcanicAshlands;
        public static bool EnableCoralCoastAshlands => _instance.Mashed_Ashlands_EnableCoralCoastAshlands;
        public static bool EnableVolcanicCoralCoastAshlands => _instance.Mashed_Ashlands_EnableVolcanicCoralCoastAshlands;
        public static bool EnableForestAshlands => _instance.Mashed_Ashlands_EnableForestAshlands;
        public static bool EnableSwampAshlands => _instance.Mashed_Ashlands_EnableSwampAshlands;
        public static bool EnableGrazelandAshlands => _instance.Mashed_Ashlands_EnableGrazelandAshlands;
        public static bool EnableBlightedBogAshlands => _instance.Mashed_Ashlands_EnableBlightedBogAshlands;
        public static bool EnableVolcanicSulphurPitsAshlands => _instance.Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands;
        public static bool EnableMeadowAshlands => _instance.Mashed_Ashlands_EnableMeadowAshlands;
        public static bool EnableMarshAshlands => _instance.Mashed_Ashlands_EnableMarshAshlands;
        public static bool EnableVolcanicBadlandsAshlands => _instance.Mashed_Ashlands_EnableVolcanicBadlandsAshlands;
        public static bool EnableDustplainAshlands => _instance.Mashed_Ashlands_EnableDustplainAshlands;
        public static bool EnableHighlandAshlands => _instance.Mashed_Ashlands_EnableHighlandAshlands;
        public static bool EnableBlightedPetrifiedForestAshlands => _instance.Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands;
        public static bool EnableVolcanicBasaltHillsAshlands => _instance.Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands;

        //volcano
        public static bool VolcanoAffectedAreaScaleWithWorldSize => _instance.Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize;
        public static int VolcanoMaxAffectedArea => _instance.Mashed_Ashlands_VolcanoMaxAffectedArea;
        public static float VolcanoConditionDurationMultiplier => _instance.Mashed_Ashlands_VolcanoConditionDurationMultiplier;
        public static float VolcanoConditionGraceMultiplier => _instance.Mashed_Ashlands_VolcanoConditionGraceMultiplier;
        public static bool VolcanoEnablePermanentConditions => _instance.Mashed_Ashlands_VolcanoEnablePermanentConditions;
        public static bool VolcanoEnableRandomConditions => _instance.Mashed_Ashlands_VolcanoEnableRandomConditions;
        public static bool VolcanoOnlyLetterIfInRadius => _instance.Mashed_Ashlands_VolcanoOnlyLetterIfInRadius;

        public static bool VolcanoEnableCategoryChange => _instance.Mashed_Ashlands_VolcanoEnableCategoryChange;
        public static int IncidentsForCategoryChange => _instance.Mashed_Ashlands_IncidentsForCategoryChange;

        //cliff racer
        public static bool CliffRacerEnableExtinction => _instance.Mashed_Ashlands_CliffRacerEnableExtinction;
        public static bool CliffRacerEnableTracker => _instance.Mashed_Ashlands_CliffRacerEnableTracker;
        public static int CliffRacerWildPopulation => _instance.Mashed_Ashlands_CliffRacerWildPopulation;
        public static bool CliffRacerEnableReturn => _instance.Mashed_Ashlands_CliffRacerEnableReturn;
        public static int CliffRacerEnableReturnThreshold => _instance.Mashed_Ashlands_CliffRacerEnableReturnThreshold;
        public static bool CliffRacerEnableSwarm => _instance.Mashed_Ashlands_CliffRacerEnableSwarm;
        public static int CliffRacerSwarmMinSize => _instance.Mashed_Ashlands_CliffRacerSwarmMinSize;
        public static int CliffRacerSwarmMaxSize => _instance.Mashed_Ashlands_CliffRacerSwarmMaxSize;
        public static float CliffRacerMutantChance => _instance.Mashed_Ashlands_CliffRacerMutantChance;

        //other
        public static bool EnableAshRaids => _instance.Mashed_Ashlands_EnableAshRaids;

        //ash storm
        public static bool AshStormCauseBuildup => _instance.Mashed_Ashlands_AshStormCauseBuildup;
        public static bool AshStormAffectsCaravan => _instance.Mashed_Ashlands_AshStormAffectsCaravan;
        public static float AshStormBuildupMult => _instance.Mashed_Ashlands_AshStormBuildupMult;

        public static bool AshStormCauseBlinded => _instance.Mashed_Ashlands_AshStormCauseBlinded;
        public static float AshStormBlindedChance => _instance.Mashed_Ashlands_AshStormBlindedChance;

        public static bool AshStormCauseCloggedServo => _instance.Mashed_Ashlands_AshStormCauseCloggedServo;
        public static float AshStormCloggedServoChance => _instance.Mashed_Ashlands_AshStormCloggedServoChance;

        public static bool AshStormDamagePlants => _instance.Mashed_Ashlands_AshStormDamagePlants;
        public static int AshStormAvgPlantDamage => _instance.Mashed_Ashlands_AshStormAvgPlantDamage;

        public static bool AshStormDamageBuildings => _instance.Mashed_Ashlands_AshStormDamageBuildings;

        public static bool AshStormBreakdownBuildings => _instance.Mashed_Ashlands_AshStormBreakdownBuildings;
        public static float AshStormBreakdownBuildingsChance => _instance.Mashed_Ashlands_AshStormBreakdownBuildingsChance;


        //ash blight
        public static bool AshBlightCanSpread => _instance.Mashed_Ashlands_AshBlightCanSpread;
        public static bool AshBlightCanSpreadToPlants => _instance.Mashed_Ashlands_AshBlightCanSpreadToPlants;
        public static bool AshBlightWandersIn => _instance.Mashed_Ashlands_AshBlightWandersIn;

        public static bool BlightStormCaravanAmbush => _instance.Mashed_Ashlands_BlightStormCaravanAmbush;
        public static bool BlightStormBlightAnimals => _instance.Mashed_Ashlands_BlightStormBlightAnimals;
        public static bool BlightStormBlightPlayerAnimals => _instance.Mashed_Ashlands_BlightStormBlightPlayerAnimals;
        public static bool BlightStormBlightNonPlayerAnimals => _instance.Mashed_Ashlands_BlightStormBlightNonPlayerAnimals;

        public static bool BlightStormBlightPlants => _instance.Mashed_Ashlands_BlightStormBlightPlants;
        public static bool BlightStormBlightWildPlants => _instance.Mashed_Ashlands_BlightStormBlightWildPlants;
        public static int BlightStormBlightPlantsNumber => _instance.Mashed_Ashlands_BlightStormBlightPlantsNumber;

        //other conditions
        public static bool MiasmaAffectsCaravan => _instance.Mashed_Ashlands_MiasmaAffectsCaravan;

        public static bool EarthquakeShake => _instance.Mashed_Ashlands_EarthquakeShake;
        public static bool EarthquakeCollapseMountains => _instance.Mashed_Ashlands_EarthquakeCollapseMountains;
        public static bool EarthquakeDamageBuildings => _instance.Mashed_Ashlands_EarthquakeDamageBuildings;
        public static bool EarthquakeDamageBuildingsNonPlayer => _instance.Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer;
        public static float EarthquakeDamageBuildingsChance => _instance.Mashed_Ashlands_EarthquakeDamageBuildingsChance;
        public static int EarthquakeDamageBuildingsDamage => _instance.Mashed_Ashlands_EarthquakeDamageBuildingsDamage;

        //biome
        public static bool EnableFetcherflyHives => _instance.Mashed_Ashlands_EnableFetcherflyHives;
        public static bool EnableCavePlants => _instance.Mashed_Ashlands_EnableCavePlants;
        public static bool EnableColumnarBasalt => _instance.Mashed_Ashlands_EnableColumnarBasalt;

        /* ==========[VARIABLES]========== */
        //general
        public bool Mashed_Ashlands_OnlySowOnAsh = Mashed_Ashlands_OnlySowOnAsh_def;
        public bool Mashed_Ashlands_BaseAshResistance = Mashed_Ashlands_BaseAshResistance_def;
        public float Mashed_Ashlands_BaseAshResistanceValue = Mashed_Ashlands_BaseAshResistanceValue_def;
        public bool Mashed_Ashlands_FlowerFeeding = Mashed_Ashlands_FlowerFeeding_def;
        public bool Mashed_Ashlands_ScampInsulting = Mashed_Ashlands_ScampInsulting_def;
        public bool Mashed_Ashlands_AshcanoJoy = Mashed_Ashlands_AshcanoJoy_def;

        //world gen

        public bool Mashed_Ashlands_EnableSettingBeforeWorldGen = Mashed_Ashlands_EnableSettingBeforeWorldGen_def;
        public bool Mashed_Ashlands_EnableDormantVolcano = Mashed_Ashlands_EnableDormantVolcano_def;
        public int Mashed_Ashlands_NumberOfDormantVolcano = Mashed_Ashlands_NumberOfDormantVolcano_def;
        public bool Mashed_Ashlands_EnableActiveVolcano = Mashed_Ashlands_EnableActiveVolcano_def;
        public int Mashed_Ashlands_NumberOfActiveVolcano = Mashed_Ashlands_NumberOfActiveVolcano_def;
        public bool Mashed_Ashlands_EnableBlightedVolcano = Mashed_Ashlands_EnableBlightedVolcano_def;
        public int Mashed_Ashlands_NumberOfBlightedVolcano = Mashed_Ashlands_NumberOfBlightedVolcano_def;
        public bool Mashed_Ashlands_EnableExtinctVolcano = Mashed_Ashlands_EnableExtinctVolcano_def;
        public int Mashed_Ashlands_NumberOfExtinctVolcano = Mashed_Ashlands_NumberOfExtinctVolcano_def;

        public bool Mashed_Ashlands_EnableCoastalVolcano = Mashed_Ashlands_EnableCoastalVolcano_def;
        public bool Mashed_Ashlands_EnableLegacyRegions = Mashed_Ashlands_EnableLegacyRegions_def;
        public int Mashed_Ashlands_VolcanoMinDistance = Mashed_Ashlands_VolcanoMinDistance_def;
        public int Mashed_Ashlands_BiomesMaxDistance = Mashed_Ashlands_BiomesMaxDistance_def;
        public bool Mashed_Ashlands_VolcanoScaleWithWorldSize = Mashed_Ashlands_VolcanoScaleWithWorldSize_def;
        public bool Mashed_Ashlands_BiomeScaleWithWorldSize = Mashed_Ashlands_BiomeScaleWithWorldSize_def;

        public bool Mashed_Ashlands_EnableStandardAshlands = Mashed_Ashlands_EnableStandardAshlands_def;
        public bool Mashed_Ashlands_EnableBlightedAshlands = Mashed_Ashlands_EnableBlightedAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicAshlands = Mashed_Ashlands_EnableVolcanicAshlands_def;
        public bool Mashed_Ashlands_EnableCoralCoastAshlands = Mashed_Ashlands_EnableCoralCoastAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicCoralCoastAshlands = Mashed_Ashlands_EnableVolcanicCoralCoastAshlands_def;
        public bool Mashed_Ashlands_EnableForestAshlands = Mashed_Ashlands_EnableForestAshlands_def;
        public bool Mashed_Ashlands_EnableSwampAshlands = Mashed_Ashlands_EnableSwampAshlands_def;
        public bool Mashed_Ashlands_EnableGrazelandAshlands = Mashed_Ashlands_EnableGrazelandAshlands_def;
        public bool Mashed_Ashlands_EnableBlightedBogAshlands = Mashed_Ashlands_EnableBlightedBogAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands = Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands_def;
        public bool Mashed_Ashlands_EnableMeadowAshlands = Mashed_Ashlands_EnableMeadowAshlands_def;
        public bool Mashed_Ashlands_EnableMarshAshlands = Mashed_Ashlands_EnableMarshAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicBadlandsAshlands = Mashed_Ashlands_EnableVolcanicBadlandsAshlands_def;
        public bool Mashed_Ashlands_EnableDustplainAshlands = Mashed_Ashlands_EnableDustplainAshlands_def;
        public bool Mashed_Ashlands_EnableHighlandAshlands = Mashed_Ashlands_EnableHighlandAshlands_def;
        public bool Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands = Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands = Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands_def;

        //volcano
        public bool Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize = Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_def;
        public int Mashed_Ashlands_VolcanoMaxAffectedArea = Mashed_Ashlands_VolcanoMaxAffectedArea_def;
        public float Mashed_Ashlands_VolcanoConditionDurationMultiplier = Mashed_Ashlands_VolcanoConditionDurationMultiplier_def;
        public float Mashed_Ashlands_VolcanoConditionGraceMultiplier = Mashed_Ashlands_VolcanoConditionGraceMultiplier_def;
        public bool Mashed_Ashlands_VolcanoEnablePermanentConditions = Mashed_Ashlands_VolcanoEnablePermanentConditions_def;
        public bool Mashed_Ashlands_VolcanoEnableRandomConditions = Mashed_Ashlands_VolcanoEnableRandomConditions_def;
        public bool Mashed_Ashlands_VolcanoOnlyLetterIfInRadius = Mashed_Ashlands_VolcanoOnlyLetterIfInRadius_def;
        public bool Mashed_Ashlands_VolcanoEnableCategoryChange = Mashed_Ashlands_VolcanoEnableCategoryChange_def;
        public int Mashed_Ashlands_IncidentsForCategoryChange = Mashed_Ashlands_IncidentsForCategoryChange_def;

        //cliff racer
        public bool Mashed_Ashlands_CliffRacerEnableExtinction = Mashed_Ashlands_CliffRacerEnableExtinction_def;
        public bool Mashed_Ashlands_CliffRacerEnableTracker = Mashed_Ashlands_CliffRacerEnableTracker_def;
        public int Mashed_Ashlands_CliffRacerWildPopulation = Mashed_Ashlands_CliffRacerWildPopulation_def;
        public bool Mashed_Ashlands_CliffRacerEnableReturn = Mashed_Ashlands_CliffRacerEnableReturn_def;
        public int Mashed_Ashlands_CliffRacerEnableReturnThreshold = Mashed_Ashlands_CliffRacerEnableReturnThreshold_def;
        public bool Mashed_Ashlands_CliffRacerEnableSwarm = Mashed_Ashlands_CliffRacerEnableSwarm_def;
        public int Mashed_Ashlands_CliffRacerSwarmMinSize = Mashed_Ashlands_CliffRacerSwarmMinSize_def;
        public int Mashed_Ashlands_CliffRacerSwarmMaxSize = Mashed_Ashlands_CliffRacerSwarmMaxSize_def;
        public float Mashed_Ashlands_CliffRacerMutantChance = Mashed_Ashlands_CliffRacerMutantChance_def;

        //other
        public bool Mashed_Ashlands_EnableAshRaids = Mashed_Ashlands_EnableAshRaids_def;

        //ash storm
        public bool Mashed_Ashlands_AshStormCauseBuildup = Mashed_Ashlands_AshStormCauseBuildup_def;
        public bool Mashed_Ashlands_AshStormAffectsCaravan = Mashed_Ashlands_AshStormAffectsCaravan_def;
        public float Mashed_Ashlands_AshStormBuildupMult = Mashed_Ashlands_AshStormBuildupMult_def;

        public bool Mashed_Ashlands_AshStormCauseBlinded = Mashed_Ashlands_AshStormCauseBlinded_def;
        public float Mashed_Ashlands_AshStormBlindedChance = Mashed_Ashlands_AshStormBlindedChance_def;

        public bool Mashed_Ashlands_AshStormCauseCloggedServo = Mashed_Ashlands_AshStormCauseCloggedServo_def;
        public float Mashed_Ashlands_AshStormCloggedServoChance = Mashed_Ashlands_AshStormCloggedServoChance_def;

        public bool Mashed_Ashlands_AshStormDamagePlants = Mashed_Ashlands_AshStormDamagePlants_def;
        public int Mashed_Ashlands_AshStormAvgPlantDamage = Mashed_Ashlands_AshStormAvgPlantDamage_def;

        public bool Mashed_Ashlands_AshStormDamageBuildings = Mashed_Ashlands_AshStormDamageBuildings_def;

        public bool Mashed_Ashlands_AshStormBreakdownBuildings = Mashed_Ashlands_AshStormBreakdownBuildings_def;
        public float Mashed_Ashlands_AshStormBreakdownBuildingsChance = Mashed_Ashlands_AshStormBreakdownBuildingsChance_def;

        //ash blight
        public bool Mashed_Ashlands_AshBlightCanSpread = Mashed_Ashlands_AshBlightCanSpread_def;
        public bool Mashed_Ashlands_AshBlightCanSpreadToPlants = Mashed_Ashlands_AshBlightCanSpreadToPlants_def;
        public bool Mashed_Ashlands_AshBlightWandersIn = Mashed_Ashlands_AshBlightWandersIn_def;

        public bool Mashed_Ashlands_BlightStormCaravanAmbush = Mashed_Ashlands_BlightStormCaravanAmbush_def;
        public bool Mashed_Ashlands_BlightStormBlightAnimals = Mashed_Ashlands_BlightStormBlightAnimals_def;
        public bool Mashed_Ashlands_BlightStormBlightPlayerAnimals = Mashed_Ashlands_BlightStormBlightPlayerAnimals_def;
        public bool Mashed_Ashlands_BlightStormBlightNonPlayerAnimals = Mashed_Ashlands_BlightStormBlightNonPlayerAnimals_def;

        public bool Mashed_Ashlands_BlightStormBlightPlants = Mashed_Ashlands_BlightStormBlightPlants_def;
        public bool Mashed_Ashlands_BlightStormBlightWildPlants = Mashed_Ashlands_BlightStormBlightWildPlants_def;
        public int Mashed_Ashlands_BlightStormBlightPlantsNumber = Mashed_Ashlands_BlightStormBlightPlantsNumber_def;

        //other conditions
        public bool Mashed_Ashlands_MiasmaAffectsCaravan = Mashed_Ashlands_MiasmaAffectsCaravan_def;

        public bool Mashed_Ashlands_EarthquakeShake = Mashed_Ashlands_EarthquakeShake_def;
        public bool Mashed_Ashlands_EarthquakeCollapseMountains = Mashed_Ashlands_EarthquakeCollapseMountains_def;
        public bool Mashed_Ashlands_EarthquakeDamageBuildings = Mashed_Ashlands_EarthquakeDamageBuildings_def;
        public bool Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer = Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer_def;
        public float Mashed_Ashlands_EarthquakeDamageBuildingsChance = Mashed_Ashlands_EarthquakeDamageBuildingsChance_def;
        public int Mashed_Ashlands_EarthquakeDamageBuildingsDamage = Mashed_Ashlands_EarthquakeDamageBuildingsDamage_def;

        //biome
        public bool Mashed_Ashlands_EnableFetcherflyHives = Mashed_Ashlands_EnableFetcherflyHives_def;
        public bool Mashed_Ashlands_EnableCavePlants = Mashed_Ashlands_EnableCavePlants_def;
        public bool Mashed_Ashlands_EnableColumnarBasalt = Mashed_Ashlands_EnableColumnarBasalt_def;

        /* ==========[DEFAULTS]========== */
        //general
        private static readonly bool Mashed_Ashlands_OnlySowOnAsh_def = true;
        private static readonly bool Mashed_Ashlands_BaseAshResistance_def = true;
        private static readonly float Mashed_Ashlands_BaseAshResistanceValue_def = 0.5f;
        private static readonly bool Mashed_Ashlands_FlowerFeeding_def = true;
        private static readonly bool Mashed_Ashlands_ScampInsulting_def = true;
        private static readonly bool Mashed_Ashlands_AshcanoJoy_def = true;

        //world gen

        private static readonly bool Mashed_Ashlands_EnableSettingBeforeWorldGen_def = true;
        private static readonly bool Mashed_Ashlands_EnableDormantVolcano_def = true;
        private static readonly int Mashed_Ashlands_NumberOfDormantVolcano_def = 3;
        private static readonly bool Mashed_Ashlands_EnableActiveVolcano_def = true;
        private static readonly int Mashed_Ashlands_NumberOfActiveVolcano_def = 3;
        private static readonly bool Mashed_Ashlands_EnableBlightedVolcano_def = true;
        private static readonly int Mashed_Ashlands_NumberOfBlightedVolcano_def = 3;
        private static readonly bool Mashed_Ashlands_EnableExtinctVolcano_def = true;
        private static readonly int Mashed_Ashlands_NumberOfExtinctVolcano_def = 3;

        private static readonly bool Mashed_Ashlands_EnableCoastalVolcano_def = false;
        private static readonly bool Mashed_Ashlands_EnableLegacyRegions_def = false;
        private static readonly int Mashed_Ashlands_VolcanoMinDistance_def = 25;
        private static readonly int Mashed_Ashlands_BiomesMaxDistance_def = 25;
        private static readonly bool Mashed_Ashlands_VolcanoScaleWithWorldSize_def = true;
        private static readonly bool Mashed_Ashlands_BiomeScaleWithWorldSize_def = true;

        private static readonly bool Mashed_Ashlands_EnableStandardAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableBlightedAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableCoralCoastAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicCoralCoastAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableForestAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableSwampAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableGrazelandAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableBlightedBogAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableMeadowAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableMarshAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicBadlandsAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableDustplainAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableHighlandAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands_def = true;

        //volcano
        private static readonly bool Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_def = true;
        private static readonly int Mashed_Ashlands_VolcanoMaxAffectedArea_def = 10;
        private static readonly float Mashed_Ashlands_VolcanoConditionDurationMultiplier_def = 1f;
        private static readonly float Mashed_Ashlands_VolcanoConditionGraceMultiplier_def = 1f;
        private static readonly bool Mashed_Ashlands_VolcanoEnablePermanentConditions_def = true;
        private static readonly bool Mashed_Ashlands_VolcanoEnableRandomConditions_def = true;
        private static readonly bool Mashed_Ashlands_VolcanoOnlyLetterIfInRadius_def = true;

        private static readonly bool Mashed_Ashlands_VolcanoEnableCategoryChange_def = true;
        private static readonly int Mashed_Ashlands_IncidentsForCategoryChange_def = 10;

        //cliff racer
        private static readonly bool Mashed_Ashlands_CliffRacerEnableExtinction_def = true;
        private static readonly bool Mashed_Ashlands_CliffRacerEnableTracker_def = true;
        private static readonly int Mashed_Ashlands_CliffRacerWildPopulation_def = 100000;
        private static readonly bool Mashed_Ashlands_CliffRacerEnableReturn_def = true;
        private static readonly int Mashed_Ashlands_CliffRacerEnableReturnThreshold_def = 50;
        private static readonly bool Mashed_Ashlands_CliffRacerEnableSwarm_def = true;
        private static readonly int Mashed_Ashlands_CliffRacerSwarmMinSize_def = 3;
        private static readonly int Mashed_Ashlands_CliffRacerSwarmMaxSize_def = 30;
        private static readonly float Mashed_Ashlands_CliffRacerMutantChance_def = 0.05f;

        //other
        private static readonly bool Mashed_Ashlands_EnableAshRaids_def = true;

        //ash storm
        private static readonly bool Mashed_Ashlands_AshStormCauseBuildup_def = true;
        private static readonly bool Mashed_Ashlands_AshStormAffectsCaravan_def = true;
        private static readonly float Mashed_Ashlands_AshStormBuildupMult_def = 1f;

        private static readonly bool Mashed_Ashlands_AshStormCauseBlinded_def = true;
        private static readonly float Mashed_Ashlands_AshStormBlindedChance_def = 0.25f;

        private static readonly bool Mashed_Ashlands_AshStormCauseCloggedServo_def = true;
        private static readonly float Mashed_Ashlands_AshStormCloggedServoChance_def = 0.25f;

        private static readonly bool Mashed_Ashlands_AshStormDamagePlants_def = true;
        private static readonly int Mashed_Ashlands_AshStormAvgPlantDamage_def = 10;

        private static readonly bool Mashed_Ashlands_AshStormDamageBuildings_def = true;

        private static readonly bool Mashed_Ashlands_AshStormBreakdownBuildings_def = false;
        private static readonly float Mashed_Ashlands_AshStormBreakdownBuildingsChance_def = 0.05f;

        //ash blight
        private static readonly bool Mashed_Ashlands_AshBlightCanSpread_def = true;
        private static readonly bool Mashed_Ashlands_AshBlightCanSpreadToPlants_def = true;
        private static readonly bool Mashed_Ashlands_AshBlightWandersIn_def = true;

        private static readonly bool Mashed_Ashlands_BlightStormCaravanAmbush_def = true;
        private static readonly bool Mashed_Ashlands_BlightStormBlightAnimals_def = true;
        private static readonly bool Mashed_Ashlands_BlightStormBlightPlayerAnimals_def = false;
        private static readonly bool Mashed_Ashlands_BlightStormBlightNonPlayerAnimals_def = false;

        private static readonly bool Mashed_Ashlands_BlightStormBlightPlants_def = true;
        private static readonly bool Mashed_Ashlands_BlightStormBlightWildPlants_def = false;
        private static readonly int Mashed_Ashlands_BlightStormBlightPlantsNumber_def = 3;

        //other conditions
        private static readonly bool Mashed_Ashlands_MiasmaAffectsCaravan_def = true;

        private static readonly bool Mashed_Ashlands_EarthquakeShake_def = true;
        private static readonly bool Mashed_Ashlands_EarthquakeCollapseMountains_def = true;
        private static readonly bool Mashed_Ashlands_EarthquakeDamageBuildings_def = true;
        private static readonly bool Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer_def = false;
        private static readonly float Mashed_Ashlands_EarthquakeDamageBuildingsChance_def = 0.2f;
        private static readonly int Mashed_Ashlands_EarthquakeDamageBuildingsDamage_def = 10;

        //biome
        private static readonly bool Mashed_Ashlands_EnableFetcherflyHives_def = true;
        private static readonly bool Mashed_Ashlands_EnableCavePlants_def = true;
        private static readonly bool Mashed_Ashlands_EnableColumnarBasalt_def = true;

        public Mashed_Ashlands_ModSettings()
        {
            _instance = this;
        }

        /* ==========[SAVING]========== */
        public override void ExposeData()
        {
            //general
            Scribe_Values.Look(ref Mashed_Ashlands_OnlySowOnAsh, "Mashed_Ashlands_OnlySowOnAsh", Mashed_Ashlands_OnlySowOnAsh_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BaseAshResistance, "Mashed_Ashlands_BaseAshResistance", Mashed_Ashlands_BaseAshResistance_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BaseAshResistanceValue, "Mashed_Ashlands_BaseAshResistanceValue", Mashed_Ashlands_BaseAshResistanceValue_def);
            Scribe_Values.Look(ref Mashed_Ashlands_FlowerFeeding, "Mashed_Ashlands_FlowerFeeding", Mashed_Ashlands_FlowerFeeding_def);
            Scribe_Values.Look(ref Mashed_Ashlands_ScampInsulting, "Mashed_Ashlands_ScampInsulting", Mashed_Ashlands_ScampInsulting_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshcanoJoy, "Mashed_Ashlands_AshcanoJoy", Mashed_Ashlands_AshcanoJoy_def);

            //world gen
            Scribe_Values.Look(ref Mashed_Ashlands_EnableSettingBeforeWorldGen, "Mashed_Ashlands_EnableSettingBeforeWorldGen", Mashed_Ashlands_EnableSettingBeforeWorldGen_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableDormantVolcano, "Mashed_Ashlands_EnableDormantVolcano", Mashed_Ashlands_EnableDormantVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_NumberOfDormantVolcano, "Mashed_Ashlands_NumberOfDormantVolcano", Mashed_Ashlands_NumberOfDormantVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableActiveVolcano, "Mashed_Ashlands_EnableActiveVolcano", Mashed_Ashlands_EnableActiveVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_NumberOfActiveVolcano, "Mashed_Ashlands_NumberOfActiveVolcano", Mashed_Ashlands_NumberOfActiveVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableBlightedVolcano, "Mashed_Ashlands_EnableBlightedVolcano", Mashed_Ashlands_EnableBlightedVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_NumberOfBlightedVolcano, "Mashed_Ashlands_NumberOfBlightedVolcano", Mashed_Ashlands_NumberOfBlightedVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableExtinctVolcano, "Mashed_Ashlands_EnableExtinctVolcano", Mashed_Ashlands_EnableExtinctVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_NumberOfExtinctVolcano, "Mashed_Ashlands_NumberOfExtinctVolcano", Mashed_Ashlands_NumberOfExtinctVolcano_def);

            Scribe_Values.Look(ref Mashed_Ashlands_EnableCoastalVolcano, "Mashed_Ashlands_EnableCoastalVolcano", Mashed_Ashlands_EnableCoastalVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableLegacyRegions, "Mashed_Ashlands_EnableLegacyRegions", Mashed_Ashlands_EnableLegacyRegions_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoMinDistance, "Mashed_Ashlands_VolcanoMinDistance", Mashed_Ashlands_VolcanoMinDistance_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BiomesMaxDistance, "Mashed_Ashlands_BiomesMaxDistance", Mashed_Ashlands_BiomesMaxDistance_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoScaleWithWorldSize, "Mashed_Ashlands_VolcanoScaleWithWorldSize", Mashed_Ashlands_VolcanoScaleWithWorldSize_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BiomeScaleWithWorldSize, "Mashed_Ashlands_BiomeScaleWithWorldSize", Mashed_Ashlands_BiomeScaleWithWorldSize_def);

            Scribe_Values.Look(ref Mashed_Ashlands_EnableStandardAshlands, "Mashed_Ashlands_EnableStandardAshlands", Mashed_Ashlands_EnableStandardAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableBlightedAshlands, "Mashed_Ashlands_EnableBlightedAshlands", Mashed_Ashlands_EnableBlightedAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicAshlands, "Mashed_Ashlands_EnableVolcanicAshlands", Mashed_Ashlands_EnableVolcanicAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableCoralCoastAshlands, "Mashed_Ashlands_EnableCoralCoastAshlands", Mashed_Ashlands_EnableCoralCoastAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicCoralCoastAshlands, "Mashed_Ashlands_EnableVolcanicCoralCoastAshlands", Mashed_Ashlands_EnableVolcanicCoralCoastAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableForestAshlands, "Mashed_Ashlands_EnableForestAshlands", Mashed_Ashlands_EnableForestAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableSwampAshlands, "Mashed_Ashlands_EnableSwampAshlands", Mashed_Ashlands_EnableSwampAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableGrazelandAshlands, "Mashed_Ashlands_EnableGrazelandAshlands", Mashed_Ashlands_EnableGrazelandAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableBlightedBogAshlands, "Mashed_Ashlands_EnableBlightedBogAshlands", Mashed_Ashlands_EnableBlightedBogAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands, "Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands", Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableMeadowAshlands, "Mashed_Ashlands_EnableMeadowAshlands", Mashed_Ashlands_EnableMeadowAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableMarshAshlands, "Mashed_Ashlands_EnableMarshAshlands", Mashed_Ashlands_EnableMarshAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicBadlandsAshlands, "Mashed_Ashlands_EnableVolcanicBadlandsAshlands", Mashed_Ashlands_EnableVolcanicBadlandsAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableDustplainAshlands, "Mashed_Ashlands_EnableDustplainAshlands", Mashed_Ashlands_EnableDustplainAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableHighlandAshlands, "Mashed_Ashlands_EnableHighlandAshlands", Mashed_Ashlands_EnableHighlandAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands, "Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands", Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands, "Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands", Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands_def);

            //volcano
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize, "Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize", Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoMaxAffectedArea, "Mashed_Ashlands_VolcanoMaxAffectedArea", Mashed_Ashlands_VolcanoMaxAffectedArea_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoConditionDurationMultiplier, "Mashed_Ashlands_VolcanoConditionDurationMultiplier", Mashed_Ashlands_VolcanoConditionDurationMultiplier_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoConditionGraceMultiplier, "Mashed_Ashlands_VolcanoConditionGraceMultiplier", Mashed_Ashlands_VolcanoConditionGraceMultiplier_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoEnablePermanentConditions, "Mashed_Ashlands_VolcanoEnablePermanentConditions", Mashed_Ashlands_VolcanoEnablePermanentConditions_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoEnableRandomConditions, "Mashed_Ashlands_VolcanoEnableRandomConditions", Mashed_Ashlands_VolcanoEnableRandomConditions_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoOnlyLetterIfInRadius, "Mashed_Ashlands_VolcanoOnlyLetterIfInRadius", Mashed_Ashlands_VolcanoOnlyLetterIfInRadius_def);

            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoEnableCategoryChange, "Mashed_Ashlands_VolcanoEnableCategoryChange", Mashed_Ashlands_VolcanoEnableCategoryChange_def);
            Scribe_Values.Look(ref Mashed_Ashlands_IncidentsForCategoryChange, "Mashed_Ashlands_IncidentsForCategoryChange", Mashed_Ashlands_IncidentsForCategoryChange_def);

            //cliff racer
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerEnableExtinction, "Mashed_Ashlands_CliffRacerEnableExtinction", Mashed_Ashlands_CliffRacerEnableExtinction_def);
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerEnableTracker, "Mashed_Ashlands_CliffRacerEnableTracker", Mashed_Ashlands_CliffRacerEnableTracker_def);
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerWildPopulation, "Mashed_Ashlands_CliffRacerWildPopulation", Mashed_Ashlands_CliffRacerWildPopulation_def);
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerEnableReturn, "Mashed_Ashlands_CliffRacerEnableReturn", Mashed_Ashlands_CliffRacerEnableReturn_def);
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerEnableReturnThreshold, "Mashed_Ashlands_CliffRacerEnableReturnThreshold", Mashed_Ashlands_CliffRacerEnableReturnThreshold_def);
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerEnableSwarm, "Mashed_Ashlands_CliffRacerEnableSwarm", Mashed_Ashlands_CliffRacerEnableSwarm_def);
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerSwarmMinSize, "Mashed_Ashlands_CliffRacerSwarmMinSize", Mashed_Ashlands_CliffRacerSwarmMinSize_def);
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerSwarmMaxSize, "Mashed_Ashlands_CliffRacerSwarmMaxSize", Mashed_Ashlands_CliffRacerSwarmMaxSize_def);
            Scribe_Values.Look(ref Mashed_Ashlands_CliffRacerMutantChance, "Mashed_Ashlands_CliffRacerMutantChance", Mashed_Ashlands_CliffRacerMutantChance_def);

            //other
            Scribe_Values.Look(ref Mashed_Ashlands_EnableAshRaids, "Mashed_Ashlands_EnableAshRaids", Mashed_Ashlands_EnableAshRaids_def);

            //ash storm
            Scribe_Values.Look(ref Mashed_Ashlands_AshStormCauseBuildup, "Mashed_Ashlands_AshStormCauseBuildup", Mashed_Ashlands_AshStormCauseBuildup_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshStormAffectsCaravan, "Mashed_Ashlands_AshStormAffectsCaravan", Mashed_Ashlands_AshStormAffectsCaravan_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshStormBuildupMult, "Mashed_Ashlands_AshStormBuildupMult", Mashed_Ashlands_AshStormBuildupMult_def);

            Scribe_Values.Look(ref Mashed_Ashlands_AshStormCauseBlinded, "Mashed_Ashlands_AshStormCauseBlinded", Mashed_Ashlands_AshStormCauseBlinded_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshStormBlindedChance, "Mashed_Ashlands_AshStormBlindedChance", Mashed_Ashlands_AshStormBlindedChance_def);

            Scribe_Values.Look(ref Mashed_Ashlands_AshStormCauseCloggedServo, "Mashed_Ashlands_AshStormCauseCloggedServo", Mashed_Ashlands_AshStormCauseCloggedServo_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshStormCloggedServoChance, "Mashed_Ashlands_AshStormCloggedServoChance", Mashed_Ashlands_AshStormCloggedServoChance_def);

            Scribe_Values.Look(ref Mashed_Ashlands_AshStormDamagePlants, "Mashed_Ashlands_AshStormDamagePlants", Mashed_Ashlands_AshStormDamagePlants_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshStormAvgPlantDamage, "Mashed_Ashlands_AshStormAvgPlantDamage", Mashed_Ashlands_AshStormAvgPlantDamage_def);

            Scribe_Values.Look(ref Mashed_Ashlands_AshStormDamageBuildings, "Mashed_Ashlands_AshStormDamageBuildings", Mashed_Ashlands_AshStormDamageBuildings_def);

            Scribe_Values.Look(ref Mashed_Ashlands_AshStormBreakdownBuildings, "Mashed_Ashlands_AshStormBreakdownBuildings", Mashed_Ashlands_AshStormBreakdownBuildings_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshStormBreakdownBuildingsChance, "Mashed_Ashlands_AshStormBreakdownBuildingsChance", Mashed_Ashlands_AshStormBreakdownBuildingsChance_def);

            //ash blight
            Scribe_Values.Look(ref Mashed_Ashlands_AshBlightCanSpread, "Mashed_Ashlands_AshBlightCanSpread", Mashed_Ashlands_AshBlightCanSpread_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshBlightCanSpreadToPlants, "Mashed_Ashlands_AshBlightCanSpreadToPlants", Mashed_Ashlands_AshBlightCanSpreadToPlants_def);
            Scribe_Values.Look(ref Mashed_Ashlands_AshBlightWandersIn, "Mashed_Ashlands_AshBlightWandersIn", Mashed_Ashlands_AshBlightWandersIn_def);

            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormCaravanAmbush, "Mashed_Ashlands_BlightStormCaravanAmbush", Mashed_Ashlands_BlightStormCaravanAmbush_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightAnimals, "Mashed_Ashlands_BlightStormBlightAnimals", Mashed_Ashlands_BlightStormBlightAnimals_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightPlayerAnimals, "Mashed_Ashlands_BlightStormBlightPlayerAnimals", Mashed_Ashlands_BlightStormBlightPlayerAnimals_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightNonPlayerAnimals, "Mashed_Ashlands_BlightStormBlightNonPlayerAnimals", Mashed_Ashlands_BlightStormBlightNonPlayerAnimals_def);

            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightPlants, "Mashed_Ashlands_BlightStormBlightPlants", Mashed_Ashlands_BlightStormBlightPlants_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightWildPlants, "Mashed_Ashlands_BlightStormBlightWildPlants", Mashed_Ashlands_BlightStormBlightWildPlants_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightPlantsNumber, "Mashed_Ashlands_BlightStormBlightPlantsNumber", Mashed_Ashlands_BlightStormBlightPlantsNumber_def);

            //other conditions
            Scribe_Values.Look(ref Mashed_Ashlands_MiasmaAffectsCaravan, "Mashed_Ashlands_MiasmaAffectsCaravan", Mashed_Ashlands_MiasmaAffectsCaravan_def);

            Scribe_Values.Look(ref Mashed_Ashlands_EarthquakeShake, "Mashed_Ashlands_EarthquakeShake", Mashed_Ashlands_EarthquakeShake_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EarthquakeCollapseMountains, "Mashed_Ashlands_EarthquakeCollapseMountains", Mashed_Ashlands_EarthquakeCollapseMountains_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EarthquakeDamageBuildings, "Mashed_Ashlands_EarthquakeDamageBuildings", Mashed_Ashlands_EarthquakeDamageBuildings_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer, "Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer", Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EarthquakeDamageBuildingsChance, "Mashed_Ashlands_EarthquakeDamageBuildingsChance", Mashed_Ashlands_EarthquakeDamageBuildingsChance_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EarthquakeDamageBuildingsDamage, "Mashed_Ashlands_EarthquakeDamageBuildingsDamage", Mashed_Ashlands_EarthquakeDamageBuildingsDamage_def);

            //biome
            Scribe_Values.Look(ref Mashed_Ashlands_EnableFetcherflyHives, "Mashed_Ashlands_EnableFetcherflyHives", Mashed_Ashlands_EnableFetcherflyHives_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableCavePlants, "Mashed_Ashlands_EnableCavePlants", Mashed_Ashlands_EnableCavePlants_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableColumnarBasalt, "Mashed_Ashlands_EnableColumnarBasalt", Mashed_Ashlands_EnableColumnarBasalt_def);

            base.ExposeData();
        }

        /* ==========[RESETTING]========== */
        public static void ResetSettings()
        {
            ResetSettings_General();
            ResetSettings_WorldGen();
            ResetSettings_Incident();
            ResetSettings_CliffRacer();
            ResetSettings_AshStorm();
            ResetSettings_AshBlight();
            ResetSettings_Biome();
        }

        public static void ResetSettings_General()
        {
            _instance.Mashed_Ashlands_EnableSettingBeforeWorldGen = Mashed_Ashlands_EnableSettingBeforeWorldGen_def;
            _instance.Mashed_Ashlands_OnlySowOnAsh = Mashed_Ashlands_OnlySowOnAsh_def;
            _instance.Mashed_Ashlands_BaseAshResistance = Mashed_Ashlands_BaseAshResistance_def;
            _instance.Mashed_Ashlands_BaseAshResistanceValue = Mashed_Ashlands_BaseAshResistanceValue_def;
            _instance.Mashed_Ashlands_FlowerFeeding = Mashed_Ashlands_FlowerFeeding_def;
            _instance.Mashed_Ashlands_ScampInsulting = Mashed_Ashlands_ScampInsulting_def;
            _instance.Mashed_Ashlands_AshcanoJoy = Mashed_Ashlands_AshcanoJoy_def;
        }

        public static void ResetSettings_WorldGen()
        {
            _instance.Mashed_Ashlands_EnableDormantVolcano = Mashed_Ashlands_EnableDormantVolcano_def;
            _instance.Mashed_Ashlands_NumberOfDormantVolcano = Mashed_Ashlands_NumberOfDormantVolcano_def;
            _instance.Mashed_Ashlands_EnableActiveVolcano = Mashed_Ashlands_EnableActiveVolcano_def;
            _instance.Mashed_Ashlands_NumberOfActiveVolcano = Mashed_Ashlands_NumberOfActiveVolcano_def;
            _instance.Mashed_Ashlands_EnableBlightedVolcano = Mashed_Ashlands_EnableBlightedVolcano_def;
            _instance.Mashed_Ashlands_NumberOfBlightedVolcano = Mashed_Ashlands_NumberOfBlightedVolcano_def;
            _instance.Mashed_Ashlands_EnableExtinctVolcano = Mashed_Ashlands_EnableExtinctVolcano_def;
            _instance.Mashed_Ashlands_NumberOfExtinctVolcano = Mashed_Ashlands_NumberOfExtinctVolcano_def;

            _instance.Mashed_Ashlands_EnableCoastalVolcano = Mashed_Ashlands_EnableCoastalVolcano_def;
            _instance.Mashed_Ashlands_EnableLegacyRegions = Mashed_Ashlands_EnableLegacyRegions_def;
            _instance.Mashed_Ashlands_VolcanoMinDistance = Mashed_Ashlands_VolcanoMinDistance_def;
            _instance.Mashed_Ashlands_BiomesMaxDistance = Mashed_Ashlands_BiomesMaxDistance_def;
            _instance.Mashed_Ashlands_VolcanoScaleWithWorldSize = Mashed_Ashlands_VolcanoScaleWithWorldSize_def;
            _instance.Mashed_Ashlands_BiomeScaleWithWorldSize = Mashed_Ashlands_BiomeScaleWithWorldSize_def;

            _instance.Mashed_Ashlands_EnableStandardAshlands = Mashed_Ashlands_EnableStandardAshlands_def;
            _instance.Mashed_Ashlands_EnableBlightedAshlands = Mashed_Ashlands_EnableBlightedAshlands_def;
            _instance.Mashed_Ashlands_EnableVolcanicAshlands = Mashed_Ashlands_EnableVolcanicAshlands_def;
            _instance.Mashed_Ashlands_EnableCoralCoastAshlands = Mashed_Ashlands_EnableCoralCoastAshlands_def;
            _instance.Mashed_Ashlands_EnableVolcanicCoralCoastAshlands = Mashed_Ashlands_EnableVolcanicCoralCoastAshlands_def;
            _instance.Mashed_Ashlands_EnableForestAshlands = Mashed_Ashlands_EnableForestAshlands_def;
            _instance.Mashed_Ashlands_EnableSwampAshlands = Mashed_Ashlands_EnableSwampAshlands_def;
            _instance.Mashed_Ashlands_EnableGrazelandAshlands = Mashed_Ashlands_EnableGrazelandAshlands_def;
            _instance.Mashed_Ashlands_EnableBlightedBogAshlands = Mashed_Ashlands_EnableBlightedBogAshlands_def;
            _instance.Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands = Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands_def;
            _instance.Mashed_Ashlands_EnableMeadowAshlands = Mashed_Ashlands_EnableMeadowAshlands_def;
            _instance.Mashed_Ashlands_EnableMarshAshlands = Mashed_Ashlands_EnableMarshAshlands_def;
            _instance.Mashed_Ashlands_EnableVolcanicBadlandsAshlands = Mashed_Ashlands_EnableVolcanicBadlandsAshlands_def;
            _instance.Mashed_Ashlands_EnableDustplainAshlands = Mashed_Ashlands_EnableDustplainAshlands_def;
            _instance.Mashed_Ashlands_EnableHighlandAshlands = Mashed_Ashlands_EnableHighlandAshlands_def;
            _instance.Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands = Mashed_Ashlands_EnableBlightedPetrifiedForestAshlands_def;
            _instance.Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands = Mashed_Ashlands_EnableVolcanicBasaltHillsAshlands_def;
        }

        public static void ResetSettings_Incident()
        {
            _instance.Mashed_Ashlands_CliffRacerEnableExtinction = Mashed_Ashlands_CliffRacerEnableExtinction_def;
            _instance.Mashed_Ashlands_CliffRacerEnableTracker = Mashed_Ashlands_CliffRacerEnableTracker_def;
            _instance.Mashed_Ashlands_CliffRacerWildPopulation = Mashed_Ashlands_CliffRacerWildPopulation_def;
            _instance.Mashed_Ashlands_CliffRacerEnableReturn = Mashed_Ashlands_CliffRacerEnableReturn_def;
            _instance.Mashed_Ashlands_CliffRacerEnableReturnThreshold = Mashed_Ashlands_CliffRacerEnableReturnThreshold_def;
            _instance.Mashed_Ashlands_CliffRacerEnableSwarm = Mashed_Ashlands_CliffRacerEnableSwarm_def;
            _instance.Mashed_Ashlands_CliffRacerSwarmMinSize = Mashed_Ashlands_CliffRacerSwarmMinSize_def;
            _instance.Mashed_Ashlands_CliffRacerSwarmMaxSize = Mashed_Ashlands_CliffRacerSwarmMaxSize_def;
            _instance.Mashed_Ashlands_CliffRacerMutantChance = Mashed_Ashlands_CliffRacerMutantChance_def;
        }

        public static void ResetSettings_CliffRacer()
        {
            _instance.Mashed_Ashlands_CliffRacerEnableExtinction = Mashed_Ashlands_CliffRacerEnableExtinction_def;
            _instance.Mashed_Ashlands_CliffRacerEnableTracker = Mashed_Ashlands_CliffRacerEnableTracker_def;
            _instance.Mashed_Ashlands_CliffRacerWildPopulation = Mashed_Ashlands_CliffRacerWildPopulation_def;
            _instance.Mashed_Ashlands_CliffRacerEnableReturn = Mashed_Ashlands_CliffRacerEnableReturn_def;
            _instance.Mashed_Ashlands_CliffRacerEnableReturnThreshold = Mashed_Ashlands_CliffRacerEnableReturnThreshold_def;
            _instance.Mashed_Ashlands_CliffRacerEnableSwarm = Mashed_Ashlands_CliffRacerEnableSwarm_def;
            _instance.Mashed_Ashlands_CliffRacerSwarmMinSize = Mashed_Ashlands_CliffRacerSwarmMinSize_def;
            _instance.Mashed_Ashlands_CliffRacerSwarmMaxSize = Mashed_Ashlands_CliffRacerSwarmMaxSize_def;
            _instance.Mashed_Ashlands_CliffRacerMutantChance = Mashed_Ashlands_CliffRacerMutantChance_def;
        }

        public static void ResetSettings_AshStorm()
        {
            _instance.Mashed_Ashlands_AshStormCauseBuildup = Mashed_Ashlands_AshStormCauseBuildup_def;
            _instance.Mashed_Ashlands_AshStormAffectsCaravan = Mashed_Ashlands_AshStormAffectsCaravan_def;
            _instance.Mashed_Ashlands_AshStormBuildupMult = Mashed_Ashlands_AshStormBuildupMult_def;

            _instance.Mashed_Ashlands_AshStormCauseBlinded = Mashed_Ashlands_AshStormCauseBlinded_def;
            _instance.Mashed_Ashlands_AshStormBlindedChance = Mashed_Ashlands_AshStormBlindedChance_def;

            _instance.Mashed_Ashlands_AshStormCauseCloggedServo = Mashed_Ashlands_AshStormCauseCloggedServo_def;
            _instance.Mashed_Ashlands_AshStormCloggedServoChance = Mashed_Ashlands_AshStormCloggedServoChance_def;

            _instance.Mashed_Ashlands_AshStormDamagePlants = Mashed_Ashlands_AshStormDamagePlants_def;
            _instance.Mashed_Ashlands_AshStormAvgPlantDamage = Mashed_Ashlands_AshStormAvgPlantDamage_def;

            _instance.Mashed_Ashlands_AshStormDamageBuildings = Mashed_Ashlands_AshStormDamageBuildings_def;

            _instance.Mashed_Ashlands_AshStormBreakdownBuildings = Mashed_Ashlands_AshStormBreakdownBuildings_def;
            _instance.Mashed_Ashlands_AshStormBreakdownBuildingsChance = Mashed_Ashlands_AshStormBreakdownBuildingsChance_def;
        }

        public static void ResetSettings_AshBlight()
        {
            _instance.Mashed_Ashlands_AshBlightCanSpread = Mashed_Ashlands_AshBlightCanSpread_def;
            _instance.Mashed_Ashlands_AshBlightCanSpreadToPlants = Mashed_Ashlands_AshBlightCanSpreadToPlants_def;
            _instance.Mashed_Ashlands_AshBlightWandersIn = Mashed_Ashlands_AshBlightWandersIn_def;

            _instance.Mashed_Ashlands_BlightStormCaravanAmbush = Mashed_Ashlands_BlightStormCaravanAmbush_def;
            _instance.Mashed_Ashlands_BlightStormBlightAnimals = Mashed_Ashlands_BlightStormBlightAnimals_def;
            _instance.Mashed_Ashlands_BlightStormBlightPlayerAnimals = Mashed_Ashlands_BlightStormBlightPlayerAnimals_def;
            _instance.Mashed_Ashlands_BlightStormBlightNonPlayerAnimals = Mashed_Ashlands_BlightStormBlightNonPlayerAnimals_def;

            _instance.Mashed_Ashlands_BlightStormBlightPlants = Mashed_Ashlands_BlightStormBlightPlants_def;
            _instance.Mashed_Ashlands_BlightStormBlightWildPlants = Mashed_Ashlands_BlightStormBlightWildPlants_def;
            _instance.Mashed_Ashlands_BlightStormBlightPlantsNumber = Mashed_Ashlands_BlightStormBlightPlantsNumber_def;
        }

        public static void ResetSettings_OtherConditions()
        {
            _instance.Mashed_Ashlands_MiasmaAffectsCaravan = Mashed_Ashlands_MiasmaAffectsCaravan_def;

            _instance.Mashed_Ashlands_EarthquakeShake = Mashed_Ashlands_EarthquakeShake_def;
            _instance.Mashed_Ashlands_EarthquakeCollapseMountains = Mashed_Ashlands_EarthquakeCollapseMountains_def;
            _instance.Mashed_Ashlands_EarthquakeDamageBuildings = Mashed_Ashlands_EarthquakeDamageBuildings_def;
            _instance.Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer = Mashed_Ashlands_EarthquakeDamageBuildingsNonPlayer_def;
            _instance.Mashed_Ashlands_EarthquakeDamageBuildingsChance = Mashed_Ashlands_EarthquakeDamageBuildingsChance_def;
            _instance.Mashed_Ashlands_EarthquakeDamageBuildingsDamage = Mashed_Ashlands_EarthquakeDamageBuildingsDamage_def;
        }

        public static void ResetSettings_Biome()
        {
            _instance.Mashed_Ashlands_EnableFetcherflyHives = Mashed_Ashlands_EnableFetcherflyHives_def;
            _instance.Mashed_Ashlands_EnableCavePlants = Mashed_Ashlands_EnableCavePlants_def;
            _instance.Mashed_Ashlands_EnableColumnarBasalt = Mashed_Ashlands_EnableColumnarBasalt_def;
        }
    }
}

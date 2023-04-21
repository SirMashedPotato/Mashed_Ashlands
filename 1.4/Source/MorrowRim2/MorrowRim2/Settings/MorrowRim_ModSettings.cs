using Verse;

namespace MorrowRim2
{
    public class MorrowRim_ModSettings : ModSettings
    {
        private static MorrowRim_ModSettings _instance;

        /* ==========[GETTERS]========== */
        //world gen
        public static bool OldBiomeGen => _instance.MorrowRim_TheAshlands_OldBiomeGen;

        public static bool EnableDormantVolcano => _instance.MorrowRim_TheAshlands_EnableDormantVolcano;
        public static int NumberOfDormantVolcano => _instance.MorrowRim_TheAshlands_NumberOfDormantVolcano;
        public static bool EnableActiveVolcano => _instance.MorrowRim_TheAshlands_EnableActiveVolcano;
        public static int NumberOfActiveVolcano => _instance.MorrowRim_TheAshlands_NumberOfActiveVolcano;
        public static bool EnableBlightedVolcano => _instance.MorrowRim_TheAshlands_EnableBlightedVolcano;
        public static int NumberOfBlightedVolcano => _instance.MorrowRim_TheAshlands_NumberOfBlightedVolcano;
        public static bool EnableExtinctVolcano => _instance.MorrowRim_TheAshlands_EnableExtinctVolcano;
        public static int NumberOfExtinctVolcano => _instance.MorrowRim_TheAshlands_NumberOfExtinctVolcano;

        public static int VolcanoMinDistance => _instance.MorrowRim_TheAshlands_VolcanoMinDistance;
        public static int BiomesMaxDistance => _instance.MorrowRim_TheAshlands_BiomesMaxDistance;
        public static bool VolcanoScaleWithWorldSize => _instance.MorrowRim_TheAshlands_VolcanoScaleWithWorldSize;
        public static bool BiomeScaleWithWorldSize => _instance.MorrowRim_TheAshlands_BiomeScaleWithWorldSize;


        public static bool EnableStandardAshlands => _instance.MorrowRim_TheAshlands_EnableStandardAshlands;
        public static bool EnableBlightedAshlands => _instance.MorrowRim_TheAshlands_EnableBlightedAshlands;
        public static bool EnableVolcanicAshlands => _instance.MorrowRim_TheAshlands_EnableVolcanicAshlands;
        public static bool EnableCoralCoastAshlands => _instance.MorrowRim_TheAshlands_EnableCoralCoastAshlands;
        public static bool EnableVolcanicCoralCoastAshlands => _instance.MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands;
        public static bool EnableForestAshlands => _instance.MorrowRim_TheAshlands_EnableForestAshlands;
        public static bool EnableSwampAshlands => _instance.MorrowRim_TheAshlands_EnableSwampAshlands;
        public static bool EnableGrazelandAshlands => _instance.MorrowRim_TheAshlands_EnableGrazelandAshlands;
        public static bool EnableHighlandAshlands => _instance.MorrowRim_TheAshlands_EnableHighlandAshlands;
        public static bool EnableSaltplainAshlands => _instance.MorrowRim_TheAshlands_EnableSaltplainAshlands;
        public static bool EnableCragIslandAshlands => _instance.MorrowRim_TheAshlands_EnableCragIslandAshlands;
        public static bool EnableBlightedCragIslandAshlands => _instance.MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands;
        public static bool EnableVolcanicCragIslandAshlands => _instance.MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands;
        public static bool EnableSwampIslandAshlands => _instance.MorrowRim_TheAshlands_EnableSwampIslandAshlands;
        public static bool EnableBlightedBogAshlands => _instance.MorrowRim_TheAshlands_EnableBlightedBogAshlands;

        public static bool EnableExclusiveRocks => _instance.MorrowRim_TheAshlands_EnableExclusiveRocks;

        //volcano
        public static bool VolcanoAffectedAreaScaleWithWorldSize => _instance.MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize;
        public static int VolcanoMaxAffectedArea => _instance.MorrowRim_TheAshlands_VolcanoMaxAffectedArea;

        public static bool VolcanoEnablePermanentConditions => _instance.MorrowRim_TheAshlands_VolcanoEnablePermanentConditions;
        public static bool VolcanoEnableRandomConditions => _instance.MorrowRim_TheAshlands_VolcanoEnableRandomConditions;

        public static bool VolcanoEnableCategoryChange => _instance.MorrowRim_TheAshlands_VolcanoEnableCategoryChange;

        //ash storm
        public static bool AshStormCauseBuildup => _instance.MorrowRim_TheAshlands_AshStormCauseBuildup;
        public static bool AshStormAffectsCaravan => _instance.MorrowRim_TheAshlands_AshStormAffectsCaravan;
        public static float AshStormBuildupMult => _instance.MorrowRim_TheAshlands_AshStormBuildupMult;

        public static bool AshStormCauseBlinded => _instance.MorrowRim_TheAshlands_AshStormCauseBlinded;
        public static float AshStormBlindedChance => _instance.MorrowRim_TheAshlands_AshStormBlindedChance;

        public static bool AshStormCauseCloggedServo => _instance.MorrowRim_TheAshlands_AshStormCauseCloggedServo;
        public static float AshStormCloggedServoChance => _instance.MorrowRim_TheAshlands_AshStormCloggedServoChance;

        public static bool AshStormDamagePlants => _instance.MorrowRim_TheAshlands_AshStormDamagePlants;
        public static int AshStormAvgPlantDamage => _instance.MorrowRim_TheAshlands_AshStormAvgPlantDamage;

        public static bool AshStormDamageBuildings => _instance.MorrowRim_TheAshlands_AshStormDamageBuildings;

        public static bool AshStormBreakdownBuildings => _instance.MorrowRim_TheAshlands_AshStormBreakdownBuildings;
        public static float AshStormBreakdownBuildingsChance => _instance.MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance;

        public static bool BlightStormBlightAnimals => _instance.MorrowRim_TheAshlands_BlightStormBlightAnimals;
        public static bool BlightStormBlightPlayerAnimals => _instance.MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals;
        public static bool BlightStormBlightNonPlayerAnimals => _instance.MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals;

        public static bool BlightStormBlightPlants => _instance.MorrowRim_TheAshlands_BlightStormBlightPlants;
        public static bool BlightStormBlightWildPlants => _instance.MorrowRim_TheAshlands_BlightStormBlightWildPlants;
        public static int BlightStormBlightPlantsNumber => _instance.MorrowRim_TheAshlands_BlightStormBlightPlantsNumber;

        /* ==========[VARIABLES]========== */
        //world gen
        public bool MorrowRim_TheAshlands_OldBiomeGen = MorrowRim_TheAshlands_OldBiomeGen_def;

        public bool MorrowRim_TheAshlands_EnableDormantVolcano = MorrowRim_TheAshlands_EnableDormantVolcano_def;
        public int MorrowRim_TheAshlands_NumberOfDormantVolcano = MorrowRim_TheAshlands_NumberOfDormantVolcano_def;
        public bool MorrowRim_TheAshlands_EnableActiveVolcano = MorrowRim_TheAshlands_EnableActiveVolcano_def;
        public int MorrowRim_TheAshlands_NumberOfActiveVolcano = MorrowRim_TheAshlands_NumberOfActiveVolcano_def;
        public bool MorrowRim_TheAshlands_EnableBlightedVolcano = MorrowRim_TheAshlands_EnableBlightedVolcano_def;
        public int MorrowRim_TheAshlands_NumberOfBlightedVolcano = MorrowRim_TheAshlands_NumberOfBlightedVolcano_def;
        public bool MorrowRim_TheAshlands_EnableExtinctVolcano = MorrowRim_TheAshlands_EnableExtinctVolcano_def;
        public int MorrowRim_TheAshlands_NumberOfExtinctVolcano = MorrowRim_TheAshlands_NumberOfExtinctVolcano_def;

        public int MorrowRim_TheAshlands_VolcanoMinDistance = MorrowRim_TheAshlands_VolcanoMinDistance_def;
        public int MorrowRim_TheAshlands_BiomesMaxDistance = MorrowRim_TheAshlands_BiomesMaxDistance_def;
        public bool MorrowRim_TheAshlands_VolcanoScaleWithWorldSize = MorrowRim_TheAshlands_VolcanoScaleWithWorldSize_def;
        public bool MorrowRim_TheAshlands_BiomeScaleWithWorldSize = MorrowRim_TheAshlands_BiomeScaleWithWorldSize_def;

        public bool MorrowRim_TheAshlands_EnableStandardAshlands = MorrowRim_TheAshlands_EnableStandardAshlands_def;
        public bool MorrowRim_TheAshlands_EnableBlightedAshlands = MorrowRim_TheAshlands_EnableBlightedAshlands_def;
        public bool MorrowRim_TheAshlands_EnableVolcanicAshlands = MorrowRim_TheAshlands_EnableVolcanicAshlands_def;
        public bool MorrowRim_TheAshlands_EnableCoralCoastAshlands = MorrowRim_TheAshlands_EnableCoralCoastAshlands_def;
        public bool MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands = MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands_def;
        public bool MorrowRim_TheAshlands_EnableForestAshlands = MorrowRim_TheAshlands_EnableForestAshlands_def;
        public bool MorrowRim_TheAshlands_EnableSwampAshlands = MorrowRim_TheAshlands_EnableSwampAshlands_def;
        public bool MorrowRim_TheAshlands_EnableGrazelandAshlands = MorrowRim_TheAshlands_EnableGrazelandAshlands_def;
        public bool MorrowRim_TheAshlands_EnableHighlandAshlands = MorrowRim_TheAshlands_EnableHighlandAshlands_def;
        public bool MorrowRim_TheAshlands_EnableSaltplainAshlands = MorrowRim_TheAshlands_EnableSaltplainAshlands_def;
        public bool MorrowRim_TheAshlands_EnableCragIslandAshlands = MorrowRim_TheAshlands_EnableCragIslandAshlands_def;
        public bool MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands = MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands_def;
        public bool MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands = MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands_def;
        public bool MorrowRim_TheAshlands_EnableSwampIslandAshlands = MorrowRim_TheAshlands_EnableSwampIslandAshlands_def;
        public bool MorrowRim_TheAshlands_EnableBlightedBogAshlands = MorrowRim_TheAshlands_EnableBlightedBogAshlands_def;

        public bool MorrowRim_TheAshlands_EnableExclusiveRocks = MorrowRim_TheAshlands_EnableExclusiveRocks_def;

        //volcano
        public bool MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize = MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize_def;
        public int MorrowRim_TheAshlands_VolcanoMaxAffectedArea = MorrowRim_TheAshlands_VolcanoMaxAffectedArea_def;

        public bool MorrowRim_TheAshlands_VolcanoEnablePermanentConditions = MorrowRim_TheAshlands_VolcanoEnablePermanentConditions_def;
        public bool MorrowRim_TheAshlands_VolcanoEnableRandomConditions = MorrowRim_TheAshlands_VolcanoEnableRandomConditions_def;
        public bool MorrowRim_TheAshlands_VolcanoEnableCategoryChange = MorrowRim_TheAshlands_VolcanoEnableCategoryChange_def;


        //ash storm
        public bool MorrowRim_TheAshlands_AshStormCauseBuildup = MorrowRim_TheAshlands_AshStormCauseBuildup_def;
        public bool MorrowRim_TheAshlands_AshStormAffectsCaravan = MorrowRim_TheAshlands_AshStormAffectsCaravan_def;
        public float MorrowRim_TheAshlands_AshStormBuildupMult = MorrowRim_TheAshlands_AshStormBuildupMult_def;

        public bool MorrowRim_TheAshlands_AshStormCauseBlinded = MorrowRim_TheAshlands_AshStormCauseBlinded_def;
        public float MorrowRim_TheAshlands_AshStormBlindedChance = MorrowRim_TheAshlands_AshStormBlindedChance_def;

        public bool MorrowRim_TheAshlands_AshStormCauseCloggedServo = MorrowRim_TheAshlands_AshStormCauseCloggedServo_def;
        public float MorrowRim_TheAshlands_AshStormCloggedServoChance = MorrowRim_TheAshlands_AshStormCloggedServoChance_def;

        public bool MorrowRim_TheAshlands_AshStormDamagePlants = MorrowRim_TheAshlands_AshStormDamagePlants_def;
        public int MorrowRim_TheAshlands_AshStormAvgPlantDamage = MorrowRim_TheAshlands_AshStormAvgPlantDamage_def;

        public bool MorrowRim_TheAshlands_AshStormDamageBuildings = MorrowRim_TheAshlands_AshStormDamageBuildings_def;

        public bool MorrowRim_TheAshlands_AshStormBreakdownBuildings = MorrowRim_TheAshlands_AshStormBreakdownBuildings_def;
        public float MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance = MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance_def;

        public bool MorrowRim_TheAshlands_BlightStormBlightAnimals = MorrowRim_TheAshlands_BlightStormBlightAnimals_def;
        public bool MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals = MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals_def;
        public bool MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals = MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals_def;

        public bool MorrowRim_TheAshlands_BlightStormBlightPlants = MorrowRim_TheAshlands_BlightStormBlightPlants_def;
        public bool MorrowRim_TheAshlands_BlightStormBlightWildPlants = MorrowRim_TheAshlands_BlightStormBlightWildPlants_def;
        public int MorrowRim_TheAshlands_BlightStormBlightPlantsNumber = MorrowRim_TheAshlands_BlightStormBlightPlantsNumber_def;

        /* ==========[DEFAULTS]========== */
        //world gen
        private static readonly bool MorrowRim_TheAshlands_OldBiomeGen_def = false;

        private static readonly bool MorrowRim_TheAshlands_EnableDormantVolcano_def = true;
        private static readonly int MorrowRim_TheAshlands_NumberOfDormantVolcano_def = 7;
        private static readonly bool MorrowRim_TheAshlands_EnableActiveVolcano_def = true;
        private static readonly int MorrowRim_TheAshlands_NumberOfActiveVolcano_def = 2;
        private static readonly bool MorrowRim_TheAshlands_EnableBlightedVolcano_def = true;
        private static readonly int MorrowRim_TheAshlands_NumberOfBlightedVolcano_def = 1;
        private static readonly bool MorrowRim_TheAshlands_EnableExtinctVolcano_def = true;
        private static readonly int MorrowRim_TheAshlands_NumberOfExtinctVolcano_def = 3;

        private static readonly int MorrowRim_TheAshlands_VolcanoMinDistance_def = 25;
        private static readonly int MorrowRim_TheAshlands_BiomesMaxDistance_def = 25;
        private static readonly bool MorrowRim_TheAshlands_VolcanoScaleWithWorldSize_def = true;
        private static readonly bool MorrowRim_TheAshlands_BiomeScaleWithWorldSize_def = true;

        private static readonly bool MorrowRim_TheAshlands_EnableStandardAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableBlightedAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableVolcanicAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableCoralCoastAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableForestAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableSwampAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableGrazelandAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableHighlandAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableSaltplainAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableCragIslandAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableSwampIslandAshlands_def = true;
        private static readonly bool MorrowRim_TheAshlands_EnableBlightedBogAshlands_def = true;

        private static readonly bool MorrowRim_TheAshlands_EnableExclusiveRocks_def = true;

        //volcano
        private static readonly bool MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize_def = true;
        private static readonly int MorrowRim_TheAshlands_VolcanoMaxAffectedArea_def = 10;

        private static readonly bool MorrowRim_TheAshlands_VolcanoEnablePermanentConditions_def = true;
        private static readonly bool MorrowRim_TheAshlands_VolcanoEnableRandomConditions_def = true;

        private static readonly bool MorrowRim_TheAshlands_VolcanoEnableCategoryChange_def = true;

        //ash storm
        private static readonly bool MorrowRim_TheAshlands_AshStormCauseBuildup_def = true;
        private static readonly bool MorrowRim_TheAshlands_AshStormAffectsCaravan_def = true;
        private static readonly float MorrowRim_TheAshlands_AshStormBuildupMult_def = 1f;

        private static readonly bool MorrowRim_TheAshlands_AshStormCauseBlinded_def = true;
        private static readonly float MorrowRim_TheAshlands_AshStormBlindedChance_def = 0.25f;

        private static readonly bool MorrowRim_TheAshlands_AshStormCauseCloggedServo_def = true;
        private static readonly float MorrowRim_TheAshlands_AshStormCloggedServoChance_def = 0.25f;

        private static readonly bool MorrowRim_TheAshlands_AshStormDamagePlants_def = true;
        private static readonly int MorrowRim_TheAshlands_AshStormAvgPlantDamage_def = 10;

        private static readonly bool MorrowRim_TheAshlands_AshStormDamageBuildings_def = true;

        private static readonly bool MorrowRim_TheAshlands_AshStormBreakdownBuildings_def = false;
        private static readonly float MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance_def = 0.05f;

        private static readonly bool MorrowRim_TheAshlands_BlightStormBlightAnimals_def = true;
        private static readonly bool MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals_def = false;
        private static readonly bool MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals_def = false;

        private static readonly bool MorrowRim_TheAshlands_BlightStormBlightPlants_def = true;
        private static readonly bool MorrowRim_TheAshlands_BlightStormBlightWildPlants_def = false;
        private static readonly int MorrowRim_TheAshlands_BlightStormBlightPlantsNumber_def = 3;

        public MorrowRim_ModSettings()
        {
            _instance = this;
        }

        /* ==========[SAVING]========== */
        public override void ExposeData()
        {
            //world gen
            Scribe_Values.Look(ref MorrowRim_TheAshlands_OldBiomeGen, "MorrowRim_TheAshlands_OldBiomeGen", MorrowRim_TheAshlands_OldBiomeGen);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableDormantVolcano, "MorrowRim_TheAshlands_EnableDormantVolcano", MorrowRim_TheAshlands_EnableDormantVolcano_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_NumberOfDormantVolcano, "MorrowRim_TheAshlands_NumberOfDormantVolcano", MorrowRim_TheAshlands_NumberOfDormantVolcano_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableActiveVolcano, "MorrowRim_TheAshlands_EnableActiveVolcano", MorrowRim_TheAshlands_EnableActiveVolcano_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_NumberOfActiveVolcano, "MorrowRim_TheAshlands_NumberOfActiveVolcano", MorrowRim_TheAshlands_NumberOfActiveVolcano_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableBlightedVolcano, "MorrowRim_TheAshlands_EnableBlightedVolcano", MorrowRim_TheAshlands_EnableBlightedVolcano_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_NumberOfBlightedVolcano, "MorrowRim_TheAshlands_NumberOfBlightedVolcano", MorrowRim_TheAshlands_NumberOfBlightedVolcano_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableExtinctVolcano, "MorrowRim_TheAshlands_EnableExtinctVolcano", MorrowRim_TheAshlands_EnableExtinctVolcano_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_NumberOfExtinctVolcano, "MorrowRim_TheAshlands_NumberOfExtinctVolcano", MorrowRim_TheAshlands_NumberOfExtinctVolcano_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_VolcanoMinDistance, "MorrowRim_TheAshlands_VolcanoMinDistance", MorrowRim_TheAshlands_VolcanoMinDistance_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_BiomesMaxDistance, "MorrowRim_TheAshlands_BiomesMaxDistance", MorrowRim_TheAshlands_BiomesMaxDistance_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_VolcanoScaleWithWorldSize, "MorrowRim_TheAshlands_VolcanoScaleWithWorldSize", MorrowRim_TheAshlands_VolcanoScaleWithWorldSize_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_BiomeScaleWithWorldSize, "MorrowRim_TheAshlands_BiomeScaleWithWorldSize", MorrowRim_TheAshlands_BiomeScaleWithWorldSize_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableStandardAshlands, "MorrowRim_TheAshlands_EnableStandardAshlands", MorrowRim_TheAshlands_EnableStandardAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableBlightedAshlands, "MorrowRim_TheAshlands_EnableBlightedAshlands", MorrowRim_TheAshlands_EnableBlightedAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableVolcanicAshlands, "MorrowRim_TheAshlands_EnableVolcanicAshlands", MorrowRim_TheAshlands_EnableVolcanicAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableCoralCoastAshlands, "MorrowRim_TheAshlands_EnableCoralCoastAshlands", MorrowRim_TheAshlands_EnableCoralCoastAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands, "MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands", MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableForestAshlands, "MorrowRim_TheAshlands_EnableForestAshlands", MorrowRim_TheAshlands_EnableForestAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableSwampAshlands, "MorrowRim_TheAshlands_EnableSwampAshlands", MorrowRim_TheAshlands_EnableSwampAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableGrazelandAshlands, "MorrowRim_TheAshlands_EnableGrazelandAshlands", MorrowRim_TheAshlands_EnableGrazelandAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableHighlandAshlands, "MorrowRim_TheAshlands_EnableHighlandAshlands", MorrowRim_TheAshlands_EnableHighlandAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableSaltplainAshlands, "MorrowRim_TheAshlands_EnableSaltplainAshlands", MorrowRim_TheAshlands_EnableSaltplainAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableCragIslandAshlands, "MorrowRim_TheAshlands_EnableCragIslandAshlands", MorrowRim_TheAshlands_EnableCragIslandAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands, "MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands", MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands, "MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands", MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableSwampIslandAshlands, "MorrowRim_TheAshlands_EnableSwampIslandAshlands", MorrowRim_TheAshlands_EnableSwampIslandAshlands_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableBlightedBogAshlands, "MorrowRim_TheAshlands_EnableBlightedBogAshlands", MorrowRim_TheAshlands_EnableBlightedBogAshlands_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_EnableExclusiveRocks, "MorrowRim_TheAshlands_EnableExclusiveRocks", MorrowRim_TheAshlands_EnableExclusiveRocks_def);

            //volcano
            Scribe_Values.Look(ref MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize, "MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize", MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_VolcanoMaxAffectedArea, "MorrowRim_TheAshlands_VolcanoMaxAffectedArea", MorrowRim_TheAshlands_VolcanoMaxAffectedArea_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_VolcanoEnablePermanentConditions, "MorrowRim_TheAshlands_VolcanoEnablePermanentConditions", MorrowRim_TheAshlands_VolcanoEnablePermanentConditions_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_VolcanoEnableRandomConditions, "MorrowRim_TheAshlands_VolcanoEnableRandomConditions", MorrowRim_TheAshlands_VolcanoEnableRandomConditions_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_VolcanoEnableCategoryChange, "MorrowRim_TheAshlands_VolcanoEnableCategoryChange", MorrowRim_TheAshlands_VolcanoEnableCategoryChange_def);

            //ash storm
            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormCauseBuildup, "MorrowRim_TheAshlands_AshStormCauseBuildup", MorrowRim_TheAshlands_AshStormCauseBuildup_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormAffectsCaravan, "MorrowRim_TheAshlands_AshStormAffectsCaravan", MorrowRim_TheAshlands_AshStormAffectsCaravan_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormBuildupMult, "MorrowRim_TheAshlands_AshStormBuildupMult", MorrowRim_TheAshlands_AshStormBuildupMult_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormCauseBlinded, "MorrowRim_TheAshlands_AshStormCauseBlinded", MorrowRim_TheAshlands_AshStormCauseBlinded_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormBlindedChance, "MorrowRim_TheAshlands_AshStormBlindedChance", MorrowRim_TheAshlands_AshStormBlindedChance_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormCauseCloggedServo, "MorrowRim_TheAshlands_AshStormCauseCloggedServo", MorrowRim_TheAshlands_AshStormCauseCloggedServo_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormCloggedServoChance, "MorrowRim_TheAshlands_AshStormCloggedServoChance", MorrowRim_TheAshlands_AshStormCloggedServoChance_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormDamagePlants, "MorrowRim_TheAshlands_AshStormDamagePlants", MorrowRim_TheAshlands_AshStormDamagePlants_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormAvgPlantDamage, "MorrowRim_TheAshlands_AshStormAvgPlantDamage", MorrowRim_TheAshlands_AshStormAvgPlantDamage_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormDamageBuildings, "MorrowRim_TheAshlands_AshStormDamageBuildings", MorrowRim_TheAshlands_AshStormDamageBuildings_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormBreakdownBuildings, "MorrowRim_TheAshlands_AshStormBreakdownBuildings", MorrowRim_TheAshlands_AshStormBreakdownBuildings_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance, "MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance", MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_BlightStormBlightAnimals, "MorrowRim_TheAshlands_BlightStormBlightAnimals", MorrowRim_TheAshlands_BlightStormBlightAnimals_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals, "MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals", MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals, "MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals", MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals_def);

            Scribe_Values.Look(ref MorrowRim_TheAshlands_BlightStormBlightPlants, "MorrowRim_TheAshlands_BlightStormBlightPlants", MorrowRim_TheAshlands_BlightStormBlightPlants_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_BlightStormBlightWildPlants, "MorrowRim_TheAshlands_BlightStormBlightWildPlants", MorrowRim_TheAshlands_BlightStormBlightWildPlants_def);
            Scribe_Values.Look(ref MorrowRim_TheAshlands_BlightStormBlightPlantsNumber, "MorrowRim_TheAshlands_BlightStormBlightPlantsNumber", MorrowRim_TheAshlands_BlightStormBlightPlantsNumber_def);


            base.ExposeData();
        }

        /* ==========[RESETTING]========== */
        public static void ResetSettings()
        {
            ResetSettings_WorldGen();
            ResetSettings_Volcano();
            ResetSettings_AshStorm();
            ResetSettings_Biome();
        }

        public static void ResetSettings_WorldGen()
        {
            _instance.MorrowRim_TheAshlands_OldBiomeGen = MorrowRim_TheAshlands_OldBiomeGen_def;

            _instance.MorrowRim_TheAshlands_EnableDormantVolcano = MorrowRim_TheAshlands_EnableDormantVolcano_def;
            _instance.MorrowRim_TheAshlands_NumberOfDormantVolcano = MorrowRim_TheAshlands_NumberOfDormantVolcano_def;
            _instance.MorrowRim_TheAshlands_EnableActiveVolcano = MorrowRim_TheAshlands_EnableActiveVolcano_def;
            _instance.MorrowRim_TheAshlands_NumberOfActiveVolcano = MorrowRim_TheAshlands_NumberOfActiveVolcano_def;
            _instance.MorrowRim_TheAshlands_EnableBlightedVolcano = MorrowRim_TheAshlands_EnableBlightedVolcano_def;
            _instance.MorrowRim_TheAshlands_NumberOfBlightedVolcano = MorrowRim_TheAshlands_NumberOfBlightedVolcano_def;
            _instance.MorrowRim_TheAshlands_EnableExtinctVolcano = MorrowRim_TheAshlands_EnableExtinctVolcano_def;
            _instance.MorrowRim_TheAshlands_NumberOfExtinctVolcano = MorrowRim_TheAshlands_NumberOfExtinctVolcano_def;

            _instance.MorrowRim_TheAshlands_VolcanoMinDistance = MorrowRim_TheAshlands_VolcanoMinDistance_def;
            _instance.MorrowRim_TheAshlands_BiomesMaxDistance = MorrowRim_TheAshlands_BiomesMaxDistance_def;
            _instance.MorrowRim_TheAshlands_VolcanoScaleWithWorldSize = MorrowRim_TheAshlands_VolcanoScaleWithWorldSize_def;
            _instance.MorrowRim_TheAshlands_BiomeScaleWithWorldSize = MorrowRim_TheAshlands_BiomeScaleWithWorldSize_def;

            _instance.MorrowRim_TheAshlands_EnableStandardAshlands = MorrowRim_TheAshlands_EnableStandardAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableBlightedAshlands = MorrowRim_TheAshlands_EnableBlightedAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableVolcanicAshlands = MorrowRim_TheAshlands_EnableVolcanicAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableCoralCoastAshlands = MorrowRim_TheAshlands_EnableCoralCoastAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands = MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableForestAshlands = MorrowRim_TheAshlands_EnableForestAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableSwampAshlands = MorrowRim_TheAshlands_EnableSwampAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableGrazelandAshlands = MorrowRim_TheAshlands_EnableGrazelandAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableHighlandAshlands = MorrowRim_TheAshlands_EnableHighlandAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableSaltplainAshlands = MorrowRim_TheAshlands_EnableSaltplainAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableCragIslandAshlands = MorrowRim_TheAshlands_EnableCragIslandAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands = MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands = MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableSwampIslandAshlands = MorrowRim_TheAshlands_EnableSwampIslandAshlands_def;
            _instance.MorrowRim_TheAshlands_EnableBlightedBogAshlands = MorrowRim_TheAshlands_EnableBlightedBogAshlands_def;

            _instance.MorrowRim_TheAshlands_EnableExclusiveRocks = MorrowRim_TheAshlands_EnableExclusiveRocks_def;
        }

        public static void ResetSettings_Volcano()
        {
            _instance.MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize = MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize_def;
            _instance.MorrowRim_TheAshlands_VolcanoMaxAffectedArea = MorrowRim_TheAshlands_VolcanoMaxAffectedArea_def;

            _instance.MorrowRim_TheAshlands_VolcanoEnablePermanentConditions = MorrowRim_TheAshlands_VolcanoEnablePermanentConditions_def;
            _instance.MorrowRim_TheAshlands_VolcanoEnableRandomConditions = MorrowRim_TheAshlands_VolcanoEnableRandomConditions_def;

            _instance.MorrowRim_TheAshlands_VolcanoEnableCategoryChange = MorrowRim_TheAshlands_VolcanoEnableCategoryChange_def;
        }

        public static void ResetSettings_AshStorm()
        {
            _instance.MorrowRim_TheAshlands_AshStormCauseBuildup = MorrowRim_TheAshlands_AshStormCauseBuildup_def;
            _instance.MorrowRim_TheAshlands_AshStormAffectsCaravan = MorrowRim_TheAshlands_AshStormAffectsCaravan_def;
            _instance.MorrowRim_TheAshlands_AshStormBuildupMult = MorrowRim_TheAshlands_AshStormBuildupMult_def;

            _instance.MorrowRim_TheAshlands_AshStormCauseBlinded = MorrowRim_TheAshlands_AshStormCauseBlinded_def;
            _instance.MorrowRim_TheAshlands_AshStormBlindedChance = MorrowRim_TheAshlands_AshStormBlindedChance_def;

            _instance.MorrowRim_TheAshlands_AshStormCauseCloggedServo = MorrowRim_TheAshlands_AshStormCauseCloggedServo_def;
            _instance.MorrowRim_TheAshlands_AshStormCloggedServoChance = MorrowRim_TheAshlands_AshStormCloggedServoChance_def;

            _instance.MorrowRim_TheAshlands_AshStormDamagePlants = MorrowRim_TheAshlands_AshStormDamagePlants_def;
            _instance.MorrowRim_TheAshlands_AshStormAvgPlantDamage = MorrowRim_TheAshlands_AshStormAvgPlantDamage_def;

            _instance.MorrowRim_TheAshlands_AshStormDamageBuildings = MorrowRim_TheAshlands_AshStormDamageBuildings_def;

            _instance.MorrowRim_TheAshlands_AshStormBreakdownBuildings = MorrowRim_TheAshlands_AshStormBreakdownBuildings_def;
            _instance.MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance = MorrowRim_TheAshlands_AshStormBreakdownBuildingsChance_def;

            _instance.MorrowRim_TheAshlands_BlightStormBlightAnimals = MorrowRim_TheAshlands_BlightStormBlightAnimals_def;
            _instance.MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals = MorrowRim_TheAshlands_BlightStormBlightPlayerAnimals_def;
            _instance.MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals = MorrowRim_TheAshlands_BlightStormBlightNonPlayerAnimals_def;

            _instance.MorrowRim_TheAshlands_BlightStormBlightPlants = MorrowRim_TheAshlands_BlightStormBlightPlants_def;
            _instance.MorrowRim_TheAshlands_BlightStormBlightWildPlants = MorrowRim_TheAshlands_BlightStormBlightWildPlants_def;
            _instance.MorrowRim_TheAshlands_BlightStormBlightPlantsNumber = MorrowRim_TheAshlands_BlightStormBlightPlantsNumber_def;
    }

        public static void ResetSettings_Biome()
        {

        }
    }
}

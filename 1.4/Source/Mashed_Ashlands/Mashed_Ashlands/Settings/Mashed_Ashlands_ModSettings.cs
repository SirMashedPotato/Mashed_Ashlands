using Verse;

namespace Mashed_Ashlands
{
    public class Mashed_Ashlands_ModSettings : ModSettings
    {
        private static Mashed_Ashlands_ModSettings _instance;

        /* ==========[GETTERS]========== */
        //general
        public static bool OnlySowOnAsh => _instance.Mashed_Ashlands_OnlySowOnAsh;
        public static bool BaseAshResistance => _instance.Mashed_Ashlands_BaseAshResistance;
        public static bool FlowerFeeding => _instance.Mashed_Ashlands_FlowerFeeding;

        //world gen
        public static bool EnableDormantVolcano => _instance.Mashed_Ashlands_EnableDormantVolcano;
        public static int NumberOfDormantVolcano => _instance.Mashed_Ashlands_NumberOfDormantVolcano;
        public static bool EnableActiveVolcano => _instance.Mashed_Ashlands_EnableActiveVolcano;
        public static int NumberOfActiveVolcano => _instance.Mashed_Ashlands_NumberOfActiveVolcano;
        public static bool EnableBlightedVolcano => _instance.Mashed_Ashlands_EnableBlightedVolcano;
        public static int NumberOfBlightedVolcano => _instance.Mashed_Ashlands_NumberOfBlightedVolcano;
        public static bool EnableExtinctVolcano => _instance.Mashed_Ashlands_EnableExtinctVolcano;
        public static int NumberOfExtinctVolcano => _instance.Mashed_Ashlands_NumberOfExtinctVolcano;

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
        public static bool EnableHighlandAshlands => _instance.Mashed_Ashlands_EnableHighlandAshlands;
        public static bool EnableSaltplainAshlands => _instance.Mashed_Ashlands_EnableSaltplainAshlands;
        public static bool EnableCragIslandAshlands => _instance.Mashed_Ashlands_EnableCragIslandAshlands;
        public static bool EnableBlightedCragIslandAshlands => _instance.Mashed_Ashlands_EnableBlightedCragIslandAshlands;
        public static bool EnableVolcanicCragIslandAshlands => _instance.Mashed_Ashlands_EnableVolcanicCragIslandAshlands;
        public static bool EnableSwampIslandAshlands => _instance.Mashed_Ashlands_EnableSwampIslandAshlands;
        public static bool EnableBlightedBogAshlands => _instance.Mashed_Ashlands_EnableBlightedBogAshlands;
        public static bool EnableVolcanicSulphurPitsAshlands => _instance.Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands;
        public static bool EnableMeadowAshlands => _instance.Mashed_Ashlands_EnableMeadowAshlands;
        public static bool EnableMarshAshlands => _instance.Mashed_Ashlands_EnableMarshAshlands;
        public static bool EnableVolcanicThermalValleyAshlands => _instance.Mashed_Ashlands_EnableVolcanicThermalValleyAshlands;
        public static bool EnableVolcanicBadlandsAshlands => _instance.Mashed_Ashlands_EnableVolcanicBadlandsAshlands;

        public static bool EnableExclusiveRocks => _instance.Mashed_Ashlands_EnableExclusiveRocks;
   
        //volcano
        public static bool VolcanoAffectedAreaScaleWithWorldSize => _instance.Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize;
        public static int VolcanoMaxAffectedArea => _instance.Mashed_Ashlands_VolcanoMaxAffectedArea;

        public static bool VolcanoEnablePermanentConditions => _instance.Mashed_Ashlands_VolcanoEnablePermanentConditions;
        public static bool VolcanoEnableRandomConditions => _instance.Mashed_Ashlands_VolcanoEnableRandomConditions;

        public static bool VolcanoEnableCategoryChange => _instance.Mashed_Ashlands_VolcanoEnableCategoryChange;

        //cliff racer
        public static bool EnableCliffRacerExtinction => true;

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

        public static bool BlightStormBlightAnimals => _instance.Mashed_Ashlands_BlightStormBlightAnimals;
        public static bool BlightStormBlightPlayerAnimals => _instance.Mashed_Ashlands_BlightStormBlightPlayerAnimals;
        public static bool BlightStormBlightNonPlayerAnimals => _instance.Mashed_Ashlands_BlightStormBlightNonPlayerAnimals;

        public static bool BlightStormBlightPlants => _instance.Mashed_Ashlands_BlightStormBlightPlants;
        public static bool BlightStormBlightWildPlants => _instance.Mashed_Ashlands_BlightStormBlightWildPlants;
        public static int BlightStormBlightPlantsNumber => _instance.Mashed_Ashlands_BlightStormBlightPlantsNumber;

        //biome
        public static bool EnableExtraGeysers => _instance.Mashed_Ashlands_EnableExtraGeysers;

        /* ==========[VARIABLES]========== */
        //general
        public bool Mashed_Ashlands_OnlySowOnAsh = Mashed_Ashlands_OnlySowOnAsh_def;
        public bool Mashed_Ashlands_BaseAshResistance = Mashed_Ashlands_BaseAshResistance_def;
        public bool Mashed_Ashlands_FlowerFeeding = Mashed_Ashlands_FlowerFeeding_def;

        //world gen

        public bool Mashed_Ashlands_EnableDormantVolcano = Mashed_Ashlands_EnableDormantVolcano_def;
        public int Mashed_Ashlands_NumberOfDormantVolcano = Mashed_Ashlands_NumberOfDormantVolcano_def;
        public bool Mashed_Ashlands_EnableActiveVolcano = Mashed_Ashlands_EnableActiveVolcano_def;
        public int Mashed_Ashlands_NumberOfActiveVolcano = Mashed_Ashlands_NumberOfActiveVolcano_def;
        public bool Mashed_Ashlands_EnableBlightedVolcano = Mashed_Ashlands_EnableBlightedVolcano_def;
        public int Mashed_Ashlands_NumberOfBlightedVolcano = Mashed_Ashlands_NumberOfBlightedVolcano_def;
        public bool Mashed_Ashlands_EnableExtinctVolcano = Mashed_Ashlands_EnableExtinctVolcano_def;
        public int Mashed_Ashlands_NumberOfExtinctVolcano = Mashed_Ashlands_NumberOfExtinctVolcano_def;

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
        public bool Mashed_Ashlands_EnableHighlandAshlands = Mashed_Ashlands_EnableHighlandAshlands_def;
        public bool Mashed_Ashlands_EnableSaltplainAshlands = Mashed_Ashlands_EnableSaltplainAshlands_def;
        public bool Mashed_Ashlands_EnableCragIslandAshlands = Mashed_Ashlands_EnableCragIslandAshlands_def;
        public bool Mashed_Ashlands_EnableBlightedCragIslandAshlands = Mashed_Ashlands_EnableBlightedCragIslandAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicCragIslandAshlands = Mashed_Ashlands_EnableVolcanicCragIslandAshlands_def;
        public bool Mashed_Ashlands_EnableSwampIslandAshlands = Mashed_Ashlands_EnableSwampIslandAshlands_def;
        public bool Mashed_Ashlands_EnableBlightedBogAshlands = Mashed_Ashlands_EnableBlightedBogAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands = Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands_def;
        public bool Mashed_Ashlands_EnableMeadowAshlands = Mashed_Ashlands_EnableMeadowAshlands_def;
        public bool Mashed_Ashlands_EnableMarshAshlands = Mashed_Ashlands_EnableMarshAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicThermalValleyAshlands = Mashed_Ashlands_EnableVolcanicThermalValleyAshlands_def;
        public bool Mashed_Ashlands_EnableVolcanicBadlandsAshlands = Mashed_Ashlands_EnableVolcanicBadlandsAshlands_def;

        public bool Mashed_Ashlands_EnableExclusiveRocks = Mashed_Ashlands_EnableExclusiveRocks_def;

        //volcano
        public bool Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize = Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_def;
        public int Mashed_Ashlands_VolcanoMaxAffectedArea = Mashed_Ashlands_VolcanoMaxAffectedArea_def;

        public bool Mashed_Ashlands_VolcanoEnablePermanentConditions = Mashed_Ashlands_VolcanoEnablePermanentConditions_def;
        public bool Mashed_Ashlands_VolcanoEnableRandomConditions = Mashed_Ashlands_VolcanoEnableRandomConditions_def;
        public bool Mashed_Ashlands_VolcanoEnableCategoryChange = Mashed_Ashlands_VolcanoEnableCategoryChange_def;

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

        public bool Mashed_Ashlands_BlightStormBlightAnimals = Mashed_Ashlands_BlightStormBlightAnimals_def;
        public bool Mashed_Ashlands_BlightStormBlightPlayerAnimals = Mashed_Ashlands_BlightStormBlightPlayerAnimals_def;
        public bool Mashed_Ashlands_BlightStormBlightNonPlayerAnimals = Mashed_Ashlands_BlightStormBlightNonPlayerAnimals_def;

        public bool Mashed_Ashlands_BlightStormBlightPlants = Mashed_Ashlands_BlightStormBlightPlants_def;
        public bool Mashed_Ashlands_BlightStormBlightWildPlants = Mashed_Ashlands_BlightStormBlightWildPlants_def;
        public int Mashed_Ashlands_BlightStormBlightPlantsNumber = Mashed_Ashlands_BlightStormBlightPlantsNumber_def;

        //biome
        public bool Mashed_Ashlands_EnableExtraGeysers = Mashed_Ashlands_EnableExtraGeysers_def;

        /* ==========[DEFAULTS]========== */
        //general
        private static readonly bool Mashed_Ashlands_OnlySowOnAsh_def = true;
        private static readonly bool Mashed_Ashlands_BaseAshResistance_def = true;
        private static readonly bool Mashed_Ashlands_FlowerFeeding_def = true;

        //world gen

        private static readonly bool Mashed_Ashlands_EnableDormantVolcano_def = true;
        private static readonly int Mashed_Ashlands_NumberOfDormantVolcano_def = 4;
        private static readonly bool Mashed_Ashlands_EnableActiveVolcano_def = true;
        private static readonly int Mashed_Ashlands_NumberOfActiveVolcano_def = 4;
        private static readonly bool Mashed_Ashlands_EnableBlightedVolcano_def = true;
        private static readonly int Mashed_Ashlands_NumberOfBlightedVolcano_def = 2;
        private static readonly bool Mashed_Ashlands_EnableExtinctVolcano_def = true;
        private static readonly int Mashed_Ashlands_NumberOfExtinctVolcano_def = 4;

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
        private static readonly bool Mashed_Ashlands_EnableHighlandAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableSaltplainAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableCragIslandAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableBlightedCragIslandAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicCragIslandAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableSwampIslandAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableBlightedBogAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableMeadowAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableMarshAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicThermalValleyAshlands_def = true;
        private static readonly bool Mashed_Ashlands_EnableVolcanicBadlandsAshlands_def = true;

        private static readonly bool Mashed_Ashlands_EnableExclusiveRocks_def = true;

        //volcano
        private static readonly bool Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_def = true;
        private static readonly int Mashed_Ashlands_VolcanoMaxAffectedArea_def = 10;

        private static readonly bool Mashed_Ashlands_VolcanoEnablePermanentConditions_def = true;
        private static readonly bool Mashed_Ashlands_VolcanoEnableRandomConditions_def = true;

        private static readonly bool Mashed_Ashlands_VolcanoEnableCategoryChange_def = true;

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

        private static readonly bool Mashed_Ashlands_BlightStormBlightAnimals_def = true;
        private static readonly bool Mashed_Ashlands_BlightStormBlightPlayerAnimals_def = false;
        private static readonly bool Mashed_Ashlands_BlightStormBlightNonPlayerAnimals_def = false;

        private static readonly bool Mashed_Ashlands_BlightStormBlightPlants_def = true;
        private static readonly bool Mashed_Ashlands_BlightStormBlightWildPlants_def = false;
        private static readonly int Mashed_Ashlands_BlightStormBlightPlantsNumber_def = 3;

        //biome
        private static readonly bool Mashed_Ashlands_EnableExtraGeysers_def = true;

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
            Scribe_Values.Look(ref Mashed_Ashlands_FlowerFeeding, "Mashed_Ashlands_FlowerFeeding", Mashed_Ashlands_FlowerFeeding_def);

            //world gen
            Scribe_Values.Look(ref Mashed_Ashlands_EnableDormantVolcano, "Mashed_Ashlands_EnableDormantVolcano", Mashed_Ashlands_EnableDormantVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_NumberOfDormantVolcano, "Mashed_Ashlands_NumberOfDormantVolcano", Mashed_Ashlands_NumberOfDormantVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableActiveVolcano, "Mashed_Ashlands_EnableActiveVolcano", Mashed_Ashlands_EnableActiveVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_NumberOfActiveVolcano, "Mashed_Ashlands_NumberOfActiveVolcano", Mashed_Ashlands_NumberOfActiveVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableBlightedVolcano, "Mashed_Ashlands_EnableBlightedVolcano", Mashed_Ashlands_EnableBlightedVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_NumberOfBlightedVolcano, "Mashed_Ashlands_NumberOfBlightedVolcano", Mashed_Ashlands_NumberOfBlightedVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableExtinctVolcano, "Mashed_Ashlands_EnableExtinctVolcano", Mashed_Ashlands_EnableExtinctVolcano_def);
            Scribe_Values.Look(ref Mashed_Ashlands_NumberOfExtinctVolcano, "Mashed_Ashlands_NumberOfExtinctVolcano", Mashed_Ashlands_NumberOfExtinctVolcano_def);

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
            Scribe_Values.Look(ref Mashed_Ashlands_EnableHighlandAshlands, "Mashed_Ashlands_EnableHighlandAshlands", Mashed_Ashlands_EnableHighlandAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableSaltplainAshlands, "Mashed_Ashlands_EnableSaltplainAshlands", Mashed_Ashlands_EnableSaltplainAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableCragIslandAshlands, "Mashed_Ashlands_EnableCragIslandAshlands", Mashed_Ashlands_EnableCragIslandAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableBlightedCragIslandAshlands, "Mashed_Ashlands_EnableBlightedCragIslandAshlands", Mashed_Ashlands_EnableBlightedCragIslandAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicCragIslandAshlands, "Mashed_Ashlands_EnableVolcanicCragIslandAshlands", Mashed_Ashlands_EnableVolcanicCragIslandAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableSwampIslandAshlands, "Mashed_Ashlands_EnableSwampIslandAshlands", Mashed_Ashlands_EnableSwampIslandAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableBlightedBogAshlands, "Mashed_Ashlands_EnableBlightedBogAshlands", Mashed_Ashlands_EnableBlightedBogAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands, "Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands", Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableMeadowAshlands, "Mashed_Ashlands_EnableMeadowAshlands", Mashed_Ashlands_EnableMeadowAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableMarshAshlands, "Mashed_Ashlands_EnableMarshAshlands", Mashed_Ashlands_EnableMarshAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicThermalValleyAshlands, "Mashed_Ashlands_EnableVolcanicThermalValleyAshlands", Mashed_Ashlands_EnableVolcanicThermalValleyAshlands_def);
            Scribe_Values.Look(ref Mashed_Ashlands_EnableVolcanicBadlandsAshlands, "Mashed_Ashlands_EnableVolcanicBadlandsAshlands", Mashed_Ashlands_EnableVolcanicBadlandsAshlands_def);

            Scribe_Values.Look(ref Mashed_Ashlands_EnableExclusiveRocks, "Mashed_Ashlands_EnableExclusiveRocks", Mashed_Ashlands_EnableExclusiveRocks_def);

            //volcano
             Scribe_Values.Look(ref Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize, "Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize", Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoMaxAffectedArea, "Mashed_Ashlands_VolcanoMaxAffectedArea", Mashed_Ashlands_VolcanoMaxAffectedArea_def);

            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoEnablePermanentConditions, "Mashed_Ashlands_VolcanoEnablePermanentConditions", Mashed_Ashlands_VolcanoEnablePermanentConditions_def);
            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoEnableRandomConditions, "Mashed_Ashlands_VolcanoEnableRandomConditions", Mashed_Ashlands_VolcanoEnableRandomConditions_def);

            Scribe_Values.Look(ref Mashed_Ashlands_VolcanoEnableCategoryChange, "Mashed_Ashlands_VolcanoEnableCategoryChange", Mashed_Ashlands_VolcanoEnableCategoryChange_def);

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

            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightAnimals, "Mashed_Ashlands_BlightStormBlightAnimals", Mashed_Ashlands_BlightStormBlightAnimals_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightPlayerAnimals, "Mashed_Ashlands_BlightStormBlightPlayerAnimals", Mashed_Ashlands_BlightStormBlightPlayerAnimals_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightNonPlayerAnimals, "Mashed_Ashlands_BlightStormBlightNonPlayerAnimals", Mashed_Ashlands_BlightStormBlightNonPlayerAnimals_def);

            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightPlants, "Mashed_Ashlands_BlightStormBlightPlants", Mashed_Ashlands_BlightStormBlightPlants_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightWildPlants, "Mashed_Ashlands_BlightStormBlightWildPlants", Mashed_Ashlands_BlightStormBlightWildPlants_def);
            Scribe_Values.Look(ref Mashed_Ashlands_BlightStormBlightPlantsNumber, "Mashed_Ashlands_BlightStormBlightPlantsNumber", Mashed_Ashlands_BlightStormBlightPlantsNumber_def);

            //biome
            Scribe_Values.Look(ref Mashed_Ashlands_EnableExtraGeysers, "Mashed_Ashlands_EnableExtraGeysers", Mashed_Ashlands_EnableExtraGeysers_def);

            base.ExposeData();
        }

        /* ==========[RESETTING]========== */
        public static void ResetSettings()
        {
            ResetSettings_General();
            ResetSettings_WorldGen();
            ResetSettings_Volcano();
            ResetSettings_AshStorm();
            ResetSettings_Biome();
        }

        public static void ResetSettings_General()
        {
            _instance.Mashed_Ashlands_OnlySowOnAsh = Mashed_Ashlands_OnlySowOnAsh_def;
            _instance.Mashed_Ashlands_BaseAshResistance = Mashed_Ashlands_BaseAshResistance_def;
            _instance.Mashed_Ashlands_FlowerFeeding = Mashed_Ashlands_FlowerFeeding_def;
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
            _instance.Mashed_Ashlands_EnableHighlandAshlands = Mashed_Ashlands_EnableHighlandAshlands_def;
            _instance.Mashed_Ashlands_EnableSaltplainAshlands = Mashed_Ashlands_EnableSaltplainAshlands_def;
            _instance.Mashed_Ashlands_EnableCragIslandAshlands = Mashed_Ashlands_EnableCragIslandAshlands_def;
            _instance.Mashed_Ashlands_EnableBlightedCragIslandAshlands = Mashed_Ashlands_EnableBlightedCragIslandAshlands_def;
            _instance.Mashed_Ashlands_EnableVolcanicCragIslandAshlands = Mashed_Ashlands_EnableVolcanicCragIslandAshlands_def;
            _instance.Mashed_Ashlands_EnableSwampIslandAshlands = Mashed_Ashlands_EnableSwampIslandAshlands_def;
            _instance.Mashed_Ashlands_EnableBlightedBogAshlands = Mashed_Ashlands_EnableBlightedBogAshlands_def;
            _instance.Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands = Mashed_Ashlands_EnableVolcanicSulphurPitsAshlands_def;

            _instance.Mashed_Ashlands_EnableExclusiveRocks = Mashed_Ashlands_EnableExclusiveRocks_def;
        }

        public static void ResetSettings_Volcano()
        {
            _instance.Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize = Mashed_Ashlands_VolcanoAffectedAreaScaleWithWorldSize_def;
            _instance.Mashed_Ashlands_VolcanoMaxAffectedArea = Mashed_Ashlands_VolcanoMaxAffectedArea_def;

            _instance.Mashed_Ashlands_VolcanoEnablePermanentConditions = Mashed_Ashlands_VolcanoEnablePermanentConditions_def;
            _instance.Mashed_Ashlands_VolcanoEnableRandomConditions = Mashed_Ashlands_VolcanoEnableRandomConditions_def;

            _instance.Mashed_Ashlands_VolcanoEnableCategoryChange = Mashed_Ashlands_VolcanoEnableCategoryChange_def;
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

            _instance.Mashed_Ashlands_BlightStormBlightAnimals = Mashed_Ashlands_BlightStormBlightAnimals_def;
            _instance.Mashed_Ashlands_BlightStormBlightPlayerAnimals = Mashed_Ashlands_BlightStormBlightPlayerAnimals_def;
            _instance.Mashed_Ashlands_BlightStormBlightNonPlayerAnimals = Mashed_Ashlands_BlightStormBlightNonPlayerAnimals_def;

            _instance.Mashed_Ashlands_BlightStormBlightPlants = Mashed_Ashlands_BlightStormBlightPlants_def;
            _instance.Mashed_Ashlands_BlightStormBlightWildPlants = Mashed_Ashlands_BlightStormBlightWildPlants_def;
            _instance.Mashed_Ashlands_BlightStormBlightPlantsNumber = Mashed_Ashlands_BlightStormBlightPlantsNumber_def;
    }

        public static void ResetSettings_Biome()
        {
            _instance.Mashed_Ashlands_EnableExtraGeysers = Mashed_Ashlands_EnableExtraGeysers_def;
        }
    }
}

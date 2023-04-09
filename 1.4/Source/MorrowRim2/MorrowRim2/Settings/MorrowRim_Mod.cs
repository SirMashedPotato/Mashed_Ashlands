using UnityEngine;
using Verse;

namespace MorrowRim2
{
    public class MorrowRim_Mod : Mod
    {
        MorrowRim_ModSettings settings;
        public MorrowRim_Mod(ModContentPack contentPack) : base(contentPack)
        {
            settings = GetSettings<MorrowRim_ModSettings>();
        }

        public override string SettingsCategory() => "MorrowRim_TheAshlands_ModName".Translate();
        private int page = 0;
        private static Vector2 scrollPosition = Vector2.zero;

        /// <summary>
        /// 
        /// </summary>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            var firstColumnWidth = (inRect.width - Listing.ColumnSpacing) * 3.5f / 5f;
            var secondColumnWidth = inRect.width - Listing.ColumnSpacing - firstColumnWidth;

            var outerRect = new Rect(inRect.x, inRect.y, firstColumnWidth, inRect.height);
            var innerRect = new Rect(0f, 0f, firstColumnWidth - 24f, inRect.height * 2.5f);
            Widgets.BeginScrollView(outerRect, ref scrollPosition, innerRect, true);

            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            //get page
            switch (page)
            {
                case 1:
                    listing_Standard = SettingsPage_WorldGen(listing_Standard);
                    break;
                case 2:
                    listing_Standard = SettingsPage_Volcano(listing_Standard);
                    break;

                default:
                    listing_Standard = SettingsPage_General(listing_Standard);
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
            TooltipHandler.TipRegion(rectPageGeneral, "MorrowRim_TheAshlands_PageGeneral".Translate());
            if (Widgets.ButtonText(rectPageGeneral, "MorrowRim_TheAshlands_PageGeneral".Translate(), true, true, true))
            {
                page = 0;
            }
            listing_Standard.Gap();

            Rect rectPageWorldGen = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageWorldGen, "MorrowRim_TheAshlands_PageWorldGen".Translate());
            if (Widgets.ButtonText(rectPageWorldGen, "MorrowRim_TheAshlands_PageWorldGen".Translate(), true, true, true))
            {
                page = 1;
            }
            listing_Standard.Gap();

            Rect rectPageVolcano = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageVolcano, "MorrowRim_TheAshlands_PageVolcano".Translate());
            if (Widgets.ButtonText(rectPageVolcano, "MorrowRim_TheAshlands_PageVolcano".Translate(), true, true, true))
            {
                page = 2;
            }
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "MorrowRim_Reset".Translate());
            if (Widgets.ButtonText(rectDefault, "MorrowRim_Reset".Translate(), true, true, true))
            {
                MorrowRim_ModSettings.ResetSettings();
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
                case 1:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "MorrowRim_ResetPage".Translate("MorrowRim_TheAshlands_PageWorldGen".Translate()));
                    if (Widgets.ButtonText(rectDefault, "MorrowRim_ResetPage".Translate("MorrowRim_TheAshlands_PageWorldGen".Translate()), true, true, true))
                    {
                        MorrowRim_ModSettings.ResetSettings_WorldGen();
                    }
                    break;

                case 2:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "MorrowRim_ResetPage".Translate("MorrowRim_TheAshlands_PageVolcano".Translate()));
                    if (Widgets.ButtonText(rectDefault, "MorrowRim_ResetPage".Translate("MorrowRim_TheAshlands_PageVolcano".Translate()), true, true, true))
                    {
                        MorrowRim_ModSettings.ResetSettings_Volcano();
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsPage_General(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("MorrowRim_TheAshlands_PageGeneral".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsPage_WorldGen(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("MorrowRim_TheAshlands_PageWorldGen".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();
            /*
            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_OldBiomeGen".Translate(), ref settings.MorrowRim_TheAshlands_OldBiomeGen, "MorrowRim_TheAshlands_OldBiomeGen_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();
            */
            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableDormantVolcano".Translate(), ref settings.MorrowRim_TheAshlands_EnableDormantVolcano, "MorrowRim_TheAshlands_EnableDormantVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("MorrowRim_TheAshlands_NumberOfDormantVolcano".Translate(settings.MorrowRim_TheAshlands_NumberOfDormantVolcano));
            settings.MorrowRim_TheAshlands_NumberOfDormantVolcano = (int)listing_Standard.Slider(settings.MorrowRim_TheAshlands_NumberOfDormantVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableExtinctVolcano".Translate(), ref settings.MorrowRim_TheAshlands_EnableExtinctVolcano, "MorrowRim_TheAshlands_EnableExtinctVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("MorrowRim_TheAshlands_NumberOfExtinctVolcano".Translate(settings.MorrowRim_TheAshlands_NumberOfExtinctVolcano));
            settings.MorrowRim_TheAshlands_NumberOfExtinctVolcano = (int)listing_Standard.Slider(settings.MorrowRim_TheAshlands_NumberOfExtinctVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableActiveVolcano".Translate(), ref settings.MorrowRim_TheAshlands_EnableActiveVolcano, "MorrowRim_TheAshlands_EnableActiveVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("MorrowRim_TheAshlands_NumberOfActiveVolcano".Translate(settings.MorrowRim_TheAshlands_NumberOfActiveVolcano));
            settings.MorrowRim_TheAshlands_NumberOfActiveVolcano = (int)listing_Standard.Slider(settings.MorrowRim_TheAshlands_NumberOfActiveVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableBlightedVolcano".Translate(), ref settings.MorrowRim_TheAshlands_EnableBlightedVolcano, "MorrowRim_TheAshlands_EnableBlightedVolcano_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("MorrowRim_TheAshlands_NumberOfBlightedVolcano".Translate(settings.MorrowRim_TheAshlands_NumberOfBlightedVolcano));
            settings.MorrowRim_TheAshlands_NumberOfBlightedVolcano = (int)listing_Standard.Slider(settings.MorrowRim_TheAshlands_NumberOfBlightedVolcano, 1, 50);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_VolcanoScaleWithWorldSize".Translate(), ref settings.MorrowRim_TheAshlands_VolcanoScaleWithWorldSize, "MorrowRim_TheAshlands_VolcanoScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_BiomeScaleWithWorldSize".Translate(), ref settings.MorrowRim_TheAshlands_BiomeScaleWithWorldSize, "MorrowRim_TheAshlands_BiomeScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("MorrowRim_TheAshlands_VolcanoMinDistance".Translate(settings.MorrowRim_TheAshlands_VolcanoMinDistance));
            settings.MorrowRim_TheAshlands_VolcanoMinDistance = (int)listing_Standard.Slider(settings.MorrowRim_TheAshlands_VolcanoMinDistance, 1, 200);
            listing_Standard.Gap();

            listing_Standard.Label("MorrowRim_TheAshlands_BiomesMaxDistance".Translate(settings.MorrowRim_TheAshlands_BiomesMaxDistance));
            settings.MorrowRim_TheAshlands_BiomesMaxDistance = (int)listing_Standard.Slider(settings.MorrowRim_TheAshlands_BiomesMaxDistance, 1, 200);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableStandardAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableStandardAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableCragIslandAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableCragIslandAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableCoralCoastAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableCoralCoastAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableForestAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableForestAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableGrazelandAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableGrazelandAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableHighlandAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableHighlandAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableSaltplainAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableSaltplainAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableSwampAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableSwampAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableSwampIslandAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableSwampIslandAshlands);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableBlightedAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableBlightedAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableBlightedCragIslandAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableBlightedBogAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableBlightedBogAshlands);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableVolcanicAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableVolcanicAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableVolcanicCragIslandAshlands);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands".Translate(), ref settings.MorrowRim_TheAshlands_EnableVolcanicCoralCoastAshlands);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        /// <summary>
        /// 
        /// </summary>
        private Listing_Standard SettingsPage_Volcano(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("MorrowRim_TheAshlands_PageVolcano".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize".Translate(), ref settings.MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize, "MorrowRim_TheAshlands_VolcanoAffectedAreaScaleWithWorldSize_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("MorrowRim_TheAshlands_VolcanoMaxAffectedArea".Translate(settings.MorrowRim_TheAshlands_VolcanoMaxAffectedArea), -1, "MorrowRim_TheAshlands_VolcanoMaxAffectedArea_Tooltip".Translate());
            settings.MorrowRim_TheAshlands_VolcanoMaxAffectedArea = (int)listing_Standard.Slider(settings.MorrowRim_TheAshlands_VolcanoMaxAffectedArea, 1, 200);

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }
    }
}

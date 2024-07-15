using RimWorld;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class Page_AshlandWorldGenSettings : Page
    {
        public override string PageTitle => "Mashed_Ashlands_ModName".Translate() + " " + "Mashed_Ashlands_PageWorldGen".Translate();

        private static Vector2 scrollPosition = Vector2.zero;

        public override void DoWindowContents(Rect inRect)
        {
            DrawPageTitle(inRect);
            Rect mainRect = GetMainRect(inRect, 0f, false);

            Listing_Standard listing_Standard = new Listing_Standard();

            Rect outerRect = new Rect(mainRect.x, mainRect.y, mainRect.width, mainRect.height);
            Rect innerRect = new Rect(0f, 0f, mainRect.width - 30, mainRect.height * 3);
            Widgets.BeginScrollView(outerRect, ref scrollPosition, innerRect, true);

            listing_Standard.Begin(innerRect);

            listing_Standard = Mashed_Ashlands_Mod.SettingsPage_WorldGen(listing_Standard, Mashed_Ashlands_ModSettings.Instance, true);

            listing_Standard.End();
            Widgets.EndScrollView();

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

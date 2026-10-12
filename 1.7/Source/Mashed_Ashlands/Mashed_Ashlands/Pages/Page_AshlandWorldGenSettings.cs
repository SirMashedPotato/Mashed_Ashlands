using RimWorld;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class Page_AshlandWorldGenSettings : Page
    {
        public override string PageTitle => "Mashed_Ashlands_ModName".Translate() + " " + "Mashed_Ashlands_PageWorldGen".Translate();

        public override void DoWindowContents(Rect inRect)
        {
            DrawPageTitle(inRect);

            Rect mainRect = GetMainRect(inRect, 0f, false);
            mainRect.yMin += 45f;

            SettingsPage_WorldGen.DoSettingsPage(mainRect, Mashed_Ashlands_ModSettings.Instance, true);
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

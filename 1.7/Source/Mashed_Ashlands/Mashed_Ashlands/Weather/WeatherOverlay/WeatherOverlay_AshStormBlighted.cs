using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_AshStormBlighted : WeatherOverlay_AshStorm
    {
        public static new readonly Color snowColour1 = new Color(0.28f, 0.08f, 0.05f, 1f);
        public static new readonly Color snowColour2 = new Color(0.28f, 0.08f, 0.05f, 0.8f);
        public static new readonly Color fogColour = new Color(0.18f, 0.08f, 0.05f, 1f);

        public override void SetOverlayColor(Color color)
        {
            SnowLayer1.color = snowColour1;
            SnowLayer2.color = snowColour2;
            FogLayer.color = fogColour;
        }
    }
}
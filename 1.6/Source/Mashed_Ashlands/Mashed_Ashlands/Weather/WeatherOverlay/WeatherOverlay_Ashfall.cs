
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_Ashfall : WeatherOverlayDualPanner
    {
        private static readonly Material OverlayWorld = MatLoader.LoadMat("Weather/SnowOverlayWorld");
        public static readonly Color overlayColour = new Color(0.25f, 0.21f, 0.21f, 1f);

        public WeatherOverlay_Ashfall()
        {
            worldOverlayMat = OverlayWorld;
            worldOverlayPanSpeed1 = 0.002f;
            worldPanDir1 = new Vector2(-0.25f, -1f);
            worldPanDir1.Normalize();
            worldOverlayPanSpeed2 = 0.003f;
            worldPanDir2 = new Vector2(-0.24f, -1f);
            worldPanDir2.Normalize();
        }

        public override void SetOverlayColor(Color color)
        {
            OverlayWorld.color = overlayColour;
        }
    }
}

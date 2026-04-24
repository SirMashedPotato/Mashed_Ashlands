using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_SulphuricRain : WeatherOverlayDualPanner
    {
        private static readonly Material OverlayWorld = MatLoader.LoadMat("Weather/RainOverlayWorld");
        public static readonly Color overlayColour = new Color(0.9f, 1f, 0.7f, 0.8f);

        public WeatherOverlay_SulphuricRain()
        {
            worldOverlayMat = OverlayWorld;
            worldOverlayPanSpeed1 = 0.015f;
            worldPanDir1 = new Vector2(-0.25f, -1f);
            worldPanDir1.Normalize();
            worldOverlayPanSpeed2 = 0.022f;
            worldPanDir2 = new Vector2(-0.24f, -1f);
            worldPanDir2.Normalize();
        }

        public override void SetOverlayColor(Color color)
        {
            OverlayWorld.color = overlayColour;
        }
    }
}

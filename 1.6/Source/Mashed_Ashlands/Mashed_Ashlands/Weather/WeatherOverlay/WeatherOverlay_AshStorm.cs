using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_AshStorm : WeatherOverlayDualPanner
    {
        private static readonly Material AshStormWorld = MatLoader.LoadMat("Weather/SnowOverlayWorld");

        public WeatherOverlay_AshStorm()
        {
            worldOverlayMat = AshStormWorld;
            worldOverlayPanSpeed1 = 0.045f;
            worldOverlayPanSpeed2 = 0.045f;
            worldPanDir1 = new Vector2(1f, 1f);
            worldPanDir2 = new Vector2(1f, 1f);
            worldPanDir1.Normalize();
            worldPanDir2.Normalize();
        }

        public override void SetOverlayColor(Color color) => base.SetOverlayColor(new Color(214f, 95f, 97f));
    }
}
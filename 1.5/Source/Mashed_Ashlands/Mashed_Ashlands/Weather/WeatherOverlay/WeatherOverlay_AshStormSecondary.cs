using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_AshStormSecondary : SkyOverlay
    {
        public WeatherOverlay_AshStormSecondary()
        {
            worldOverlayMat = AshStormWorld;
            OverlayColor = new Color(214f, 95f, 97f);
            worldOverlayPanSpeed1 = 0.045f;
            worldOverlayPanSpeed2 = 0.045f;
            worldPanDir1 = new Vector2(1f, 1f);
            worldPanDir2 = new Vector2(1f, 1f);
        }

        private static readonly Material AshStormWorld = MatLoader.LoadMat("Weather/SnowOverlayWorld");
    }
}
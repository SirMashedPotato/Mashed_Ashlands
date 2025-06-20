using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_DustStorm : SkyOverlay
    {
        public WeatherOverlay_DustStorm()
        {
            worldOverlayMat = DustStormWorld;
            OverlayColor = new Color(104f, 95f, 97f);
            worldOverlayPanSpeed1 = 0.5f;
            worldOverlayPanSpeed2 = 0.5f;
            worldPanDir1 = new Vector2(1f, 1f);
            worldPanDir2 = new Vector2(1f, 1f);
            worldPanDir1.Normalize();
            worldPanDir2.Normalize();
        }

        private static readonly Material DustStormWorld = MatLoader.LoadMat("Weather/SnowOverlayWorld", -1);
    }
}

using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_AshStormPrimary : SkyOverlay
    {
        public WeatherOverlay_AshStormPrimary()
        {
            AshStormWorld.mainTexture = FogOverlayWorld.mainTexture;
            worldOverlayMat = AshStormWorld;
            OverlayColor = new Color(84f, 75f, 77f);
            worldOverlayPanSpeed1 = 0.02f;
            worldOverlayPanSpeed2 = 0.02f;
            worldPanDir1 = new Vector2(1f, 1f);
            worldPanDir2 = new Vector2(1f, 1f);
        }

        // Yes snow, becuase if I start with fog it's barely visible
        private static readonly Material AshStormWorld = MatLoader.LoadMat("Weather/SnowOverlayWorld");
        private static readonly Material FogOverlayWorld = MatLoader.LoadMat("Weather/FogOverlayWorld");
    }
}
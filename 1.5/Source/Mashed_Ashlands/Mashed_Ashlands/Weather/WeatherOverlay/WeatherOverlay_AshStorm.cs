using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_AshStorm : SkyOverlay
	{
		public WeatherOverlay_AshStorm(float colorMult = 1f, float panSpeed1 = 0.05f, float panSpeed2 = 0.05f, float worldPanDir = 1f)
		{
			worldOverlayMat = AshStormWorld;
			OverlayColor = new Color(114f, 95f, 97f) * colorMult;
			worldOverlayPanSpeed1 = panSpeed1;
			worldOverlayPanSpeed2 = panSpeed2;
			worldPanDir1 = new Vector2(worldPanDir, worldPanDir);
			worldPanDir2 = new Vector2(worldPanDir, worldPanDir);
            worldPanDir1.Normalize();
            worldPanDir2.Normalize();
        }

		private static readonly Material AshStormWorld = MatLoader.LoadMat("Weather/SnowOverlayWorld", -1);
	}
}

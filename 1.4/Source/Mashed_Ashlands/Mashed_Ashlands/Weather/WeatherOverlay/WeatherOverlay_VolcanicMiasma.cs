using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_VolcanicMiasma : SkyOverlay
	{
		public WeatherOverlay_VolcanicMiasma()
		{
			worldOverlayMat = MiasmaOverlayWorld;
			worldOverlayPanSpeed1 = 0.001f;
			worldOverlayPanSpeed2 = 0.0005f;
			worldPanDir1 = new Vector2(1f, 1f);
			worldPanDir2 = new Vector2(1f, -1f);
		}

		private static readonly Material MiasmaOverlayWorld = MatLoader.LoadMat("Weather/FogOverlayWorld", -1);
	}
}

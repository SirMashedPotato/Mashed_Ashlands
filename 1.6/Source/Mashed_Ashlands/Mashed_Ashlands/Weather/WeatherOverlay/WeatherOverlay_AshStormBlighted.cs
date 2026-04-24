using LudeonTK;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_AshStormBlighted : WeatherOverlayDualPanner
    {
        private static readonly Material SnowLayer = MatLoader.LoadMat("Weather/SnowOverlayWorld");
        private static readonly Material FogLayer = MatLoader.LoadMat("Weather/FogOverlayWorld");

        public static readonly Color snowColour = new Color(0.28f, 0.08f, 0.05f, 1f);
        public static readonly Color fogColour = new Color(0.18f, 0.08f, 0.05f, 1f);

        private static readonly ComplexCurve speedCurve = new ComplexCurve(
            new UnityEngine.Keyframe(0f, 0f),
            new UnityEngine.Keyframe(1f, 1f),
            new UnityEngine.Keyframe(2f, 1.15f),
            new UnityEngine.Keyframe(3f, 1.3f));

        private readonly TexturePannerSpeedCurve snowLayerPanner1 = new TexturePannerSpeedCurve(SnowLayer, "_MainTex", speedCurve, new Vector2(1f, 1f), 0.095f);
        private readonly TexturePannerSpeedCurve snowLayerPanner2 = new TexturePannerSpeedCurve(SnowLayer, "_MainTex2", speedCurve, new Vector2(1f, 1f), 0.095f);

        private readonly TexturePannerSpeedCurve fogLayerPanner1 = new TexturePannerSpeedCurve(FogLayer, "_MainTex", speedCurve, new Vector2(1f, 1f), 0.035f);
        private readonly TexturePannerSpeedCurve fogLayerPanner2 = new TexturePannerSpeedCurve(FogLayer, "_MainTex2", speedCurve, new Vector2(1f, 1f), 0.035f);

        public override void DrawOverlay(Map map)
        {
            SkyOverlay.DrawWorldOverlay(map, SnowLayer);
            SkyOverlay.DrawWorldOverlay(map, FogLayer);
        }

        public override void SetOverlayColor(Color color)
        {
            SnowLayer.color = snowColour;
            FogLayer.color = fogColour;
        }

        public override void TickOverlay(Map map, float lerpFactor)
        {
            snowLayerPanner1.Tick();
            snowLayerPanner2.Tick();
            fogLayerPanner1.Tick();
            fogLayerPanner2.Tick();
        }
    }
}
using LudeonTK;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class WeatherOverlay_AshStorm : WeatherOverlayDualPanner
    {
        public static readonly Material SnowLayer1 = MatLoader.LoadMat("Weather/SnowOverlayWorld");
        public static readonly Material SnowLayer2 = MatLoader.LoadMat("Weather/SnowOverlayWorld");
        public static readonly Material FogLayer = MatLoader.LoadMat("Weather/FogOverlayWorld");


        public static readonly Color snowColour1 = new Color(0.45f, 0.41f, 0.41f, 1f);
        public static readonly Color snowColour2 = new Color(0.45f, 0.41f, 0.41f, 0.8f);
        public static readonly Color fogColour = new Color(0.25f, 0.21f, 0.21f, 1f);

        private static readonly ComplexCurve speedCurve = new ComplexCurve(
            new UnityEngine.Keyframe(0f, 0f), 
            new UnityEngine.Keyframe(1f, 1f), 
            new UnityEngine.Keyframe(2f, 1.15f), 
            new UnityEngine.Keyframe(3f, 1.3f));

        private readonly TexturePannerSpeedCurve snowLayer1Panner1 = new TexturePannerSpeedCurve(SnowLayer1, "_MainTex", speedCurve, new Vector2(1f, 1f), 0.095f);
        private readonly TexturePannerSpeedCurve snowLayer1Panner2 = new TexturePannerSpeedCurve(SnowLayer1, "_MainTex2", speedCurve, new Vector2(1f, 1f), 0.095f);

        private readonly TexturePannerSpeedCurve snowLayer2Panner1 = new TexturePannerSpeedCurve(SnowLayer2, "_MainTex", speedCurve, new Vector2(1f, 1f), 0.065f);
        private readonly TexturePannerSpeedCurve snowLayer2Panner2 = new TexturePannerSpeedCurve(SnowLayer2, "_MainTex2", speedCurve, new Vector2(1f, 1f), 0.065f);

        private readonly TexturePannerSpeedCurve fogLayerPanner1 = new TexturePannerSpeedCurve(FogLayer, "_MainTex", speedCurve, new Vector2(1f, 1f), 0.035f);
        private readonly TexturePannerSpeedCurve fogLayerPanner2 = new TexturePannerSpeedCurve(FogLayer, "_MainTex2", speedCurve, new Vector2(1f, 1f), 0.035f);

        public override void DrawOverlay(Map map)
        {
            SkyOverlay.DrawWorldOverlay(map, SnowLayer1);
            SkyOverlay.DrawWorldOverlay(map, SnowLayer2);
            SkyOverlay.DrawWorldOverlay(map, FogLayer);
        }

        public override void SetOverlayColor(Color color)
        {
            SnowLayer1.color = snowColour1;
            SnowLayer2.color = snowColour2;
            FogLayer.color = fogColour;
        }

        public override void TickOverlay(Map map, float lerpFactor)
        {
            snowLayer1Panner1.Tick();
            snowLayer1Panner2.Tick();
            snowLayer2Panner1.Tick();
            snowLayer2Panner2.Tick();
            fogLayerPanner1.Tick();
            fogLayerPanner2.Tick();
        }
    }
}
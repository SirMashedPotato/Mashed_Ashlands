using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class GameCondition_AshStormBlighted : GameCondition_AshStorm
    {
        public override SkyTarget? SkyTarget(Map map)
        {
            return new SkyTarget?(new SkyTarget(SkyGlow, AshStormColours, 1f, 1f));
        }

        public override List<SkyOverlay> SkyOverlays(Map map)
        {
            return overlays;
        }

        private const float SkyGlow = 0.55f;
        private SkyColorSet AshStormColours = new SkyColorSet(new ColorInt(169, 68, 63).ToColor, new ColorInt(234, 204, 204).ToColor, new Color(1f, 0.9f, 0.9f), SkyGlow);
        private readonly List<SkyOverlay> overlays = new List<SkyOverlay>
        {
            new WeatherOverlay_AshStormBlighted(),
        };
    }
}

using RimWorld;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class WeatherEvent_BlightstormFlash : WeatherEvent_LightningFlash
    {
        private static readonly SkyColorSet BlightstormFlashColors = new SkyColorSet(
            new Color(1f, 0.85f, 0.8f), 
            new Color(0.85f, 0.7f, 0.7f), 
            new Color(1f, 0.95f, 0.9f), 1.15f);
        public override SkyTarget SkyTarget => new SkyTarget(1f, BlightstormFlashColors, 1f, 1f);

        public WeatherEvent_BlightstormFlash(Map map) : base(map)
        {
            duration = Rand.Range(15, 60);
            shadowVector = new Vector2(Rand.Range(-5f, 5f), Rand.Range(-5f, 0f));
        }
    }
}

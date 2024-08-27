using Verse;

namespace Mashed_Ashlands
{
    public class HediffCompProperties_Regeneration : HediffCompProperties
    {
        public HediffCompProperties_Regeneration()
        {
            compClass = typeof(HediffComp_Regeneration);
        }
        public int ticks = 100;
        public float baseNumber = 3f;
        public float severity = 0.5f;
        public bool regenParts = false;
        public bool fireDisables = false;
    }
}
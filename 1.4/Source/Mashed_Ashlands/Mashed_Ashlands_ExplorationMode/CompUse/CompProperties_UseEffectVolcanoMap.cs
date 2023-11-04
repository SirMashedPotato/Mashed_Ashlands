using RimWorld;

namespace Mashed_Ashlands_ExplorationMode
{
    public class CompProperties_UseEffectVolcanoMap : CompProperties_UseEffect
    {
        public CompProperties_UseEffectVolcanoMap()
        {
            compClass = typeof(CompUseEffect_VolcanoMap);
        }

        public int size;
        public int locations;
    }
}

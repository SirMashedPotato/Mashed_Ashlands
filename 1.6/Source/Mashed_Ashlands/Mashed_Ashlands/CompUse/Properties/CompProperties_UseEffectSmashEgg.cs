using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_UseEffectSmashEgg : CompProperties
    {
        public CompProperties_UseEffectSmashEgg() => compClass = typeof(CompUseEffect_SmashEgg);

        public SoundDef soundDef;
        public float baseManhunterRadius = 0;
        public PawnKindDef manhunterKind;
    }
}

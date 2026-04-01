using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_UseEffectSpawnPawn : CompProperties
    {
        public CompProperties_UseEffectSpawnPawn() => compClass = typeof(CompUseEffect_SpawnPawn);

        public PawnKindDef pawnKindDef;
    }
}
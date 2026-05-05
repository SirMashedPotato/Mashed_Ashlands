using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_UseEffectSpawnPawn : CompProperties
    {
        public CompProperties_UseEffectSpawnPawn() => compClass = typeof(CompUseEffect_SpawnPawn);

        public List<PawnKindDef> pawnKindDefs;
        public float extraHediffChance = 0.06f;
        public HediffDef extraHediff;
    }
}
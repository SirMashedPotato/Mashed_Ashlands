using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class CompUseEffect_SpawnPawn : CompUseEffect
    {
        public CompProperties_UseEffectSpawnPawn Props => (CompProperties_UseEffectSpawnPawn)props;

        public override void PrepareTick()
        {
        }

        public override void DoEffect(Pawn usedBy)
        {
            Pawn pawn = PawnGenerator.GeneratePawn(Props.pawnKindDef, usedBy.Faction ?? null);
            if (Rand.Chance(0.06f))
            {
                pawn.health.AddHediff(HediffDefOf.AlcoholAddiction);
            }
            GenSpawn.Spawn(pawn, parent.Position, usedBy.Map, Rot4.Random, WipeMode.Vanish, false);
            Messages.Message("Mashed_Ashlands_SummonedDaedra".Translate(parent,usedBy, pawn), pawn, MessageTypeDefOf.NeutralEvent, false);
        }
    }
}

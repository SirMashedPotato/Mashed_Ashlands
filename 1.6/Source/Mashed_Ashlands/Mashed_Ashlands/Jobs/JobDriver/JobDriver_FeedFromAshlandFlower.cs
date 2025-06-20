using System.Collections.Generic;
using Verse.AI;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class JobDriver_FeedFromAshlandFlower : JobDriver
    {
        protected Thing Plant => job.targetA.Thing;

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return pawn.Reserve(Plant, job);
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            float durationMult = 1f / pawn.GetStatValue(RimWorld.StatDefOf.EatingSpeed);
            float durationTicks = Plant.def.ingestible.baseIngestTicks * durationMult;
            this.FailOnDespawnedOrNull(TargetIndex.A);
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            yield return Toils_General.WaitWith(TargetIndex.A, (int)durationTicks, true, true);
            yield return Toils_General.Do(delegate
            {
                pawn.needs.TryGetNeed(NeedDefOf.Food).CurLevel = pawn.needs.TryGetNeed(NeedDefOf.Food).MaxLevel;
                Plant.TakeDamage(new DamageInfo(DamageDefOf.Deterioration, Rand.Range(5,10)));
            });
            yield break;
        }
    }
}

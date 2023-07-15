using System.Collections.Generic;
using Verse.AI;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class JobDriver_FeedFromAshlandFlower : JobDriver
    {
        protected Thing Plant
        {
            get
            {
                return job.targetA.Thing;
            }
        }

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return true;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedOrNull(TargetIndex.A);
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            Toils_General.WaitWith(TargetIndex.A, DurationTicks, false, true);
            yield return Toils_General.Do(delegate
            {
                pawn.needs.TryGetNeed(NeedDefOf.Food).CurLevel = pawn.needs.TryGetNeed(NeedDefOf.Food).MaxLevel;
                Plant.TakeDamage(new DamageInfo(DamageDefOf.Deterioration, Rand.Range(5,10)));
            });
            yield break;
        }

        private const int DurationTicks = 100;
    }
}

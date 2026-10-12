using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using Verse.Sound;

namespace Mashed_Ashlands
{
    public class JobDriver_Restore : JobDriver
    {
        private Thing RestoreTarget => TargetThingA;

        private Comp_Restorable CompRestorable => RestoreTarget.TryGetComp<Comp_Restorable>();

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return pawn.Reserve(RestoreTarget, job, 1, -1, null, errorOnFailed);
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
            this.FailOn(() => !CompRestorable.CanRestoreNow(pawn));
            PathEndMode pathEndMode = (TargetThingA.def.hasInteractionCell ? PathEndMode.InteractionCell : PathEndMode.ClosestTouch);
            yield return Toils_Goto.GotoThing(TargetIndex.A, pathEndMode);
            Toil toil = ToilMaker.MakeToil("MakeNewToils");
            toil.handlingFacing = true;

            toil.tickAction = delegate
            {
                float statValue = pawn.GetStatValue(CompRestorable.Props.restoreStatDef ?? RimWorld.StatDefOf.ConstructionSpeed);
                CompRestorable.ProgressRestoration(statValue);
                pawn.skills.Learn(SkillDefOf.Construction, 0.1f);
                pawn.rotationTracker.FaceTarget(RestoreTarget);
            };

            if (CompRestorable.Props.effectRestoring != null)
            {
                toil.WithEffect(() => CompRestorable.Props.effectRestoring, () => RestoreTarget.OccupiedRect().ClosestCellTo(pawn.Position));
            }

            toil.WithProgressBar(TargetIndex.A, () => CompRestorable.ProgressPercent, interpolateBetweenActorAndTarget: false, -0.5f, alwaysShow: true);
            toil.AddFinishAction(delegate
            {
                if (CompRestorable.IsRestored)
                {
                    CompRestorable.Props.restorationCompletedSound?.PlayOneShot(RestoreTarget);
                }
            });

            toil.FailOnCannotTouch(TargetIndex.A, pathEndMode);
            toil.FailOn(() => CompRestorable.IsRestored);
            toil.defaultCompleteMode = ToilCompleteMode.Never;
            toil.activeSkill = () => SkillDefOf.Construction;
            yield return toil;
        }
    }
}

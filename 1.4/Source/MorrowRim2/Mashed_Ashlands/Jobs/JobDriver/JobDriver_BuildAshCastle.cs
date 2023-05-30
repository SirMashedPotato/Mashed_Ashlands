using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace Mashed_Ashlands
{
    public class JobDriver_BuildAshCastle : JobDriver
	{
		public override bool TryMakePreToilReservations(bool errorOnFailed)
		{
			return pawn.Reserve(job.targetA, job, 1, -1, null, errorOnFailed);
		}

		protected override IEnumerable<Toil> MakeNewToils()
		{
			yield return Toils_Goto.GotoCell(TargetIndex.A, PathEndMode.Touch);
            Toil doWork = new Toil
            {
                initAction = delegate ()
                {
                    workLeft = BaseWorkAmount;
                }
            };
            doWork.tickAction = delegate ()
			{
				workLeft -= doWork.actor.GetStatValue(RimWorld.StatDefOf.ConstructionSpeed, true) * 1.7f;
				if (workLeft <= 0f)
				{
					Thing thing = ThingMaker.MakeThing(ThingDefOf.MorrowRim_AshCastle, null);
					thing.SetFaction(pawn.Faction, null);
					GenSpawn.Spawn(thing, TargetLocA, Map, WipeMode.Vanish);
					ReadyForNextToil();
					return;
				}
				JoyUtility.JoyTickCheckEnd(pawn, JoyTickFullJoyAction.EndJob, 1f, null);
			};
			doWork.defaultCompleteMode = ToilCompleteMode.Never;
			doWork.FailOn(() => !JoyUtility.EnjoyableOutsideNow(pawn, null));
			doWork.FailOnCannotTouch(TargetIndex.A, PathEndMode.Touch);
			doWork.activeSkill = () => SkillDefOf.Construction;
			yield return doWork;
			yield break;
		}

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref workLeft, "workLeft", 0f, false);
		}

		private float workLeft = -1000f;

		protected const int BaseWorkAmount = 2300;
	}
}

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
            doWork.tickIntervalAction = delegate (int delta)
			{
				workLeft -= doWork.actor.GetStatValue(RimWorld.StatDefOf.ConstructionSpeed, true) * 1.7f;
				if (workLeft <= 0f)
				{
					Thing thing = ThingMaker.MakeThing(ThingDefOf.Mashed_Ashlands_AshCastle, null);
					thing.SetFaction(Faction.OfPlayer, null);
					GenSpawn.Spawn(thing, TargetLocA, Map, WipeMode.Vanish);
					ReadyForNextToil();
					return;
				}
				JoyUtility.JoyTickCheckEnd(pawn, delta);
			};
			doWork.defaultCompleteMode = ToilCompleteMode.Never;
			doWork.FailOn(() => !JoyUtility.EnjoyableOutsideNow(pawn, null));
			doWork.FailOnCannotTouch(TargetIndex.A, PathEndMode.Touch);
			doWork.activeSkill = () => SkillDefOf.Construction;
			yield return doWork;
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

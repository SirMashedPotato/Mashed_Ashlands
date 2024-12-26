using RimWorld;
using System;
using Verse;
using Verse.AI;

namespace Mashed_Ashlands
{
    public class JobGiver_FeedFromAshlandFlower : ThinkNode_JobGiver
    {
		protected override Job TryGiveJob(Pawn pawn)
		{
			if (pawn.Downed)
			{
				return null;
			}
			Thing plant = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForGroup(ThingRequestGroup.Plant), PathEndMode.OnCell,
				TraverseParms.For(pawn, Danger.Deadly, TraverseMode.ByPawn, false), radius, new Predicate<Thing>(AshlandFlower), null, 0, -1, false, RegionType.Set_Passable, false);
			return plant == null ? null : JobMaker.MakeJob(JobDefOf.Mashed_Ashlands_FeedFromAshlandFlower, plant);
		}

		public bool AshlandFlower(Thing plant)
        {
			return OnStartupUtility.ashlandFlowerPlants.Contains(plant.def) && plant is Plant p && p.Growth >= minGrowth;
        }

		public float radius = 20f;
		public float minGrowth = 0.7f;
	}
}

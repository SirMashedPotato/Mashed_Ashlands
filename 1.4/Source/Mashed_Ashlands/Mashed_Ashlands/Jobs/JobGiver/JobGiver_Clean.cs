using Verse;
using Verse.AI;
using RimWorld;
using System.Collections.Generic;
using System.Linq;

namespace Mashed_Ashlands
{
    public class JobGiver_Clean : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            bool validator(Thing t)
            {
                if (!pawn.CanReserve(t, 1, -1, null))
                {
                    return false;
                }
                return true;
            }

            if (pawn.Map.listerFilthInHomeArea.FilthInHomeArea.Count == 0)
            {
                return null;
            }
            Thing filth = GenClosest.ClosestThing_Global_Reachable(pawn.Position, pawn.Map, pawn.Map.listerFilthInHomeArea.FilthInHomeArea, 
                PathEndMode.OnCell, TraverseParms.For(pawn), radius, validator);

            if (filth != null)
            {
                return CreateJob(pawn, filth);
            }
            return null;
        }

        public Job CreateJob(Pawn pawn, Thing initialFilth)
        {
            Job result = new Job(RimWorld.JobDefOf.Clean);
            Map map = pawn.Map;
            Room room = initialFilth.GetRoom();
            IEnumerable<IntVec3> cells = GenRadial.RadialCellsAround(initialFilth.Position, radius, true);
            foreach (IntVec3 cell in cells)
            {
                if (cell.InBounds(map) && cell.GetRoom(map) == room && cell.InAllowedArea(pawn))
                {
                    foreach (Thing thing in cell.GetThingList(map).Where(x => x is Filth))
                    {
                        if (pawn.CanReserve(thing, 1, -1, null) && thing.Map.areaManager.Home[thing.Position])
                        {
                            result.AddQueuedTarget(TargetIndex.A, thing);
                        }
                    }
                }
            }
            if (result.targetQueueA != null && result.targetQueueA.Count >= 5)
            {
                result.targetQueueA.SortBy((LocalTargetInfo targ) => targ.Cell.DistanceToSquared(pawn.Position));
            }
            return result;
        }

        public float radius = 6f;
    }
}

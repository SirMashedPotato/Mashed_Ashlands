using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace Mashed_Ashlands
{
    public class WorkGiver_Restore : WorkGiver_Scanner
    {
        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
        {
            foreach (Designation item in pawn.Map.designationManager.SpawnedDesignationsOfDef(DesignationDefOf.Mashed_Ashlands_Restore))
            {
                yield return item.target.Thing;
            }
        }

        public override bool ShouldSkip(Pawn pawn, bool forced = false)
        {
            return !pawn.Map.designationManager.AnySpawnedDesignationOfDef(DesignationDefOf.Mashed_Ashlands_Restore);
        }

        public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
        {
            Comp_Restorable compRestorable = t.TryGetComp<Comp_Restorable>();
            if (compRestorable == null)
            {
                return false;
            }

            if (!compRestorable.IsMarked)
            {
                return false;
            }

            AcceptanceReport acceptanceReport = compRestorable.CanRestoreNow(pawn);
            if (!acceptanceReport.Accepted && !acceptanceReport.Reason.NullOrEmpty())
            {
                JobFailReason.Is(acceptanceReport.Reason);
            }

            if (!pawn.CanReserve(t))
            {
                return false;
            }

            return acceptanceReport.Accepted;
        }

        public override Job JobOnThing(Pawn pawn, Thing t, bool forced = false)
        {
            if (t.TryGetComp<Comp_Restorable>() == null)
            {
                return null;
            }

            Job job = JobMaker.MakeJob(JobDefOf.Mashed_Ashlands_Restore, t);
            job.playerForced = forced;
            return job;
        }
    }
}

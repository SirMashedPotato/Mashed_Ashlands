using Verse;
using Verse.AI;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class JobGiver_Insult : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            Pawn target = TryFindNewTarget(pawn);
            if (target == null)
            {
                return null;
            }
            return JobMaker.MakeJob(RimWorld.JobDefOf.Insult, target);
        }

        private Pawn TryFindNewTarget(Pawn pawn)
        {
            InsultingSpreeMentalStateUtility.GetInsultCandidatesFor(pawn, candidates, false);
            if (!candidates.NullOrEmpty())
            {
                return candidates.RandomElement();
            }
            return null;
        }

        private static readonly List<Pawn> candidates = new List<Pawn>();
    }
}

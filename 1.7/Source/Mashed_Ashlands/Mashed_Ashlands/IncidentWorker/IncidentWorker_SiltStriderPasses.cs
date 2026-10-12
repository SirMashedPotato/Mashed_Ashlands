using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class IncidentWorker_SiltStriderPasses : IncidentWorker_AshlandsSpecific
    {
		protected override bool CanFireNowSub(IncidentParms parms)
		{
            return base.CanFireNowSub(parms) && CanWanderIn(parms, ThingDefOf.Mashed_Ashlands_SiltStrider);
        }

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			if (!TryFindEntryCell(map, out IntVec3 intVec))
			{
				return false;
			}
			int stayTicks = Rand.RangeInclusive(90000, 150000);
            if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(intVec, map, 10f, out IntVec3 invalid))
            {
                invalid = IntVec3.Invalid;
            }
            Pawn pawn = null;

			IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
			pawn = PawnGenerator.GeneratePawn(PawnKindDefOf.Mashed_Ashlands_SiltStrider, null);
			GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);
			pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + stayTicks;
			if (invalid.IsValid)
			{
				pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(invalid, map, 10, null);
			}

			SendStandardLetter(def.letterLabel, def.letterText, def.letterDef, parms, pawn);
			return true;
		}
    }
}

using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class IncidentWorker_SiltStriderPasses : IncidentWorker
    {
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			Map map = (Map)parms.target;
            return !map.gameConditionManager.ConditionIsActive(RimWorld.GameConditionDefOf.ToxicFallout)
                && (!ModsConfig.BiotechActive || !map.gameConditionManager.ConditionIsActive(RimWorld.GameConditionDefOf.NoxiousHaze))
                && map.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(ThingDefOf.Mashed_Ashlands_SiltStrider) && TryFindEntryCell(map, out _);
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

		private bool TryFindEntryCell(Map map, out IntVec3 cell)
        {
            return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f, false, null);
        }
    }
}

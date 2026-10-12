using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace Mashed_Ashlands
{
    public class JoyGiver_BuildAshCastle : JoyGiver
	{

		public override Job TryGiveJob(Pawn pawn)
		{
			if (!Mashed_Ashlands_ModSettings.AshcanoJoy)
			{
				return null;
			}
			if (pawn.WorkTypeIsDisabled(WorkTypeDefOf.Construction))
			{
				return null;
			}
			if (!JoyUtility.EnjoyableOutsideNow(pawn, null))
			{
				return null;
			}
			IntVec3 c = TryFindAshCastleBuildCell(pawn);
			if (!c.IsValid)
			{
				return null;
			}
			return JobMaker.MakeJob(def.jobDef, c);
		}

		private static IntVec3 TryFindAshCastleBuildCell(Pawn pawn)
		{
            if (!CellFinder.TryFindClosestRegionWith(pawn.GetRegion(RegionType.Set_Passable), TraverseParms.For(pawn, Danger.Deadly, TraverseMode.ByPawn, false, false, false), (Region r) => r.Room.PsychologicallyOutdoors, 100, out Region rootReg, RegionType.Set_Passable))
            {
                return IntVec3.Invalid;
            }
            IntVec3 result = IntVec3.Invalid;
			RegionTraverser.BreadthFirstTraverse(rootReg, (Region from, Region r) => r.District == rootReg.District, delegate (Region r)
			{
				for (int i = 0; i < 5; i++)
				{
					IntVec3 randomCell = r.RandomCell;
					if (IsGoodAshCastleCell(randomCell, pawn))
					{
						result = randomCell;
						return true;
					}
				}
				return false;
			}, 30, RegionType.Set_Passable);
			return result;
		}

		private static bool IsGoodAshCastleCell(IntVec3 c, Pawn pawn)
		{
			if (pawn.Map.snowGrid.GetDepth(c) > MaxSnowDepth)
			{
				return false;
			}
			if (!c.GetTerrain(pawn.Map).affordances.Contains(TerrainAffordanceDefOf.Mashed_Ashlands_AshCastle))
			{
				return false;
			}
			if (!c.GetThingList(pawn.Map).NullOrEmpty())
			{
				return false;
			}
			if (c.IsForbidden(pawn))
			{
				return false;
			}
			if (c.GetEdifice(pawn.Map) != null)
			{
				return false;
			}
			for (int i = 0; i < 9; i++)
			{
				IntVec3 c2 = c + GenAdj.AdjacentCellsAndInside[i];
				if (!c2.InBounds(pawn.Map))
				{
					return false;
				}
				if (!c2.Standable(pawn.Map))
				{
					return false;
				}
				if (pawn.Map.reservationManager.IsReservedAndRespected(c2, pawn))
				{
					return false;
				}
			}
			List<Thing> list = pawn.Map.listerThings.ThingsOfDef(ThingDefOf.Mashed_Ashlands_AshCastle);
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].Position.InHorDistOf(c, MinDistBetweenAshCastle))
				{
					return false;
				}
			}
			return true;
		}

		private const float MaxSnowDepth = 0.5f;
		private const float MinDistBetweenAshCastle = 12f;
	}
}

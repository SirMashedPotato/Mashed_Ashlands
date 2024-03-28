using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace Mashed_Ashlands
{
	/// <summary>
	/// Yea this is basically copy pasted from WorkGiver_Grower
	/// I feel dirty
	/// </summary>
	public class WorkGiver_GrowerAsh : WorkGiver_Scanner
    {
		public override bool AllowUnreachable => true;

		protected virtual bool ExtraRequirements(IPlantToGrowSettable settable, Pawn pawn) => true;


		public static ThingDef CalculateWantedPlantDef(IntVec3 c, Map map)
		{
			IPlantToGrowSettable plantToGrowSettable = c.GetPlantToGrowSettable(map);
			if (plantToGrowSettable == null)
			{
				return null;
			}
			return plantToGrowSettable.GetPlantDefToGrow();
		}

		public override IEnumerable<IntVec3> PotentialWorkCellsGlobal(Pawn pawn)
		{
			Danger maxDanger = pawn.NormalMaxDanger();
			List<Building> bList = pawn.Map.listerBuildings.allBuildingsColonist;
			int num;
			for (int i = 0; i < bList.Count; i = num + 1)
			{
                if (bList[i] is Building_PlantGrower building_PlantGrower && ExtraRequirements(building_PlantGrower, pawn) && !building_PlantGrower.IsForbidden(pawn) && pawn.CanReach(building_PlantGrower, PathEndMode.OnCell, maxDanger, false, false, TraverseMode.ByPawn) && !building_PlantGrower.IsBurning())
                {
                    foreach (IntVec3 intVec in building_PlantGrower.OccupiedRect())
                    {
                        yield return intVec;
                    }
                    wantedPlantDef = null;
                }
                num = i;
			}
			wantedPlantDef = null;
			List<Zone> zonesList = pawn.Map.zoneManager.AllZones;
			for (int i = 0; i < zonesList.Count; i = num + 1)
			{
                if (zonesList[i] is Zone_GrowingAsh growZone)
                {
                    if (growZone.cells.Count == 0)
                    {
                        Log.ErrorOnce("Grow zone has 0 cells: " + growZone, -563487);
                    }
                    else if (ExtraRequirements(growZone, pawn) && !growZone.ContainsStaticFire && pawn.CanReach(growZone.Cells[0], PathEndMode.OnCell, maxDanger, false, false, TraverseMode.ByPawn))
                    {
                        for (int j = 0; j < growZone.cells.Count; j = num + 1)
                        {
                            yield return growZone.cells[j];
                            num = j;
                        }
                        wantedPlantDef = null;
                    }
                }
                num = i;
			}
			wantedPlantDef = null;
			yield break;
		}

		protected static ThingDef wantedPlantDef;
	}
}

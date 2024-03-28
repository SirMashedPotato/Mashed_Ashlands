using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace Mashed_Ashlands
{
	/// <summary>
	/// Yea this is basically copy pasted from WorkGiver_GrowerSow
	/// I feel dirty
	/// </summary>
	public class WorkGiver_GrowerSowAsh : WorkGiver_GrowerAsh
    {
		public override PathEndMode PathEndMode => PathEndMode.ClosestTouch;

		public static void ResetStaticData()
		{
			CantSowCavePlantBecauseOfLightTrans = "CantSowCavePlantBecauseOfLight".Translate();
			CantSowCavePlantBecauseUnroofedTrans = "CantSowCavePlantBecauseUnroofed".Translate();
		}

		protected override bool ExtraRequirements(IPlantToGrowSettable settable, Pawn pawn)
		{
			if (!settable.CanAcceptSowNow())
			{
				return false;
			}
            IntVec3 c;
            if (settable is Zone_GrowingAsh zone_Growing)
			{
				if (!zone_Growing.allowSow)
				{
					return false;
				}
				c = zone_Growing.Cells[0];
			}
			else
			{
				c = ((Thing)settable).Position;
			}
			wantedPlantDef = CalculateWantedPlantDef(c, pawn.Map);
			return wantedPlantDef != null;
		}

		public override Job JobOnCell(Pawn pawn, IntVec3 c, bool forced = false)
		{
			Map map = pawn.Map;
			if (c.IsForbidden(pawn))
			{
				return null;
			}
			if (!PlantUtility.GrowthSeasonNow(c, map, true))
			{
				return null;
			}
			if (wantedPlantDef == null)
			{
				wantedPlantDef = CalculateWantedPlantDef(c, map);
				if (wantedPlantDef == null)
				{
					return null;
				}
			}
			List<Thing> thingList = c.GetThingList(map);
			Zone_GrowingAsh zone_Growing = c.GetZone(map) as Zone_GrowingAsh;
			bool flag = false;
			for (int i = 0; i < thingList.Count; i++)
			{
				Thing thing = thingList[i];
				if (thing.def == wantedPlantDef)
				{
					return null;
				}
				if ((thing is Blueprint || thing is Frame) && thing.Faction == pawn.Faction)
				{
					flag = true;
				}
			}
			if (flag)
			{
				Thing edifice = c.GetEdifice(map);
				if (edifice == null || edifice.def.fertility < 0f)
				{
					return null;
				}
			}
			if (wantedPlantDef.plant.cavePlant)
			{
				if (!c.Roofed(map))
				{
					JobFailReason.Is(CantSowCavePlantBecauseUnroofedTrans, null);
					return null;
				}
				if (map.glowGrid.GroundGlowAt(c, true) > 0f)
				{
					JobFailReason.Is(CantSowCavePlantBecauseOfLightTrans, null);
					return null;
				}
			}
			if (wantedPlantDef.plant.interferesWithRoof && c.Roofed(pawn.Map))
			{
				return null;
			}
			Plant plant = c.GetPlant(map);
			if (plant != null && plant.def.plant.blockAdjacentSow)
			{
				if (!pawn.CanReserve(plant, 1, -1, null, forced) || plant.IsForbidden(pawn))
				{
					return null;
				}
				if (zone_Growing != null && !zone_Growing.allowCut)
				{
					return null;
				}
				if (!PlantUtility.PawnWillingToCutPlant_Job(plant, pawn))
				{
					return null;
				}
				return JobMaker.MakeJob(RimWorld.JobDefOf.CutPlant, plant);
			}
			else
			{
				Thing thing2 = PlantUtility.AdjacentSowBlocker(wantedPlantDef, c, map);
				if (thing2 != null)
				{
                    if (thing2 is Plant plant2 && pawn.CanReserveAndReach(plant2, PathEndMode.Touch, Danger.Deadly, 1, -1, null, forced) && !plant2.IsForbidden(pawn))
                    {
                        IPlantToGrowSettable plantToGrowSettable = plant2.Position.GetPlantToGrowSettable(plant2.Map);
                        if (plantToGrowSettable == null || plantToGrowSettable.GetPlantDefToGrow() != plant2.def)
                        {
							Zone_GrowingAsh zone_Growing2 = c.GetZone(map) as Zone_GrowingAsh;
							Zone_GrowingAsh zone_Growing3 = plant2.Position.GetZone(map) as Zone_GrowingAsh;
                            if ((zone_Growing2 != null && !zone_Growing2.allowCut) || (zone_Growing3 != null && !zone_Growing3.allowCut))
                            {
                                return null;
                            }
                            if (PlantUtility.TreeMarkedForExtraction(plant2))
                            {
                                return null;
                            }
                            if (!PlantUtility.PawnWillingToCutPlant_Job(plant2, pawn))
                            {
                                return null;
                            }
                            return JobMaker.MakeJob(RimWorld.JobDefOf.CutPlant, plant2);
                        }
                    }
                    return null;
				}
				if (wantedPlantDef.plant.sowMinSkill > 0 && ((pawn.skills != null && pawn.skills.GetSkill(SkillDefOf.Plants).Level < wantedPlantDef.plant.sowMinSkill) || (pawn.IsColonyMech && pawn.RaceProps.mechFixedSkillLevel < wantedPlantDef.plant.sowMinSkill)))
				{
					JobFailReason.Is("UnderAllowedSkill".Translate(wantedPlantDef.plant.sowMinSkill), def.label);
					return null;
				}
				int j = 0;
				while (j < thingList.Count)
				{
					Thing thing3 = thingList[j];
					if (thing3.def.BlocksPlanting(false))
					{
						if (!pawn.CanReserve(thing3, 1, -1, null, forced))
						{
							return null;
						}
						if (thing3.def.category == ThingCategory.Plant)
						{
							if (thing3.IsForbidden(pawn))
							{
								return null;
							}
							if (zone_Growing != null && !zone_Growing.allowCut)
							{
								return null;
							}
							if (!PlantUtility.PawnWillingToCutPlant_Job(thing3, pawn))
							{
								return null;
							}
							if (PlantUtility.TreeMarkedForExtraction(thing3))
							{
								return null;
							}
							return JobMaker.MakeJob(RimWorld.JobDefOf.CutPlant, thing3);
						}
						else
						{
							if (thing3.def.EverHaulable)
							{
								return HaulAIUtility.HaulAsideJobFor(pawn, thing3);
							}
							return null;
						}
					}
					else
					{
						j++;
					}
				}
				if (!wantedPlantDef.CanNowPlantAt(c, map, false) || !PlantUtility.GrowthSeasonNow(c, map, true) || !pawn.CanReserve(c, 1, -1, null, forced))
				{
					return null;
				}
				Job job = JobMaker.MakeJob(RimWorld.JobDefOf.Sow, c);
				job.plantDefToSow = wantedPlantDef;
				return job;
			}
		}

		protected static string CantSowCavePlantBecauseOfLightTrans;
		protected static string CantSowCavePlantBecauseUnroofedTrans;
	}
}

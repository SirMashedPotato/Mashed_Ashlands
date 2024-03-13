using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class Zone_GrowingAsh : Zone, IPlantToGrowSettable
    {
		public override bool IsMultiselectable => true;

		protected override Color NextZoneColor => ZoneUtility.NextGrowingZoneAshColor();

		public bool CanAcceptSowNow() => true;

		IEnumerable<IntVec3> IPlantToGrowSettable.Cells => Cells;

		public ThingDef PlantDefToGrow
		{
			get
			{
				if (plantDefToGrow == null)
				{
					if (PollutionUtility.SettableEntirelyPolluted(this))
					{
						plantDefToGrow = ThingDefOf.Mashed_Ashlands_Plant_ToxYam;
					}
					else
					{
						plantDefToGrow = ThingDefOf.Mashed_Ashlands_Plant_AshYam;
					}
				}
				return plantDefToGrow;
			}
		}

		public Zone_GrowingAsh() 
		{ 
		}

		public Zone_GrowingAsh(ZoneManager zoneManager) : base("Mashed_Ashlands_GrowingZoneAsh".Translate(), zoneManager)
		{
		}

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Defs.Look(ref plantDefToGrow, "plantDefToGrow");
			Scribe_Values.Look(ref allowSow, "allowSow", true, false);
			Scribe_Values.Look(ref allowCut, "allowCut", true, false);
		}

		/// <summary>
		/// Largely copy paste
		/// </summary>
		public void ContentsStatistics(out int totalPlants, out float averagePlantAgeTicks, out int oldestPlantAgeTicks, out float averagePlantGrowth, out float maxPlantGrowth)
		{
			averagePlantAgeTicks = 0f;
			totalPlants = 0;
			oldestPlantAgeTicks = 0;
			averagePlantGrowth = 0f;
			maxPlantGrowth = 0f;
			foreach (IntVec3 c in Cells)
			{
				foreach (Thing thing in c.GetThingList(Map))
				{
					Plant plant;
					if (thing.def == plantDefToGrow && (plant = (thing as Plant)) != null)
					{
						totalPlants++;
						averagePlantAgeTicks += plant.Age;
						oldestPlantAgeTicks = Mathf.Max(oldestPlantAgeTicks, plant.Age);
						averagePlantGrowth += plant.Growth;
						maxPlantGrowth = Mathf.Max(maxPlantGrowth, plant.Growth);
					}
				}
			}
			averagePlantGrowth /= totalPlants;
			averagePlantAgeTicks /= totalPlants;
		}

		/// <summary>
		/// Largely copy paste
		/// </summary>
		public override string GetInspectString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.GetInspectString());
			stringBuilder.AppendLine();
			if (!Cells.NullOrEmpty())
			{
                ContentsStatistics(out int num, out float num2, out int num3, out float f, out float f2);
                if (num > 0)
				{
					string arg = (num2 / 3600000f).ToStringApproxAge();
					string arg2 = (num3 / 3600000f).ToStringApproxAge();
					stringBuilder.AppendLine(string.Format("{0}: {1} {2}", "Contains".Translate().CapitalizeFirst(), num, Find.ActiveLanguageWorker.Pluralize(plantDefToGrow.label, num)));
					stringBuilder.AppendLine(string.Format("{0}: {1} ({2})", "AveragePlantAge".Translate().CapitalizeFirst(), arg, "PercentGrowth".Translate(f.ToStringPercent())));
					stringBuilder.AppendLine(string.Format("{0}: {1} ({2})", "OldestPlantAge".Translate().CapitalizeFirst(), arg2, "PercentGrowth".Translate(f2.ToStringPercent())));
				}
				IntVec3 c = Cells[0];
				if (c.UsesOutdoorTemperature(Map))
				{
					stringBuilder.AppendLine("OutdoorGrowingPeriod".Translate() + ": " + Zone_Growing.GrowingQuadrumsDescription(Map.Tile));
				}
				if (PlantUtility.GrowthSeasonNow(c, Map, true))
				{
					stringBuilder.Append("GrowSeasonHereNow".Translate());
				}
				else
				{
					stringBuilder.Append("CannotGrowBadSeasonTemperature".Translate());
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Largely copy paste
		/// </summary>
		public static string GrowingQuadrumsDescription(int tile)
		{
			List<Twelfth> list = GenTemperature.TwelfthsInAverageTemperatureRange(tile, 6f, 42f);
			if (list.NullOrEmpty())
			{
				return "NoGrowingPeriod".Translate();
			}
			if (list.Count == 12)
			{
				return "GrowYearRound".Translate();
			}
			return "PeriodDays".Translate(list.Count * 5 + "/" + 60) + " (" + QuadrumUtility.QuadrumsRangeLabel(list) + ")";
		}

		public override void AddCell(IntVec3 c)
		{
			base.AddCell(c);
			foreach (Thing t in Map.thingGrid.ThingsListAt(c))
			{
				Designator_PlantsHarvestWood.PossiblyWarnPlayerImportantPlantDesignateCut(t);
			}
		}

		public override IEnumerable<Gizmo> GetGizmos()
		{
			foreach (Gizmo gizmo in base.GetGizmos())
			{
				yield return gizmo;
			}
			yield return PlantToGrowSettableUtility.SetPlantToGrowCommand(this);
			yield return new Command_Toggle
			{
				defaultLabel = "CommandAllowSow".Translate(),
				defaultDesc = "CommandAllowSowDesc".Translate(),
				hotKey = KeyBindingDefOf.Command_ItemForbid,
				icon = TexCommand.ForbidOff,
				isActive = (() => allowSow),
				toggleAction = delegate ()
				{
					allowSow = !allowSow;
				}
			};
			yield return new Command_Toggle
			{
				defaultLabel = "CommandAllowCut".Translate(),
				defaultDesc = "CommandAllowCutDesc".Translate(),
				icon = Designator_PlantsCut.IconTex,
				isActive = (() => allowCut),
				toggleAction = delegate ()
				{
					allowCut = !allowCut;
				}
			};
			yield break;
		}

		public override IEnumerable<Gizmo> GetZoneAddGizmos()
		{
			yield return DesignatorUtility.FindAllowedDesignator<Designator_ZoneAdd_GrowingAsh_Expand>();
		}

        public ThingDef GetPlantDefToGrow()
        {
			return PlantDefToGrow;
		}

        public void SetPlantDefToGrow(ThingDef plantDef)
        {
			plantDefToGrow = plantDef;
		}

        private ThingDef plantDefToGrow;
		public bool allowSow = true;
		public bool allowCut = true;
	}
}

using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class Zone_GrowingAsh : Zone_Growing, IPlantToGrowSettable
    {
		protected override Color NextZoneColor => ZoneUtility.NextGrowingZoneAshColor();

		IEnumerable<IntVec3> IPlantToGrowSettable.Cells => Cells;

		public new ThingDef PlantDefToGrow
		{
			get
			{
				if (ModsConfig.BiotechActive && base.PlantDefToGrow == RimWorld.ThingDefOf.Plant_Toxipotato)
				{
					SetPlantDefToGrow(ThingDefOf.Mashed_Ashlands_Plant_ToxYam);
				}
				else if (base.PlantDefToGrow == RimWorld.ThingDefOf.Plant_Potato)
				{
					SetPlantDefToGrow(ThingDefOf.Mashed_Ashlands_Plant_AshYam);
				}
				return base.PlantDefToGrow;
			}
		}

		public Zone_GrowingAsh() 
		{
        }

		public Zone_GrowingAsh(ZoneManager zoneManager) : base(zoneManager)
		{
            label = zoneManager.NewZoneName("Mashed_Ashlands_GrowingZoneAsh".Translate());
        }

        public override void AddCell(IntVec3 c)
        {
            base.AddCell(c);
            //done here because otherwise SettableEntirelyPolluted returns true due to Cells being empty
            _ = PlantDefToGrow;
        }

        public override IEnumerable<Gizmo> GetZoneAddGizmos()
		{
			yield return DesignatorUtility.FindAllowedDesignator<Designator_ZoneAdd_GrowingAsh_Expand>();
		}
	}
}

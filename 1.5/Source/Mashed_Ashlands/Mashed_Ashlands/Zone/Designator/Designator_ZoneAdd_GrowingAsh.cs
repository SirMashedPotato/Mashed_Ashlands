using UnityEngine;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class Designator_ZoneAdd_GrowingAsh : Designator_ZoneAdd
    {
		protected override string NewZoneLabel => "Mashed_Ashlands_GrowingZoneAsh".Translate();

		public Designator_ZoneAdd_GrowingAsh()
		{
			zoneTypeToPlace = typeof(Zone_GrowingAsh);
			defaultLabel = "Mashed_Ashlands_GrowingZoneAsh".Translate();
			defaultDesc = "Mashed_Ashlands_GrowingZoneAshDesc".Translate();
			icon = ContentFinder<Texture2D>.Get("UI/Designators/Mashed_Ashlands_ZoneCreate_GrowingAsh", true);
			tutorTag = "ZoneAdd_Growing";
			soundSucceeded = SoundDefOf.Designate_ZoneAdd_Growing;
		}

		public override AcceptanceReport CanDesignateCell(IntVec3 c)
		{
			if (!base.CanDesignateCell(c).Accepted)
			{
				return false;
			}

			TerrainDef terrain = c.GetTerrain(Map);
			return terrain != null && !terrain.affordances.NullOrEmpty() && terrain.affordances.Contains(TerrainAffordanceDefOf.Mashed_Ashlands_GrowAsh);
		}

		protected override Zone MakeNewZone()
		{
			PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.GrowingFood, KnowledgeAmount.Total);
			return new Zone_GrowingAsh(Find.CurrentMap.zoneManager);
		}
    }
}

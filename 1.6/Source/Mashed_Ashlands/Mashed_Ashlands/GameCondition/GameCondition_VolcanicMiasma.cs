using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
	/// <summary>
	/// Basically a stripped down GameCondition_ToxicFallout
	/// </summary>
	public class GameCondition_VolcanicMiasma : GameCondition
	{
		public override int TransitionTicks =>  5000;

		public override void Init()
		{
			base.Init();
			LessonAutoActivator.TeachOpportunity(RimWorld.ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
			LessonAutoActivator.TeachOpportunity(RimWorld.ConceptDefOf.AllowedAreas, OpportunityType.Critical);
		}

		public override void GameConditionTick()
		{
			List<Map> affectedMaps = AffectedMaps;
			if (Find.TickManager.TicksGame % 3451 == 0)
			{
				for (int i = 0; i < affectedMaps.Count; i++)
				{
					DoPawnsToxicDamage(affectedMaps[i]);
				}
			}
			for (int j = 0; j < overlays.Count; j++)
			{
				for (int k = 0; k < affectedMaps.Count; k++)
				{
					overlays[j].TickOverlay(affectedMaps[k], MaxSkyLerpFactor);
				}
			}
		}

		private void DoPawnsToxicDamage(Map map)
		{
            IReadOnlyList<Pawn> allPawnsSpawned = map.mapPawns.AllPawnsSpawned;
			for (int i = 0; i < allPawnsSpawned.Count; i++)
			{
                if (!allPawnsSpawned[i].kindDef.immuneToGameConditionEffects)
                {
                    ToxicUtility.DoAirbornePawnToxicDamage(allPawnsSpawned[i]);
                }
            }
		}

		public override void GameConditionDraw(Map map)
		{
			for (int i = 0; i < overlays.Count; i++)
			{
				overlays[i].DrawOverlay(map);
			}
		}

		public override float SkyTargetLerpFactor(Map map)
		{
			return GameConditionUtility.LerpInOutValue(this, TransitionTicks, MaxSkyLerpFactor);
		}

		public override SkyTarget? SkyTarget(Map map)
		{
			return new SkyTarget?(new SkyTarget(1, VolcanicMiasmaColors, 1f, 1f));
		}

		public override float AnimalDensityFactor(Map map)
		{
			return 0f;
		}

		public override bool AllowEnjoyableOutsideNow(Map map)
		{
			return false;
		}

		public override List<SkyOverlay> SkyOverlays(Map map)
		{
			return overlays;
		}

		private const float MaxSkyLerpFactor = 0.5f;
		private SkyColorSet VolcanicMiasmaColors = new SkyColorSet(new ColorInt(224, 204, 204).ToColor, new ColorInt(234, 234, 234).ToColor, new Color(1f, 1f, 1f), 1);
		private readonly List<SkyOverlay> overlays = new List<SkyOverlay>
		{
			new WeatherOverlay_VolcanicMiasma()
		};

	}
}

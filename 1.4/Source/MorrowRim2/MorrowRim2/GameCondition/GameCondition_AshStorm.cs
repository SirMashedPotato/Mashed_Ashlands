using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace MorrowRim2
{
    public class GameCondition_AshStorm : GameCondition
    {
		public override int TransitionTicks
		{
			get
			{
				return 5000;
			}
		}

		public override void Init()
		{
			LessonAutoActivator.TeachOpportunity(RimWorld.ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
			LessonAutoActivator.TeachOpportunity(RimWorld.ConceptDefOf.AllowedAreas, OpportunityType.Critical);
			//protecting against ash storms concept TODO
		}

		public override void GameConditionTick()
		{
			List<Map> affectedMaps = AffectedMaps;
			if (Find.TickManager.TicksGame % CheckInterval == 0)
			{
				for (int i = 0; i < affectedMaps.Count; i++)
				{
					DoPawnsAshDamage(affectedMaps[i]);
				}
			}
			for (int j = 0; j < overlays.Count; j++)
			{
				for (int k = 0; k < affectedMaps.Count; k++)
				{
					overlays[j].TickOverlay(affectedMaps[k]);
				}
			}
		}

		private void DoPawnsAshDamage(Map map)
		{
			List<Pawn> allPawnsSpawned = map.mapPawns.AllPawnsSpawned;
			for (int i = 0; i < allPawnsSpawned.Count; i++)
			{
				DoPawnAshDamage(allPawnsSpawned[i], true, 1f);
			}
		}

		public static void DoPawnAshDamage(Pawn p, bool protectedByRoof = true, float extraFactor = 1f)
		{
			if (p.Spawned && protectedByRoof && p.Position.Roofed(p.Map))
			{
				return;
			}
			float ashResistanceValue = p.GetStatValue(StatDefOf.MorrowRim_AshResistance, true, -1);

			if (!p.health.capacities.CapableOf(PawnCapacityDefOf.Breathing) ||
				ashResistanceValue >= 1f)
            {
				return;
			}
			float num = 0.0230066683f;
			num *= Mathf.Max(1f - ashResistanceValue);
			num /= p.BodySize / p.health.capacities.GetLevel(PawnCapacityDefOf.Breathing);
			num *= extraFactor;
			if (num != 0f)
			{
				float num2 = Mathf.Lerp(0.85f, 1.15f, Rand.ValueSeeded(p.thingIDNumber ^ 74374237));
				num *= num2;
				HealthUtility.AdjustSeverity(p, HediffDefOf.MorrowRim_AshBuildup, num);
			}
		}

		public override void DoCellSteadyEffects(IntVec3 c, Map map)
		{
			if (!c.Roofed(map))
			{
				List<Thing> thingList = c.GetThingList(map);
				for (int i = 0; i < thingList.Count; i++)
				{
					Thing thing = thingList[i];
					if (thing is Plant)
					{
						float ashResistanceValue = thing.GetStatValue(StatDefOf.MorrowRim_AshResistance, true, -1);
						if (ashResistanceValue < 1f && Rand.Value < 0.065f)
						{
							DamageInfo info = new DamageInfo
							{
								Def = DamageDefOf.Deterioration
							};
							info.SetAmount(Rand.Gaussian(10 * (1 - ashResistanceValue)));
							thing.TakeDamage(info);
						}
					}
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
			return new SkyTarget?(new SkyTarget(SkyGlow, AshStormColours, 1f, 1f));
		}

		public override float AnimalDensityFactor(Map map)
		{
			return 0.5f;
		}

		public override float PlantDensityFactor(Map map)
		{
			return 0.5f;
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
		private const float SkyGlow = 0.5f;
		private SkyColorSet AshStormColours = new SkyColorSet(new ColorInt(204, 204, 204).ToColor, new ColorInt(234, 234, 234).ToColor, new Color(1f, 1f, 1f), SkyGlow);
		private readonly List<SkyOverlay> overlays = new List<SkyOverlay>
		{
			new WeatherOverlay_AshStormPrimary(),
			new WeatherOverlay_AshStormSecondary()
		};
		public const int CheckInterval = 3451;
	}
}

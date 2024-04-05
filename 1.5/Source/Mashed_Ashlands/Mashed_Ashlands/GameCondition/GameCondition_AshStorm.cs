using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
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
			base.Init();
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
			IReadOnlyList<Pawn> allPawnsSpawned = map.mapPawns.AllPawnsSpawned;
			for (int i = 0; i < allPawnsSpawned.Count; i++)
			{
				AshResistanceProperties props = AshResistanceProperties.Get(allPawnsSpawned[i].def);
				if (props != null && props.treatAsMechanical && Mashed_Ashlands_ModSettings.AshStormCauseCloggedServo)
				{
					DoMechAshDamage(allPawnsSpawned[i], true);
				}
				else
				{
					DoPawnAshDamage(allPawnsSpawned[i], true);

					if ((props == null || !props.immuneToAshBlinding) && Mashed_Ashlands_ModSettings.AshStormCauseBlinded)
					{
						TryBlindPawn(allPawnsSpawned[i], true);
					}
				}
			}
		}

		/// <summary>
		/// Specifically for fleshy pawns
		/// Causes ash buildup
		/// </summary>
		public static void DoPawnAshDamage(Pawn p, bool protectedByRoof = true)
		{
            if (!Mashed_Ashlands_ModSettings.AshStormCauseBuildup)
            {
				return;
            }
			if (p.Spawned && protectedByRoof && p.Position.Roofed(p.Map))
			{
				return;
			}
			if (PawnImmuneToAsh(p, out float ashResistanceValue))
            {
				return;
			}
			float num = 0.0230066683f;
			num *= Mathf.Max(1f - ashResistanceValue);
			num /= p.BodySize / p.health.capacities.GetLevel(PawnCapacityDefOf.Breathing);
			num *= Mashed_Ashlands_ModSettings.AshStormBuildupMult;
			if (num != 0f)
			{
				float num2 = Mathf.Lerp(0.85f, 1.15f, Rand.ValueSeeded(p.thingIDNumber ^ 74374237));
				num *= num2;
				HealthUtility.AdjustSeverity(p, HediffDefOf.Mashed_Ashlands_AshBuildup, num);
			}
		}

		/// <summary>
		/// Meant for use as a hook for potential Harmony patches
		/// </summary>
		public static bool PawnImmuneToAsh(Pawn p, out float ashResistanceValue)
		{
			ashResistanceValue = p.GetStatValue(StatDefOf.Mashed_Ashlands_AshResistance, true, -1);
			return !p.health.capacities.CapableOf(PawnCapacityDefOf.Breathing) || ashResistanceValue >= 1f;
		}

		/// <summary>
		/// Specifically for fleshy pawns
		/// Causes ash in eyes
		/// </summary>
		public void TryBlindPawn(Pawn p, bool protectedByRoof = true)
		{
			if (p.Spawned && protectedByRoof && p.Position.Roofed(p.Map))
			{
				return;
			}
			if (Rand.Chance(Mashed_Ashlands_ModSettings.AshStormBlindedChance))
			{
				if (PawnImmuneToBlinding(p, out BodyPartRecord targetPart))
				{
					return;
				}
				p.health.AddHediff(HediffDefOf.Mashed_Ashlands_AshInEyes, targetPart);
			}
		}

		/// <summary>
		/// Meant for use as a hook for potential Harmony patches
		/// </summary>
		public bool PawnImmuneToBlinding(Pawn p, out BodyPartRecord targetPart)
		{
			targetPart = p.health.hediffSet.GetNotMissingParts(BodyPartHeight.Undefined, BodyPartDepth.Undefined, BodyPartTagDefOf.SightSource, null).RandomElement();
			return !p.health.capacities.CapableOf(PawnCapacityDefOf.Sight) && targetPart != null && (p.apparel == null || p.apparel.BodyPartGroupIsCovered(BodyPartGroupDefOf.Eyes));
		}

		/// <summary>
		/// Specifically for mech pawns
		/// Clogs servos
		/// </summary>
		public void DoMechAshDamage(Pawn p, bool protectedByRoof = true)
		{
			if (p.Spawned && protectedByRoof && p.Position.Roofed(p.Map))
			{
				return;
			}
			if (Rand.Chance(Mashed_Ashlands_ModSettings.AshStormCloggedServoChance))
			{
				BodyPartRecord part = p.RaceProps.body.AllParts.RandomElement();
				p.health.AddHediff(HediffDefOf.Mashed_Ashlands_AshCloggedServo, part);
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
					if (thing is Plant && Mashed_Ashlands_ModSettings.AshStormDamagePlants)
					{
						if (!PlantImmuneToAsh(thing as Plant, out float ashResistanceValue) && Rand.Value < 0.065f)
						{
							DamageInfo info = new DamageInfo
							{
								Def = DamageDefOf.Deterioration
							};
							info.SetAmount(Rand.Gaussian(Mashed_Ashlands_ModSettings.AshStormAvgPlantDamage * (1 - ashResistanceValue)));
							thing.TakeDamage(info);
						}
					}
					if (thing is Building)
					{
						AshResistanceProperties props = AshResistanceProperties.Get(thing.def);
                        if (Mashed_Ashlands_ModSettings.AshStormDamageBuildings)
                        {
							if (props != null && props.buildingTakesDamage && Rand.Chance(props.chanceDamaged))
							{
								DamageInfo info = new DamageInfo
								{
									Def = DamageDefOf.Deterioration
								};
								info.SetAmount(Rand.Gaussian(props.avgDamageTaken));
								thing.TakeDamage(info);
							}
						}
						if (Mashed_Ashlands_ModSettings.AshStormBreakdownBuildings && Rand.Chance(Mashed_Ashlands_ModSettings.AshStormBreakdownBuildingsChance))
						{
							if (props == null || !props.buildingImmuneToBreakDowns)
							{
								CompBreakdownable compBreakdownable = thing.TryGetComp<CompBreakdownable>();
                                if (compBreakdownable != null && !compBreakdownable.BrokenDown)
                                {
									compBreakdownable.DoBreakdown();
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Meant for use as a hook for potential Harmony patches
		/// </summary>
		public bool PlantImmuneToAsh(Plant p, out float ashResistanceValue)
		{
			ashResistanceValue = p.GetStatValue(StatDefOf.Mashed_Ashlands_AshResistance, true, -1);
			return ashResistanceValue >= 1f;
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

		public override WeatherDef ForcedWeather()
		{
			return def.weatherDef;
		}

        public override void End()
        {
            if (ForcedWeather() != null)
            {
				foreach (Map map in AffectedMaps)
				{
					map.weatherManager.TransitionTo(RimWorld.WeatherDefOf.Clear);
				}
			}
            base.End();
        }

		private const float MaxSkyLerpFactor = 0.5f;
		private const float SkyGlow = 0.55f;
		private SkyColorSet AshStormColours = new SkyColorSet(new ColorInt(204, 204, 204).ToColor, new ColorInt(234, 234, 234).ToColor, new Color(1f, 1f, 1f), SkyGlow);
		private readonly List<SkyOverlay> overlays = new List<SkyOverlay>
		{
			new WeatherOverlay_AshStorm(0.4f),
			new WeatherOverlay_AshStorm(0.8f, 0.045f, 0.045f, 0.7f),
            new WeatherOverlay_AshStorm(1.2f, 0.04f, 0.04f, 1.3f)
        };
		public const int CheckInterval = 3451;
	}
}

using Verse;
using RimWorld;
using UnityEngine;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class IncidentWorker_CliffRacerSwarm : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Map map = (Map)parms.target;
			return Mashed_Ashlands_ModSettings.CliffRacerEnableSwarm 
				&& (!Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction || !CliffRacerTrackerUtility.ExtinctionReached())
				&& !map.gameConditionManager.ConditionIsActive(RimWorld.GameConditionDefOf.ToxicFallout)
                && (!ModsConfig.BiotechActive || !map.gameConditionManager.ConditionIsActive(RimWorld.GameConditionDefOf.NoxiousHaze))
				&& map.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(ThingDefOf.Mashed_Ashlands_CliffRacer) && TryFindEntryCell(map, out _);
        }

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			if (!TryFindEntryCell(map, out IntVec3 intVec))
			{
				return false;
			}

			float freeColonistsCount = map.mapPawns.FreeColonistsCount + (map.mapPawns.SpawnedColonyMechs.Count / 3);
			float randomInRange = CountPerColonistRange.RandomInRange;
			int num = Mathf.Clamp(GenMath.RoundRandom(freeColonistsCount * randomInRange), Mashed_Ashlands_ModSettings.CliffRacerSwarmMinSize, Mashed_Ashlands_ModSettings.CliffRacerSwarmMaxSize);
			List<Pawn> cliffRacers = new List<Pawn> { };

			for (int i = 0; i < num; i++)
			{
				IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
				Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDefOf.Mashed_Ashlands_CliffRacer, null);
				GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);
				cliffRacers.Add(pawn);
			}

			SendStandardLetter(def.letterLabel, def.letterText.Formatted(cliffRacers.Count), def.letterDef, parms, cliffRacers);
			return true;
		}

		private bool TryFindEntryCell(Map map, out IntVec3 cell)
		{
			return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f, false, null);
		}

		private static readonly FloatRange CountPerColonistRange = new FloatRange(1f, 3f);
	}
}

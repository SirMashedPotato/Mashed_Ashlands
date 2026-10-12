using Verse;
using RimWorld;
using UnityEngine;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class IncidentWorker_CliffRacerSwarm : IncidentWorker_AshlandsSpecific
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
			return base.CanFireNowSub(parms) && CanWanderIn(parms, ThingDefOf.Mashed_Ashlands_CliffRacer) && Mashed_Ashlands_ModSettings.CliffRacerEnableSwarm
				&& (!Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction || !CliffRacerTrackerUtility.ExtinctionReached());
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

		private static readonly FloatRange CountPerColonistRange = new FloatRange(1f, 3f);
	}
}

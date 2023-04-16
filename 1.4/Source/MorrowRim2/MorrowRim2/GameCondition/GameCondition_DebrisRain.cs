using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace MorrowRim2
{
    public class GameCondition_DebrisRain : GameCondition
    {
        public override void Init()
        {
            base.Init();
			checkInterval = checkIntervalRange.RandomInRange;
		}

        public override void GameConditionTick()
		{
			List<Map> affectedMaps = AffectedMaps;
			if (Find.TickManager.TicksGame % checkInterval == 0)
			{
				for (int i = 0; i < affectedMaps.Count; i++)
				{
					TryTriggerMeteor(affectedMaps[i]);
				}
			}
		}

		public void TryTriggerMeteor(Map map)
		{
			if (!TryFindCell(out IntVec3 intVec, map))
			{
				return;
			}
			SkyfallerMaker.SpawnSkyfaller(ThingDefOf.MorrowRim_VolcanicDebrisIncoming, ThingMaker.MakeThing(ThingDefOf.MorrowRim_VolcanicDebris), intVec, map);
			checkInterval = checkIntervalRange.RandomInRange;
		}

		private bool TryFindCell(out IntVec3 cell, Map map)
		{
			int maxMineables = ThingSetMaker_Meteorite.MineablesCountRange.max;
			return CellFinderLoose.TryFindSkyfallerCell(ThingDefOf.MorrowRim_VolcanicDebrisIncoming, map, out cell, 10, default, -1, true, false, false, false, true, true);
		}

		public int checkInterval;
		public IntRange checkIntervalRange = new IntRange(341, 851);
    }
}

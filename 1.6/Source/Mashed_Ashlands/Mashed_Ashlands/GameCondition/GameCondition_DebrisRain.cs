using System.Collections.Generic;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
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
			SkyfallerMaker.SpawnSkyfaller(ThingDefOf.Mashed_Ashlands_VolcanicDebrisIncoming, ThingMaker.MakeThing(ThingDefOf.Mashed_Ashlands_VolcanicDebris), intVec, map);
			checkInterval = checkIntervalRange.RandomInRange;
		}

		private bool TryFindCell(out IntVec3 cell, Map map)
		{
			int maxMineables = ThingSetMaker_Meteorite.MineablesCountRange.max;
			return CellFinderLoose.TryFindSkyfallerCell(ThingDefOf.Mashed_Ashlands_VolcanicDebrisIncoming, map, RimWorld.TerrainAffordanceDefOf.Walkable, out cell, alwaysAvoidColonists: true);
		}

		public int checkInterval;
		public IntRange checkIntervalRange = new IntRange(341, 851);
    }
}

using Verse;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;

namespace MorrowRim2
{
    /// TODO
    /// Tidy up
    /// Potentially rework, using it for randomly generated non-permanent conditions
    public class WorldObjectComp_PermanentCondition : WorldObjectComp
    {
		public WorldObjectCompProperties_PermanentCondition Props
		{
			get
			{
				return (WorldObjectCompProperties_PermanentCondition)props;
			}
		}

        public Volcano ParentVolcano
        {
            get
            {
                return parent as Volcano;
            }
        }

        public IEnumerable<GameCondition> CausedConditions
        {
            get
            {
                return causedConditions.Values;
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            foreach (Map map in Find.Maps)
            {
                if (InAoE(map.Tile))
                {
                    EnforceConditionOn(map);
                }
            }
            tmpDeadConditionMaps.Clear();
            foreach (KeyValuePair<Map, GameCondition> keyValuePair in causedConditions)
            {
                if (!InAoE(keyValuePair.Key.Tile) || keyValuePair.Value.Expired || !keyValuePair.Key.GameConditionManager.ConditionIsActive(keyValuePair.Value.def))
                {
                    keyValuePair.Value.End();
                    tmpDeadConditionMaps.Add(keyValuePair.Key);
                }
            }
            foreach (Map key in tmpDeadConditionMaps)
            {
                causedConditions.Remove(key);
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            if (Scribe.mode == LoadSaveMode.Saving)
            {
                causedConditions.RemoveAll((KeyValuePair<Map, GameCondition> x) => !Find.Maps.Contains(x.Key));
            }
            Scribe_Collections.Look(ref causedConditions, "causedConditions", LookMode.Reference, LookMode.Reference);
            if (Scribe.mode == LoadSaveMode.ResolvingCrossRefs)
            {
                causedConditions.RemoveAll((KeyValuePair<Map, GameCondition> x) => x.Value == null);
            }
        }

        public bool InAoE(int tile)
        {
            int worldRange = ParentVolcano.EffectRadiusFor(ParentVolcano.Category);
            return Find.WorldGrid.TraversalDistanceBetween(ParentVolcano.Tile, tile, true, worldRange + 1) <= worldRange;
        }

        protected GameCondition GetConditionInstance(Map map)
        {
            if (!causedConditions.TryGetValue(map, out GameCondition activeCondition) && Props.preventConditionStacking)
            {
                activeCondition = map.GameConditionManager.GetActiveCondition(Props.conditionDef);
                if (activeCondition != null)
                {
                    causedConditions.Add(map, activeCondition);
                    SetupCondition(activeCondition, map);
                }
            }
            return activeCondition;
        }

        private GameCondition EnforceConditionOn(Map map)
        {
            GameCondition gameCondition = GetConditionInstance(map);
            if (gameCondition == null)
            {
                gameCondition = CreateConditionOn(map);
            }
            else
            {
                gameCondition.TicksLeft = gameCondition.TransitionTicks;
            }
            return gameCondition;
        }

        protected virtual GameCondition CreateConditionOn(Map map)
        {
            GameCondition gameCondition = GameConditionMaker.MakeCondition(Props.conditionDef, -1);
            gameCondition.Duration = gameCondition.TransitionTicks;
            map.gameConditionManager.RegisterCondition(gameCondition);
            causedConditions.Add(map, gameCondition);
            SetupCondition(gameCondition, map);
            return gameCondition;
        }

        protected virtual void SetupCondition(GameCondition condition, Map map)
        {
            condition.suppressEndMessage = true;
        }

        protected void ReSetupAllConditions()
        {
            foreach (KeyValuePair<Map, GameCondition> keyValuePair in causedConditions)
            {
                SetupCondition(keyValuePair.Value, keyValuePair.Key);
            }
        }

        public override string CompInspectStringExtra()
        {
            return "MorrowRim_TheAshlands_VolcanoPermanentCondition".Translate(Props.conditionDef.label);
        }

        public override string GetDescriptionPart()
        {
            return Props.conditionDef.label.CapitalizeFirst() + "\n" + Props.conditionDef.description;
        }

        public override void PostDestroy()
        {
            foreach (KeyValuePair<Map, GameCondition> keyValuePair in causedConditions)
            {
                keyValuePair.Value.End();
            }
            causedConditions.Clear();
            base.PostDestroy();
        }

        private Dictionary<Map, GameCondition> causedConditions = new Dictionary<Map, GameCondition>();
        private static List<Map> tmpDeadConditionMaps = new List<Map>();
    }
}

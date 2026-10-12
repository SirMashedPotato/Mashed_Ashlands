using Verse;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;

namespace Mashed_Ashlands
{
    public abstract class WorldObjectComp_VolcanoConditionCauser : WorldObjectComp
    {
        public Volcano ParentVolcano => parent as Volcano;

        public WorldGrid Grid
        {
            get
            {
                if (worldGrid == null)
                {
                    worldGrid = Find.WorldGrid;
                }
                return worldGrid;
            }
        }

        private WorldGrid worldGrid = null;

        public GameCondition GetConditionInstance(ref Dictionary<Map, GameCondition> causedConditions, Map map)
        {
            causedConditions.TryGetValue(map, out GameCondition activeCondition);
            return activeCondition ?? null;
        }

        public GameCondition EnforceConditionOn(ref Dictionary<Map, GameCondition> causedConditions, Map map, GameConditionDef conditionDef)
        {
            GameCondition gameCondition = GetConditionInstance(ref causedConditions, map);
            if (gameCondition == null)
            {
                if (map.GameConditionManager.ActiveConditions.Any(x => x.def == conditionDef))
                {
                    return null;
                }
                else
                {
                    gameCondition = CreateConditionOn(ref causedConditions, map, conditionDef);
                }
            }
            else
            {
                gameCondition.TicksLeft = gameCondition.TransitionTicks;
            }
            return gameCondition;
        }

        public virtual GameCondition CreateConditionOn(ref Dictionary<Map, GameCondition> causedConditions, Map map, GameConditionDef conditionDef)
        {
            GameCondition gameCondition = GameConditionMaker.MakeCondition(conditionDef, -1);
            gameCondition.Duration = gameCondition.TransitionTicks;
            map.gameConditionManager.RegisterCondition(gameCondition);
            causedConditions.Add(map, gameCondition);
            SetupCondition(gameCondition, map);
            return gameCondition;
        }

        public virtual void SetupCondition(GameCondition condition, Map map)
        {
            condition.suppressEndMessage = true;
        }

        public void ReSetupAllConditions(ref Dictionary<Map, GameCondition> causedConditions)
        {
            foreach (KeyValuePair<Map, GameCondition> keyValuePair in causedConditions)
            {
                SetupCondition(keyValuePair.Value, keyValuePair.Key);
            }
        }

        public bool AnyPlayerInRadius()
        {
            return AnyMapInRadius() || AnyCaravanInRadius();
        }

        public bool AnyMapInRadius()
        {
            foreach (Map map in Find.Maps.Where(x => !x.IsPocketMap))
            {
                if (ParentVolcano.InAoE(map.Tile, ParentVolcano.Category))
                {
                    return true;
                }
            }
            return false;
        }

        public bool AnyCaravanInRadius()
        {
            foreach (Caravan caravan in Find.World.worldObjects.Caravans)
            {
                if (ParentVolcano.InAoE(caravan.Tile, ParentVolcano.Category))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

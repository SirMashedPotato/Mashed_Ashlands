using Verse;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;

namespace MorrowRim2
{
    public abstract class WorldObjectComp_VolcanoConditionCauser : WorldObjectComp
    {

        public bool InAoE(int tile, int category, Volcano parentVolcano)
        {
            int worldRange = parentVolcano.EffectRadiusFor(category);
            return Find.WorldGrid.TraversalDistanceBetween(parentVolcano.Tile, tile, true, worldRange + 1) <= worldRange;
        }

        public GameCondition GetConditionInstance(ref Dictionary<Map, GameCondition> causedConditions, Map map, GameConditionDef conditionDef, bool preventConditionStacking)
        {
            if (!causedConditions.TryGetValue(map, out GameCondition activeCondition) && preventConditionStacking)
            {
                activeCondition = map.GameConditionManager.GetActiveCondition(conditionDef);
                if (activeCondition != null)
                {
                    causedConditions.Add(map, activeCondition);
                    SetupCondition(activeCondition, map);
                }
            }
            return activeCondition;
        }

        public GameCondition EnforceConditionOn(ref Dictionary<Map, GameCondition> causedConditions, Map map, GameConditionDef conditionDef, bool preventConditionStacking)
        {
            GameCondition gameCondition = GetConditionInstance(ref causedConditions, map, conditionDef, preventConditionStacking);
            if (gameCondition == null)
            {
                gameCondition = CreateConditionOn(ref causedConditions, map, conditionDef);
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
    }
}

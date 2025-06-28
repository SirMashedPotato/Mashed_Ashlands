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

        /// <summary>
        /// If performance is terrible switch to the below
        /// return Grid.ApproxDistanceInTiles(parentVolcano.Tile, tile) <= worldRange;
        /// slight issue with that though, tiles outside of the visible radius may be effected if they are along a line instead of a corner
        /// </summary>
        public bool InAoE(PlanetTile tile, int category, Volcano parentVolcano)
        {
            if (tile.Layer != parentVolcano.Tile.Layer)
            {
                return false;
            }
            int worldRange = parentVolcano.EffectRadiusFor(category);
            return Grid.TraversalDistanceBetween(parentVolcano.Tile, tile, true, worldRange + 1) <= worldRange;
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

        public bool AnyPlayerInRadius()
        {
            return AnyMapInRadius() || AnyCaravanInRadius();
        }

        public bool AnyMapInRadius()
        {
            foreach (Map map in Find.Maps.Where(x => !x.IsPocketMap))
            {
                if (InAoE(map.Tile, ParentVolcano.Category, ParentVolcano))
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
                if (InAoE(caravan.Tile, ParentVolcano.Category, ParentVolcano))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

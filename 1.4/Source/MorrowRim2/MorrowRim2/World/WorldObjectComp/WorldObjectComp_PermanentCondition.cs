using Verse;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;

namespace MorrowRim2
{
    public class WorldObjectComp_PermanentCondition : WorldObjectComp_ConditionCauser
    {
		public WorldObjectCompProperties_PermanentCondition Props
		{
			get
			{
				return (WorldObjectCompProperties_PermanentCondition)props;
			}
		}

        public Volcano ParentVolcano => parent as Volcano;

        public IEnumerable<GameCondition> CausedConditions => causedConditions.Values;

        public override void CompTick()
        {
            base.CompTick();
            foreach (Map map in Find.Maps)
            {
                if (InAoE(map.Tile, ParentVolcano.Category, ParentVolcano))
                {
                    EnforceConditionOn(ref causedConditions, map, Props.conditionDef, Props.preventConditionStacking);
                }
            }
            tmpDeadConditionMaps.Clear();
            foreach (KeyValuePair<Map, GameCondition> keyValuePair in causedConditions)
            {
                if (!InAoE(keyValuePair.Key.Tile, ParentVolcano.Category, ParentVolcano) || keyValuePair.Value.Expired || !keyValuePair.Key.GameConditionManager.ConditionIsActive(keyValuePair.Value.def))
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

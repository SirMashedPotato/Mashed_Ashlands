using Verse;
using RimWorld;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class WorldObjectComp_PermanentCondition : WorldObjectComp_VolcanoConditionCauser
    {
		public WorldObjectCompProperties_PermanentCondition Props
		{
			get
			{
				return (WorldObjectCompProperties_PermanentCondition)props;
			}
		}

        public IEnumerable<GameCondition> CausedConditions => causedConditions.Values;

        public override void CompTick()
        {
            base.CompTick();
            ///uses IsHashIntervalTick to avoid tanking performance from checking InAoE
            if (parent.IsHashIntervalTick(60))
            {
                if (Mashed_Ashlands_ModSettings.VolcanoEnablePermanentConditions)
                {
                    foreach (Map map in Find.Maps)
                    {
                        if (InAoE(map.Tile, ParentVolcano.Category, ParentVolcano))
                        {
                            EnforceConditionOn(ref causedConditions, map, Props.conditionDef, Props.preventConditionStacking);
                        }
                    }
                }
                ///for cleaning out conditions
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
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            if (Scribe.mode == LoadSaveMode.Saving)
            {
                causedConditions.RemoveAll((KeyValuePair<Map, GameCondition> x) => !Find.Maps.Contains(x.Key));
            }
            Scribe_Collections.Look(ref causedConditions, "permanentCausedConditions", LookMode.Reference, LookMode.Reference);
            if (Scribe.mode == LoadSaveMode.ResolvingCrossRefs)
            {
                causedConditions.RemoveAll((KeyValuePair<Map, GameCondition> x) => x.Value == null);
            }
        }

        public override string CompInspectStringExtra()
        {
            if (Mashed_Ashlands_ModSettings.VolcanoEnablePermanentConditions)
            {
                return "Mashed_Ashlands_VolcanoPermanentCondition".Translate(Props.conditionDef.label);
            }
            return base.CompInspectStringExtra();
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

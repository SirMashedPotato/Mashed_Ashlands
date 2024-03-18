using Verse;
using RimWorld;
using System.Collections.Generic;
using RimWorld.Planet;
using System.Linq;

namespace Mashed_Ashlands
{
    public class WorldObjectComp_RandomConditionCauser : WorldObjectComp_VolcanoConditionCauser
    {
		public WorldObjectCompProperties_RandomConditionCauser Props
		{
			get
			{
				return (WorldObjectCompProperties_RandomConditionCauser)props;
			}
		}

        public IEnumerable<GameCondition> CausedConditions => causedConditions.Values;
        public bool CanCauseCondition => graceTicksLeft == 0;

        /// <summary>
        /// 
        /// </summary>
        public void TriggerCondition()
        {
            PotentialConditions condition = Props.potentialConditions.Where(x => x.minVolcanoCategory <= ParentVolcano.Category).RandomElementByWeight(y => y.weight);
            if (condition != null)
            {
                EndConditions();
                SetCondition(condition, ParentVolcano);

                bool categoryChangeFlag = false;
                int originalCategory = ParentVolcano.Category;

                if (condition.countAsIncident)
                {
                    ParentVolcano.IncidentTriggered();

                    if (Mashed_Ashlands_ModSettings.VolcanoEnableCategoryChange && ++incidentsCount >= Mashed_Ashlands_ModSettings.IncidentsForCategoryChange)
                    {
                        incidentsCount = 0;
                        WorldObjectComp_VolcanoDetails compDetails = parent.GetComponent<WorldObjectComp_VolcanoDetails>();
                        categoryChangeFlag = compDetails.TryChangeCategory();
                    }
                }

                bool radiusFlag = !Mashed_Ashlands_ModSettings.VolcanoOnlyLetterIfInRadius || AnyPlayerInRadius();

                if (condition.sendLetter && radiusFlag)
                {
                    Find.LetterStack.ReceiveLetter(
                    "Mashed_Ashlands_VolcanoConditionLetter_Label".Translate(ParentVolcano.Name, category, currentConditionDef.label).CapitalizeFirst(),
                    "Mashed_Ashlands_VolcanoConditionLetter_Description".Translate(ParentVolcano.Name, category, currentConditionDef.label, currentConditionDef.description),
                    currentConditionDef.letterDef, ParentVolcano, null, null);
                }

                if (categoryChangeFlag && radiusFlag)
                {
                    Find.LetterStack.ReceiveLetter("Mashed_Ashlands_CategoryChange_Label".Translate(ParentVolcano.Name).CapitalizeFirst(),
                        "Mashed_Ashlands_CategoryChange_Description".Translate(ParentVolcano.Name, originalCategory, ParentVolcano.Category), LetterDefOf.Mashed_Ashlands_VolcanoNegativeEvent, ParentVolcano, null, null);
                }

                conditionTicksLeft = (int)(durationDays * 60000f);
                graceTicksLeft = (int)(graceDaysAfter * 60000f);
                endMessage = condition.sendEndMessage;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetCondition(PotentialConditions condition, Volcano parentVolcano)
        {
            if (condition.conditionDef != null)
            {
                currentConditionDef = condition.conditionDef;
            }
            else
            {
                currentConditionDef = null;
            }
            durationDays = condition.GetTrueConditionDuration.RandomInRange;
            graceDaysAfter = condition.graceDaysAfter.RandomInRange;
            category = condition.forcedCategory > 0 ? condition.forcedCategory : category = Rand.RangeInclusive(1, parentVolcano.Category);
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndConditions()
        {
            if (endMessage && (!Mashed_Ashlands_ModSettings.VolcanoOnlyLetterIfInRadius || AnyPlayerInRadius()))
            {
                Messages.Message(currentConditionDef.endMessage, ParentVolcano, MessageTypeDefOf.NeutralEvent, false);
            }
            foreach (KeyValuePair<Map, GameCondition> keyValuePair in causedConditions)
            {
                keyValuePair.Value.End();
            }
            causedConditions.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CompTick()
        {
            base.CompTick();
            ///uses IsHashIntervalTick to avoid tanking performance from checking InAoE
            if (parent.IsHashIntervalTick(tickInterval))
            {
                bool caravanFlag = parent.IsHashIntervalTick(3600);
                if (Mashed_Ashlands_ModSettings.VolcanoEnableRandomConditions)
                {
                    if (conditionTicksLeft > 0)
                    {
                        if (currentConditionDef != null)
                        {
                            foreach (Map map in Find.Maps)
                            {
                                if (InAoE(map.Tile, category, ParentVolcano))
                                {
                                    EnforceConditionOn(ref causedConditions, map, currentConditionDef, Props.preventConditionStacking);
                                }
                            }
                            ///Causes ash buildup to pawns in caravans during an ash storm
                            if (caravanFlag)
                            {
                                if (Mashed_Ashlands_ModSettings.AshStormAffectsCaravan && currentConditionDef.conditionClass == typeof(GameCondition_AshStorm))
                                {
                                    foreach (Caravan caravan in Find.World.worldObjects.Caravans)
                                    {
                                        if (InAoE(caravan.Tile, category, ParentVolcano) && caravan.pather.MovingNow)
                                        {
                                            foreach (Pawn p in caravan.PawnsListForReading)
                                            {
                                                GameCondition_AshStorm.DoPawnAshDamage(p, false);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        conditionTicksLeft -= tickInterval;
                    }
                    else
                    {
                        if (graceTicksLeft > 0)
                        {
                            graceTicksLeft -= tickInterval;
                        }
                        else
                        {
                            TriggerCondition();
                        }
                    }
                }
                ///for cleaning out conditions
                tmpDeadConditionMaps.Clear();
                foreach (KeyValuePair<Map, GameCondition> keyValuePair in causedConditions)
                {
                    if (!InAoE(keyValuePair.Key.Tile, category, ParentVolcano) || keyValuePair.Value.Expired || !keyValuePair.Key.GameConditionManager.ConditionIsActive(keyValuePair.Value.def))
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

        public override void Initialize(WorldObjectCompProperties props)
        {
            base.Initialize(props);
            graceTicksLeft = initialGraceTicks.RandomInRange;
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            if (Scribe.mode == LoadSaveMode.Saving)
            {
                causedConditions.RemoveAll((KeyValuePair<Map, GameCondition> x) => !Find.Maps.Contains(x.Key));
            }
            Scribe_Collections.Look(ref causedConditions, "tempraryCausedConditions", LookMode.Reference, LookMode.Reference);
            if (Scribe.mode == LoadSaveMode.ResolvingCrossRefs)
            {
                causedConditions.RemoveAll((KeyValuePair<Map, GameCondition> x) => x.Value == null);
            }

            Scribe_Defs.Look(ref currentConditionDef, "conditionDef");
            Scribe_Values.Look(ref category, "incidentCategory", 1);
            Scribe_Values.Look(ref conditionTicksLeft, "conditionTicksLeft", 0);
            Scribe_Values.Look(ref graceTicksLeft, "graceTicksLeft", 0);
            Scribe_Values.Look(ref incidentsCount, "incidentsCount", 0);
        }

        public override string CompInspectStringExtra()
        {
            if (DebugSettings.ShowDevGizmos)
            {
                return "Condition ticks left: " + conditionTicksLeft + "(~" + conditionTicksLeft.TicksToDays().ToString("0.0") + " days)" + "\nGrace ticks left: " + graceTicksLeft + "(~" + graceTicksLeft.TicksToDays().ToString("0.0") + " days)";
            }
            if (currentConditionDef != null)
            {
                return "Mashed_Ashlands_VolcanoTriggeredCondition".Translate(category, currentConditionDef.label);
            }
            return base.CompInspectStringExtra();
        }

        public override void PostDrawExtraSelectionOverlays()
        {
            if(currentConditionDef != null)
            {
                if (category != ParentVolcano.Category)
                {
                    int radius = ParentVolcano.EffectRadiusFor(category);
                    if (radius != -1)
                    {
                        GenDraw.DrawWorldRadiusRing(parent.Tile, radius);
                    }
                }
            }
            base.PostDrawExtraSelectionOverlays();
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach (Gizmo gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }

            if (DebugSettings.ShowDevGizmos)
            {
                yield return new Command_Action
                {
                    defaultLabel = "DEV: Set duration ticks to 0",
                    action = delegate ()
                    {
                        conditionTicksLeft = 0;
                    },
                };

                yield return new Command_Action
                {
                    defaultLabel = "DEV: Set grace ticks to 0",
                    action = delegate ()
                    {
                        graceTicksLeft = 0;
                    },
                };

                yield return new Command_Action
                {
                    defaultLabel = "DEV: Randomise initial grace ticks",
                    defaultDesc = "Set the current grace ticks to a random value between " + initialGraceTicks.min + " and " + initialGraceTicks.max,
                    action = delegate ()
                    {
                        graceTicksLeft = initialGraceTicks.RandomInRange;
                    },
                };

                yield return new Command_Action
                {
                    defaultLabel = "DEV: Force new condition",
                    action = delegate ()
                    {
                        TriggerCondition();
                    },
                };
            }
        }

        public override void PostDestroy()
        {
            EndConditions();
            base.PostDestroy();
        }

        public int incidentsCount = 0;
        private GameConditionDef currentConditionDef;
        private float durationDays = 0;
        private float graceDaysAfter = 0;
        private int category = 1;
        private bool endMessage = false;

        private const int tickInterval = 60;
        private int conditionTicksLeft = 0;
        private int graceTicksLeft = 0;
        private IntRange initialGraceTicks = new IntRange(300000, 1500000);

        private Dictionary<Map, GameCondition> causedConditions = new Dictionary<Map, GameCondition>();
        private static List<Map> tmpDeadConditionMaps = new List<Map>();
    }
}
using Verse;
using RimWorld;
using System.Collections.Generic;
using RimWorld.Planet;

namespace MorrowRim2
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

        public Volcano ParentVolcano => parent as Volcano;
        public IEnumerable<GameCondition> CausedConditions => causedConditions.Values;
        public bool CanCauseCondition => graceTicksLeft == 0;


        /// <summary>
        /// 
        /// </summary>
        public void TriggerCondition()
        {
            PotentialConditions condition = Props.potentialConditions.RandomElementByWeight(x => x.weight);
            if (condition != null)
            {
                EndConditions();
                SetCondition(condition, ParentVolcano);
                if (condition.countAsIncident)
                {
                    ParentVolcano.IncidentTriggered();
                }
                if (condition.sendLetter)
                {
                    Find.LetterStack.ReceiveLetter(
                        "MorrowRim_TheAshlands_VolcanoConditionLetter_Label".Translate(ParentVolcano.Name, category, currentConditionDef.label).CapitalizeFirst(),
                        "MorrowRim_TheAshlands_VolcanoConditionLetter_Description".Translate(ParentVolcano.Name, category, currentConditionDef.label, currentConditionDef.description), 
                        currentConditionDef.letterDef, ParentVolcano, null, null);
                }
                conditionTicksLeft = duration;
                graceTicksLeft = gracePeriodAfter;
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
            duration = condition.duration.RandomInRange;
            gracePeriodAfter = condition.gracePeriodAfter.RandomInRange;
            category = Rand.RangeInclusive(1, parentVolcano.Category);
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndConditions()
        {
            if (endMessage)
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
            if (MorrowRim_ModSettings.VolcanoEnableRandomConditions)
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
                        if (Find.TickManager.TicksGame % CheckInterval == 0)
                        {
                            if (MorrowRim_ModSettings.AshStormAffectsCaravan && currentConditionDef.conditionClass == typeof(GameCondition_AshStorm))
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
                    conditionTicksLeft--;
                }
                else
                {
                    if (graceTicksLeft > 0)
                    {
                        graceTicksLeft--;
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
            Scribe_Values.Look(ref category, "category", 1);
            Scribe_Values.Look(ref conditionTicksLeft, "conditionTicksLeft", 0);
            Scribe_Values.Look(ref graceTicksLeft, "graceTicksLeft", 0);
        }

        public override string CompInspectStringExtra()
        {
            if (currentConditionDef != null)
            {
                return "MorrowRim_TheAshlands_VolcanoTriggeredCondition".Translate(category, currentConditionDef.label);
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

        private GameConditionDef currentConditionDef;
        private int duration = 0;
        private int gracePeriodAfter = 0;
        private int category = 1;
        private bool endMessage = false;

        private int conditionTicksLeft = 0;
        private int graceTicksLeft = 0;
        private IntRange initialGraceTicks = new IntRange(1500000, 300000);

        private Dictionary<Map, GameCondition> causedConditions = new Dictionary<Map, GameCondition>();
        private static List<Map> tmpDeadConditionMaps = new List<Map>();
        public const int CheckInterval = 3451;
    }
}

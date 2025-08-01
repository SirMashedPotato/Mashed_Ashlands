﻿using Verse;
using RimWorld.Planet;
using System.Collections.Generic;
using RimWorld;
using System.Linq;

namespace Mashed_Ashlands
{
    public class Volcano : WorldObject
    {
        public override bool HasName => nameInt != null;

        public string Name
        {
            get
            {
                return nameInt;
            }
            set
            {
                nameInt = value;
            }
        }

        public int Category
        {
            get
            {
                return volcanoCategory;
            }
            set
            {
                volcanoCategory = value;
            }
        }

        public override string Label
        {
            get
            {
                if (HasName)
                {
                    return nameInt;
                }
                return base.Label;
            }
        }

        public string LastIncident
        {
            get
            {
                return lastIncident;
            }
            set
            {
                lastIncident = value;
            }
        }

        public int TotalIncidents
        {
            get
            {
                return totalIncidents;
            }
            set
            {
                totalIncidents = value;
            }
        }

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

        public void IncidentTriggered()
        {
            totalIncidents++;
            lastIncident = GenDate.DateFullStringAt(Find.TickManager.TicksAbs, DrawPos);
        }

        public int EffectRadiusFor(int category)
        {
            if (category > 0)
            {
                int maxDistance = Mashed_Ashlands_ModSettings.VolcanoMaxAffectedArea;
                if (Mashed_Ashlands_ModSettings.VolcanoAffectedAreaScaleWithWorldSize && planetCoverage != 0.3)
                {
                    maxDistance = (int)(maxDistance * ((planetCoverage * 3) + 0.1f));
                    if (maxDistance < 1)
                    {
                        maxDistance = 1;
                    }
                }
                return (int)(category * 0.2f * maxDistance);
            }
            return -1;
        }

        /// <summary>
        /// If performance is terrible switch to the below
        /// return Grid.ApproxDistanceInTiles(parentVolcano.Tile, tile) <= worldRange;
        /// slight issue with that though, tiles outside of the visible radius may be effected if they are along a line instead of a corner
        /// </summary>
        public bool InAoE(PlanetTile tile, int category)
        {
            if (tile.Layer != Tile.Layer)
            {
                return false;
            }
            int worldRange = EffectRadiusFor(category);
            return Grid.TraversalDistanceBetween(Tile, tile, true, worldRange + 1) <= worldRange;
        }

        public override void SpawnSetup()
        {
            planetCoverage = Find.World.PlanetCoverage;
            base.SpawnSetup();
        }

        public override IEnumerable<StatDrawEntry> SpecialDisplayStats
        {
            get
            {
                WorldObjectComp_VolcanoDetails compDetailsRadius = GetComponent<WorldObjectComp_VolcanoDetails>();
                if (compDetailsRadius != null && !compDetailsRadius.Props.extinct)
                {
                    int categoryIndex = compDetailsRadius.Props.categoryWeights.FindIndex(x => x.category == Category);
                    for (int i = 0; i <= categoryIndex; i++)
                    {
                        int category = compDetailsRadius.Props.categoryWeights[i].category;
                        yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Ashlands_VolcanoIncidentRadius, "Mashed_Ashlands_VolcanoRadiusCategoryLabel".Translate(category),
                            "Mashed_Ashlands_VolcanoRadiusCategoryRadius".Translate(EffectRadiusFor(category)),
                            "Mashed_Ashlands_VolcanoRadiusCategoryDescription".Translate(category), 1, null, null, false);
                    }
                }

                WorldObjectComp_RandomConditionCauser compDetailsConditons = GetComponent<WorldObjectComp_RandomConditionCauser>();
                if (compDetailsConditons != null && !compDetailsConditons.Props.potentialConditions.NullOrEmpty())
                {
                    if (totalIncidentWeight == -1)
                    {
                        SetTotalIncidentWeight(compDetailsConditons.Props);
                    }
                    foreach (PotentialConditions condition in compDetailsConditons.Props.potentialConditions)
                    {
                        yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Ashlands_VolcanoPotentialIncidents, condition.volcanicConditionDef.label,
                            "Mashed_Ashlands_VolcanoConditionChance".Translate((condition.weight / totalIncidentWeight).ToStringPercent()),
                            (condition.volcanicConditionDef.description ?? condition.volcanicConditionDef.conditionDef.description) + 
                            "Mashed_Ashlands_VolcanoConditionDuration".Translate(condition.GetTrueConditionDuration, condition.GetTrueGraceDuration, condition.volcanicConditionDef.minVolcanoCategory), 
                            (int)(condition.weight * 10));
                    }
                }
            }
        }

        private void SetTotalIncidentWeight(WorldObjectCompProperties_RandomConditionCauser props)
        {
            totalIncidentWeight = 0;
            foreach (PotentialConditions condition in props.potentialConditions)
            {
                totalIncidentWeight += condition.weight;
            }
        }

        public override bool AllMatchingObjectsOnScreenMatchesWith(WorldObject other)
        {
            return def == other.def;
        }

        public override void ExposeData()
        {
            base.ExposeData();
            if (HasName)
            {
                Scribe_Values.Look(ref nameInt, "name", null);
            }
            Scribe_Values.Look(ref planetCoverage, "planetCoverage", 0.3f);
            Scribe_Values.Look(ref volcanoCategory, "volcanoCategory", 1);
            Scribe_Values.Look(ref lastIncident, "lastIncident", "Unknown");
            Scribe_Values.Look(ref totalIncidents, "totalIncidents", 0);
        }

        private float planetCoverage = 0.3f;
        private string nameInt = null;
        private int volcanoCategory = 1;
        private string lastIncident = "Mashed_Ashlands_Unknown".Translate();
        private int totalIncidents = 0;
        private float totalIncidentWeight = -1;
    }
}

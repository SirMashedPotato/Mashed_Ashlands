using Verse;
using RimWorld.Planet;
using System.Collections.Generic;
using RimWorld;

namespace MorrowRim2
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

        public void IncidentTriggered()
        {
            totalIncidents++;
            lastIncident = GenDate.DateFullStringAt(Find.TickManager.TicksAbs, DrawPos);
        }

        public int EffectRadiusFor(int category)
        {
            if (category > 0)
            {
                int maxDistance = MorrowRim_ModSettings.VolcanoMaxAffectedArea;
                if (MorrowRim_ModSettings.VolcanoAffectedAreaScaleWithWorldSize)
                {
                    maxDistance = (int)(maxDistance * ((Find.World.PlanetCoverage * 3) + 0.1f));
                    if (maxDistance < 1)
                    {
                        maxDistance = 1;
                    }
                }
                return (int)(category * 0.2f * maxDistance);
            }
            return -1;
        }

        public override void SpawnSetup()
        {
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
                        yield return new StatDrawEntry(StatCategoryDefOf.MorrowRim_VolcanoIncidentRadius, "MorrowRim_TheAshlands_VolcanoRadiusCategoryLabel".Translate(category),
                            "MorrowRim_TheAshlands_VolcanoRadiusCategoryRadius".Translate(EffectRadiusFor(category)), 
                            "MorrowRim_TheAshlands_VolcanoRadiusCategoryDescription".Translate(category), 1, null, null, false);
                    }
                }

                WorldObjectComp_RandomConditionCauser compDetailsConditons = GetComponent<WorldObjectComp_RandomConditionCauser>();
                if (compDetailsConditons != null && !compDetailsConditons.Props.potentialConditions.NullOrEmpty())
                {
                    foreach(PotentialConditions condition in compDetailsConditons.Props.potentialConditions) 
                    {
                        if (condition.conditionDef != null)
                        {
                            yield return new StatDrawEntry(StatCategoryDefOf.MorrowRim_VolcanoPotentialIncidents, condition.conditionDef.label, 
                                "MorrowRim_TheAshlands_VolcanoConditionWeight".Translate(condition.weight.ToString()), 
                                condition.conditionDef.description, 1, null, null, false);
                        }
                    }
                }
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
            Scribe_Values.Look(ref volcanoCategory, "category", 1);
            Scribe_Values.Look(ref lastIncident, "lastIncident", "Unknown");
            Scribe_Values.Look(ref totalIncidents, "totalIncidents", 0);
        }

        private string nameInt = null;
        private int volcanoCategory = 1;
        private string lastIncident = "MorrowRim_TheAshlands_Unknown".Translate();
        private int totalIncidents = 0;
    }
}

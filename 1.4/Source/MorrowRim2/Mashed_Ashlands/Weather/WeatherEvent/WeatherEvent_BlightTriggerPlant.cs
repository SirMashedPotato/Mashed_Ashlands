using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Mashed_Ashlands
{
    public class WeatherEvent_BlightTriggerPlant : WeatherEvent
    {
        public WeatherEvent_BlightTriggerPlant(Map map) : base(map)
        {
        }

        public override bool Expired => true;

        public override void FireEvent()
        {
            if (Mashed_Ashlands_ModSettings.BlightStormBlightPlants)
            {
                List<Thing> potentialTargets = (from x in map.listerThings.ThingsInGroup(ThingRequestGroup.Plant)
                               where !PlantImmuneToBlight(x as Plant)
                               select x).ToList();
                if (!potentialTargets.NullOrEmpty())
                {
                    int numberBlighted = (int)Rand.Gaussian(Mashed_Ashlands_ModSettings.BlightStormBlightPlantsNumber);
                    List<Plant> actualTargets = new List<Plant>();
                    if (numberBlighted > potentialTargets.Count())
                    {
                        numberBlighted = potentialTargets.Count();
                    }
                    for (int i = 0; i < numberBlighted; i++)
                    {
                        Plant target = potentialTargets.RandomElement() as Plant;
                        BlightPlant(target);
                        potentialTargets.Remove(target);
                        actualTargets.Add(target);
                    }
                    if (!actualTargets.NullOrEmpty())
                    {
                        SendLetter(actualTargets);
                    }
                }
            }
        }

        /// <summary>
        /// Meant for use as a hook for potential Harmony patches
        /// Final check doesn't use p.BlightableNow, as that checks if the plant is a possible wild plant for the biome
        /// </summary>
        public bool PlantImmuneToBlight(Plant p)
        {
            if (!p.sown && !Mashed_Ashlands_ModSettings.BlightStormBlightWildPlants)
            {
                return true;
            }
            return !p.Blighted && p.def.plant.Blightable && p.LifeStage != PlantLifeStage.Sowing;
        }

        public void SendLetter(List<Plant> plants)
        {
            StringBuilder plantDetails = new StringBuilder();
            foreach (Plant p in plants)
            {
                if (plantDetails.Length != 0)
                {
                    plantDetails.AppendLine();
                }
                plantDetails.Append("  - " + p.LabelNoCount);
            }
            Find.LetterStack.ReceiveLetter("Mashed_Ashlands_BlightedPlants_Label".Translate(), "Mashed_Ashlands_BlightdPlants_Description".Translate() + plantDetails.ToString(), LetterDefOf.MorrowRim_VolcanoNegativeEvent, plants, null, null);
        }

        public void BlightPlant(Plant p)
        {
            p.CropBlighted();
        }

        public override void WeatherEventTick()
        {
        }
    }
}

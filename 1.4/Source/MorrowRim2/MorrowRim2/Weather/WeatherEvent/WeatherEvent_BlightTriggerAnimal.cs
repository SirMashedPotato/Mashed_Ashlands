using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    public class WeatherEvent_BlightTriggerAnimal : WeatherEvent
    {
        public WeatherEvent_BlightTriggerAnimal(Map map) : base(map)
        {
        }

        public override bool Expired => true;

        public override void FireEvent()
        {
            if (true)   //potential setting, disable for animal
            {
                List<Pawn> allPawnsSpawned = map.mapPawns.AllPawnsSpawned;
                List<Pawn> validTargets = new List<Pawn>();
                foreach(Pawn potentialTarget in allPawnsSpawned)
                {
                    if (potentialTarget.RaceProps.Animal)
                    {
                        if (!potentialTarget.Position.Roofed(map) && !PawnImmuneToBlight(potentialTarget))
                        {
                            validTargets.Add(potentialTarget);
                        }
                    }
                }
                if (!validTargets.NullOrEmpty())
                {
                    BlightAnimal(validTargets.RandomElementByWeight(x => x.RaceProps.manhunterOnDamageChance));
                }
            }
        }

        /// <summary>
		/// Meant for use as a hook for potential Harmony patches
		/// </summary>
		public bool PawnImmuneToBlight(Pawn p)
        {
            //potential settings, target animals with factions, target animals of player faction

            return false;
        }

        public void BlightAnimal(Pawn p)
        {
            p.health.AddHediff(HediffDefOf.MorrowRim_AshBlight);
        }

        public override void WeatherEventTick()
        {
        }
    }
}

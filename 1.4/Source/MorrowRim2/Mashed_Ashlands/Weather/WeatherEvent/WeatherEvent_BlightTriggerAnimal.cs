using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class WeatherEvent_BlightTriggerAnimal : WeatherEvent
    {
        public WeatherEvent_BlightTriggerAnimal(Map map) : base(map)
        {
        }

        public override bool Expired => true;

        public override void FireEvent()
        {
            if (Mashed_Ashlands_ModSettings.BlightStormBlightAnimals)
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
            if (p.Faction != null)
            {
                if (p.Faction == Faction.OfPlayerSilentFail && !Mashed_Ashlands_ModSettings.BlightStormBlightPlayerAnimals)
                {
                    return true;
                }
                if (p.Faction != Faction.OfPlayerSilentFail && !Mashed_Ashlands_ModSettings.BlightStormBlightNonPlayerAnimals)
                {
                    return true;
                }
            }

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

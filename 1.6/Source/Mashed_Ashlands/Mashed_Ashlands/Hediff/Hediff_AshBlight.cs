using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class Hediff_AshBlight : HediffWithComps
    {
        public const int plantSpreadRadius = 3;
        public const int plantSpreadTicks = 600;
        public const float plantSpreadChance = 0.3f;
        public const float pawnSpreadChance = 0.3f;

        public override bool ShouldRemove => false;

        private bool InBlightedState
        {
            get
            {
                if (pawn.RaceProps.Animal)
                {
                    return pawn.mindState.mentalStateHandler.CurStateDef == MentalStateDefOf.Mashed_Ashlands_BlightedPermanent;
                }
                return false;
            }
        }

        public override void TickInterval(int delta)
        {
            base.TickInterval(delta);
            if (pawn.IsAnimal)
            {
                StartMentalState();
            }
            if (pawn.IsHashIntervalTick(plantSpreadTicks, delta))
            {
                if (Mashed_Ashlands_ModSettings.AshBlightCanSpreadToPlants)
                {
                    SpreadToPlant();
                }
            }
        }

        private void StartMentalState()
        {
            pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Mashed_Ashlands_BlightedPermanent, "CausedByHediff".Translate(def.LabelCap),
                forced: true, forceWake: true, transitionSilently: true);
        }

        private void SpreadToPlant()
        {
            if (!Rand.Chance(plantSpreadChance))
            {
                return;
            }

            IEnumerable<IntVec3> radius = GenRadial.RadialCellsAround(pawn.Position, plantSpreadRadius, false).InRandomOrder();
            foreach (IntVec3 cell in radius)
            {
                if (!cell.InBounds(pawn.Map))
                {
                    continue;
                }

                Plant plant = cell.GetFirstThing<Plant>(pawn.Map);

                if (plant == null)
                {
                    continue;
                }

                if (!plant.sown && !Mashed_Ashlands_ModSettings.BlightStormBlightWildPlants)
                {
                    continue;
                }

                if (plant.Blighted || !plant.def.plant.Blightable || plant.LifeStage == PlantLifeStage.Sowing)
                {
                    continue;
                }

                plant.CropBlighted();
                break;
            }
        }

        public override void PostRemoved()
        {
            base.PostRemoved();
            if (InBlightedState)
            {
                pawn.mindState.mentalStateHandler.CurState.RecoverFromState();
            }
        }

        public override void Notify_PawnDamagedThing(Thing thing, DamageInfo dinfo, DamageWorker.DamageResult result)
        {
            base.Notify_PawnDamagedThing(thing, dinfo, result);
            if (result.hediffs.NullOrEmpty())
            {
                return;
            }

            if (thing is Pawn victim && victim.IsAnimal)
            {
                if (!Mashed_Ashlands_ModSettings.AshBlightCanSpread)
                {
                    return;
                }

                if (!Rand.Chance(pawnSpreadChance))
                {
                    return;
                }
                bool infectFlag = false;
                if (victim.Faction != null)
                {
                    if (victim.Faction == Faction.OfPlayerSilentFail)
                    {
                        if (Mashed_Ashlands_ModSettings.BlightStormBlightPlayerAnimals)
                        {
                            infectFlag = true;
                        }
                    }
                    else if (Mashed_Ashlands_ModSettings.BlightStormBlightNonPlayerAnimals)
                    {
                        infectFlag = true;
                    }
                }
                else
                {
                    infectFlag = true;
                }

                if (infectFlag)
                {
                    victim.health.AddHediff(def, dinfo: dinfo, result: result);
                }
            }
        }
    }
}

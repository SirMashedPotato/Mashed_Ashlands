using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class GameCondition_Earthquake : GameCondition
    {
        public override int TransitionTicks => 5000;

        public override void GameConditionTick()
        {
            List<Map> affectedMaps = AffectedMaps;
            if (Find.TickManager.TicksGame % shakeInterval == 0 && Mashed_Ashlands_ModSettings.EarthquakeShake)
            {
                for (int i = 0; i < affectedMaps.Count; i++)
                {
                    if (Find.CurrentMap == affectedMaps[i])
                    {
                        Find.CameraDriver.shaker.SetMinShake(3);
                        break;
                    }
                }
            }
        }

        public override void DoCellSteadyEffects(IntVec3 c, Map map)
        {
            if (500 <= TicksPassed)
            {
                List<Thing> thingList = c.GetThingList(map);
                if (thingList.NullOrEmpty() || c.GetRoofHolderOrImpassable(map) == null)
                {
                    if (Mashed_Ashlands_ModSettings.EarthquakeCollapseMountains)
                    {
                        if (c.GetRoof(map) == RoofDefOf.RoofRockThick)
                        {
                            if (Rand.Value < 0.01f && IsValidCell(c, map))
                            {
                                RoofCollapserImmediate.DropRoofInCells(c, map);
                            }
                            else
                            {
                                if (Rand.Chance(0.05f))
                                {
                                    FleckMaker.ThrowDustPuffThick(c.ToVector3(), map, 1f, Color.grey);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Mashed_Ashlands_ModSettings.EarthquakeDamageBuildings)
                    {
                        for (int i = 0; i < thingList.Count; i++)
                        {
                            Thing thing = thingList[i];
                            if (thing is Building b)
                            {
                                if (IsValidBuilding(b))
                                {
                                    if (Rand.Chance(Mashed_Ashlands_ModSettings.EarthquakeDamageBuildingsChance))
                                    {
                                        DamageInfo info = new DamageInfo
                                        {
                                            Def = DamageDefOf.Blunt
                                        };
                                        info.SetAmount(Rand.Gaussian(Mashed_Ashlands_ModSettings.EarthquakeDamageBuildingsDamage));
                                        thing.TakeDamage(info);
                                        FleckMaker.ThrowDustPuffThick(c.ToVector3(), map, 2f, Color.grey);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        // <summary>
        /// Meant for use as a hook for potential Harmony patches
        /// </summary>
        public bool IsValidCell(IntVec3 c, Map map)
        {
            if (c.GetFirstPawn(map) == null && c.GetFirstItem(map) == null && c.GetFirstBuilding(map) == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
		/// Meant for use as a hook for potential Harmony patches
		/// </summary>
        public bool IsValidBuilding(Building b)
        {
            if (b.def.holdsRoof && !b.def.building.isNaturalRock && b.def.building.repairable)
            {
                if (Mashed_Ashlands_ModSettings.EarthquakeDamageBuildingsNonPlayer || b.Faction == Faction.OfPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        public override float AnimalDensityFactor(Map map)
        {
            return 0.5f;
        }

        public override void End()
        {
            base.End();
        }

        public const int shakeInterval = 11;
    }
}

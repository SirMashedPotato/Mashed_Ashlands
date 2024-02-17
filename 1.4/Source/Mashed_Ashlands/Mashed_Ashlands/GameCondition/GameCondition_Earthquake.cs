using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class GameCondition_Earthquake : GameCondition
    {
        public override int TransitionTicks
        {
            get
            {
                return 5000;
            }
        }

        public override void Init()
        {
            base.Init();
        }

        public override void GameConditionTick()
        {
            List<Map> affectedMaps = AffectedMaps;
            if (Find.TickManager.TicksGame % CheckInterval == 0 && Mashed_Ashlands_ModSettings.AshStormDamageBuildings)  //TODO setting
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
            List<Thing> thingList = c.GetThingList(map);
            if (thingList.NullOrEmpty() || c.GetRoofHolderOrImpassable(map) == null)
            {
                if (Mashed_Ashlands_ModSettings.AshStormDamageBuildings)  //TODO setting
                {
                    if (c.GetRoof(map) == RoofDefOf.RoofRockThick)
                    {
                        if (Rand.Chance(0.01f)) //TODO setting
                        {
                            RoofCollapserImmediate.DropRoofInCells(c, map);
                        }
                    }
                }
            }
            else
            {
                if (Mashed_Ashlands_ModSettings.AshStormDamageBuildings)  //TODO setting
                {
                    for (int i = 0; i < thingList.Count; i++)
                    {
                        Thing thing = thingList[i];
                        if (thing is Building b)
                        {
                            if (IsValidBuilding(b))
                            {
                                if (Rand.Chance(0.1f)) //TODO setting
                                {
                                    DamageInfo info = new DamageInfo
                                    {
                                        Def = DamageDefOf.Blunt
                                    };
                                    info.SetAmount(Rand.Gaussian(5)); //TODO setting
                                    thing.TakeDamage(info);
                                    FleckMaker.ThrowDustPuffThick(c.ToVector3(), map, 1f, Color.grey);
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
		/// Meant for use as a hook for potential Harmony patches
		/// </summary>
        public bool IsValidBuilding(Building b)
        {
            if (b.def.holdsRoof && !b.def.building.isNaturalRock)
            {
                if (Mashed_Ashlands_ModSettings.AshStormDamageBuildings || b.Faction == Faction.OfPlayer) //TODO setting
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

        public const int CheckInterval = 41;
    }
}

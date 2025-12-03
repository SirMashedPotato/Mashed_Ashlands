using RimWorld;
using RimWorld.Planet;
using System.Linq;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public abstract class DangerousTunnelsMapComponent : CustomMapComponent
    {
        public PocketMapExit mineExit;
        public Building_UndercaveEntrance mineEntrance;

        private float instability;
        private FloatRange instabilityGainRange = new FloatRange(0f, 0.06f);
        private int checkInterval;
        private IntRange checkIntervalRange = new IntRange(15000, 60000);

        public Map SourceMap => (map.Parent as PocketMapParent)?.sourceMap;

        public DangerousTunnelsMapComponent(Map map) : base(map)
        {
            instability = instabilityGainRange.RandomInRange;
            checkInterval = checkIntervalRange.RandomInRange;
        }

        public override void MapGenerated()
        {
            base.MapGenerated();

            mineEntrance = SourceMap?.listerThings?.ThingsOfDef(ThingDefOf.Mashed_Ashlands_UndercaveEntrance).FirstOrDefault() as Building_UndercaveEntrance;
            if (mineEntrance == null)
            {
                Log.Warning("Abandoned mine entrance was not found after generating undercave, if this map was created via dev tools you can ignore this");
                return;
            }

            mineExit = map.listerThings.ThingsOfDef(RimWorld.ThingDefOf.CaveExit).FirstOrDefault() as PocketMapExit;
            if (mineExit == null)
            {
                Log.Error("Abandoned mine exit was not found after generating abandoned mine");
                return;
            }
        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();
            if (map == null)
            {
                return;
            }

            if (map.IsHashIntervalTick(checkInterval))
            {
                checkInterval = checkIntervalRange.RandomInRange;

                if (instability >= 1f)
                {
                    TriggerInstabilityEffect();
                    instability = 0f;
                }
                else
                {
                    if (Find.CurrentMap == map)
                    {
                        Find.CameraDriver.shaker.SetMinShake(1);
                    }
                    instability = Mathf.Clamp(instability + instabilityGainRange.RandomInRange, 0f, 1f);
                }
            }
        }

        public abstract void TriggerInstabilityEffect();

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref instability, "instability", 0f);
            Scribe_Values.Look(ref checkInterval, "checkInterval", 60000);
            Scribe_References.Look(ref mineEntrance, "mineEntrance");
            Scribe_References.Look(ref mineExit, "mineExit");
        }
    }
}

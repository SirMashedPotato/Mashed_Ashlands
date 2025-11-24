using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class AbandonedMineMapComponent : CustomMapComponent
    {
        public PocketMapExit mineExit;
        public Building_AbandonedMineEntrance mineEntrance;

        private static IntRange caveInCountRange = new IntRange(1,3);
        private static IntRange caveInSizeRange = new IntRange(10, 20);

        private float instability;
        private FloatRange instabilityGainRange = new FloatRange(0f, 0.06f);
        private int checkInterval;
        private IntRange checkIntervalRange = new IntRange(15000, 60000);

        public Map SourceMap => (map.Parent as PocketMapParent)?.sourceMap;

        public AbandonedMineMapComponent(Map map) : base(map)
        {
            instability = instabilityGainRange.RandomInRange;
            checkInterval = checkIntervalRange.RandomInRange;
        }

        public override void MapGenerated()
        {
            base.MapGenerated();

            mineEntrance = SourceMap?.listerThings?.ThingsOfDef(ThingDefOf.Mashed_Ashlands_AbandonedMineEntrance).FirstOrDefault() as Building_AbandonedMineEntrance;
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
                    Messages.Message("Mashed_Ashlands_AbandonedMine_CaveIn".Translate(mineEntrance.UndercaveTypeDef), mineExit, MessageTypeDefOf.NegativeEvent);
                    TriggerCaveIn();
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

        private void TriggerCaveIn()
        {
            int caveInTarget = caveInCountRange.RandomInRange;
            for (int i = 0; i < caveInTarget; i++)
            {
                int caveInSize = caveInSizeRange.RandomInRange;
                CellFinder.TryFindRandomCell(map, c => Utility.CaveInCellValidator(map, c), out IntVec3 result);
                if (result.IsValid)
                {
                    List<IntVec3> caveIn = GridShapeMaker.IrregularLump(result, map, caveInSize, c => Utility.CaveInCellValidator(map, c));
                    foreach (IntVec3 cell in caveIn)
                    {
                        GenSpawn.Spawn(ThingDefOf.Mashed_Ashlands_CollapsingRockRoof, cell, map, WipeMode.FullRefund);
                    }
                }
            }
        }

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

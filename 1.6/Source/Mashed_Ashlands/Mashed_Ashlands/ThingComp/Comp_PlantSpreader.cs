using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class Comp_PlantSpreader : ThingComp
    {
        private CompProperties_PlantSpreader Props
        {
            get
            {
                return (CompProperties_PlantSpreader)props;
            }
        }

        public override void CompTick()
        {
            if (parent.IsHashIntervalTick(Props.tickInterval))
            {
                TrySpreadPlant();
            }
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            foreach (Gizmo gizmo in base.CompGetGizmosExtra())
            {
                yield return gizmo;
            }
            if (DebugSettings.ShowDevGizmos)
            {
                yield return new Command_Action
                {
                    action = delegate
                    {
                        TrySpreadPlant();
                    },
                    defaultLabel = "DEV: Try spread plant"
                };
            }
        }

        public void TrySpreadPlant()
        {
            if (Props.disableIfPolluted && parent.Position.IsPolluted(parent.Map))
            {
                FleckMaker.ThrowDustPuffThick(parent.Position.ToVector3(), parent.Map, 1f, Color.green);
                return;
            }
            IEnumerable<IntVec3> radius = GenRadial.RadialCellsAround(parent.Position, Props.spreadRadius, false);
            foreach (IntVec3 cell in radius)
            {
                if (!cell.InBounds(parent.Map) || !cell.Standable(parent.Map) || cell.GetFirstBuilding(parent.Map) != null || cell.GetFirstThing<Plant>(parent.Map) != null)
                {
                    continue;
                }
                if (!Props.spreadOnWater && cell.GetTerrain(parent.Map).IsWater)
                {
                    continue;
                }
                GenSpawn.Spawn(Props.plantDef, cell, parent.Map, WipeMode.FullRefund);
                break;
            }
        }
    }
}

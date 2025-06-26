using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class Comp_SimpleItemProcessor : ThingComp
    {
        public CompProperties_SimpleItemProcessor Props => (CompProperties_SimpleItemProcessor)props;

        private int ticksLeft;
        private CompRefuelable compRefuelable;

        private CompRefuelable CompRefuelable
        {
            get
            {
                if (compRefuelable == null)
                {
                    compRefuelable = parent.TryGetComp<CompRefuelable>();
                }
                return compRefuelable;
            }
        }

        private void SetTicks()
        {
            ticksLeft = Props.processDays * GenDate.TicksPerDay;
        }

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            if (!respawningAfterLoad)
            {
                SetTicks();
            }
        }

        public override void CompTickRare()
        {
            base.CompTickRare();
            if(CompRefuelable == null)
            {
                return;
            }
            if (!parent.Spawned)
            {
                return;
            }
            if (CompRefuelable.IsFull)
            {
                ticksLeft -= GenTicks.TickRareInterval;
            }
            if (ticksLeft <= 0)
            {
                FinishProcess();
            }
        }

        private void FinishProcess()
        {
            Thing droppedThing = ThingMaker.MakeThing(Props.yieldThingDef);
            droppedThing.stackCount = Props.yieldAmount;
            GenPlace.TryPlaceThing(droppedThing, parent.Position, parent.Map, ThingPlaceMode.Near);
            CompRefuelable.ConsumeFuel(CompRefuelable.Props.fuelCapacity);
            SetTicks();
        }

        public override void ReceiveCompSignal(string signal)
        {
            if (signal == "RuinedByTemperature")
            {
                CompRefuelable.ConsumeFuel(CompRefuelable.Props.fuelCapacity);
                SetTicks();
            }
        }

        public override string CompInspectStringExtra()
        {
            if (CompRefuelable != null && !CompRefuelable.IsFull)
            {
                return "Mashed_Ashlands_SimpleItemProcessorEmpty".Translate(parent);
            }
            return "Mashed_Ashlands_SimpleItemProcessorDesc".Translate(ticksLeft.ToStringTicksToPeriodVerbose(), Props.yieldThingDef);
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            foreach(Gizmo gizmo in base.CompGetGizmosExtra()) 
            { 
                yield return gizmo; 
            }

            if (DebugSettings.ShowDevGizmos)
            {
                yield return new Command_Action
                {
                    action = delegate
                    {
                        FinishProcess();
                    },
                    defaultLabel = "DEV: Finish process"
                };
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref ticksLeft, "ticksLeft", 0);
        }
    }
}

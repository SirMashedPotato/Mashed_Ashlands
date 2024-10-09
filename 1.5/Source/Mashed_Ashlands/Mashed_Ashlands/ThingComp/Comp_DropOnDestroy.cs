using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class Comp_DropOnDestroy : ThingComp
    {
		public CompProperties_DropOnDestroy Props
		{
			get
			{
				return (CompProperties_DropOnDestroy)props;
			}
		}

        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            if (Props.thingSetMakerDef != null)
            {
                List<Thing> setDropList = Props.thingSetMakerDef.root.Generate();
                foreach (Thing thing in setDropList)
                {
                    DropThing(thing, previousMap);
                }
            }
            if (!Props.guaranteedDrops.NullOrEmpty())
            {
                foreach(PotentialDrops drop in Props.guaranteedDrops)
                {
                    DoDrop(drop, previousMap);
                }
            }
            if (!Props.potentialDrops.NullOrEmpty())
            {
                PotentialDrops drop = Props.potentialDrops.RandomElementByWeight(x => x.weight);
                if (drop.thingDef != null)
                {
                    DoDrop(drop, previousMap);
                }
            }

            base.PostDestroy(mode, previousMap);
        }

        private void DoDrop(PotentialDrops drop, Map previousMap)
        {
            Thing droppedThing = ThingMaker.MakeThing(drop.thingDef);
            droppedThing.stackCount = drop.amountRange.RandomInRange;
            droppedThing.TryGetComp<CompQuality>()?.SetQuality(QualityUtility.GenerateQualityRandomEqualChance(), ArtGenerationContext.Colony);
            GenPlace.TryPlaceThing(droppedThing, parent.Position, previousMap, ThingPlaceMode.Near);
        }

        private void DropThing(Thing thing, Map previousMap)
        {
            GenPlace.TryPlaceThing(thing, parent.Position, previousMap, ThingPlaceMode.Near);
        }
    }
}

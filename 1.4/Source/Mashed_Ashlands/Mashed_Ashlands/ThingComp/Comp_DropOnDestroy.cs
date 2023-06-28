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
            if (!Props.potentialDrops.NullOrEmpty())
            {
                PotentialDrops drop = Props.potentialDrops.RandomElementByWeight(x => x.weight);
                Thing droppedThing = ThingMaker.MakeThing(drop.thingDef);
                droppedThing.stackCount = drop.amountRange.RandomInRange;
                GenPlace.TryPlaceThing(droppedThing, parent.Position, previousMap, ThingPlaceMode.Direct);
            }

            base.PostDestroy(mode, previousMap);
        }
    }
}

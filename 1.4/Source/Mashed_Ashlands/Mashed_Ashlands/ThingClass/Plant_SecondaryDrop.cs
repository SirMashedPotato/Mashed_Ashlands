using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class Plant_SecondaryDrop : Plant
    {
        public override void PlantCollected(Pawn by, PlantDestructionMode plantDestructionMode)
        {
            if (HarvestableNow)
            {
                PlantProperties props = PlantProperties.Get(def);
                if (props != null && props.secondaryDrop != null)
                {
                    if (!props.secondaryNotWhenLeafless || !LeaflessNow)
                    {
                        if (Rand.Chance(props.secondaryDropChance))
                        {
                            Thing droppedThing = ThingMaker.MakeThing(props.secondaryDrop);
                            droppedThing.stackCount = props.secondaryDropAmountRange.RandomInRange;
                            GenPlace.TryPlaceThing(droppedThing, Position, Map, ThingPlaceMode.Near);
                        }
                    }
                }
            }
            base.PlantCollected(by, plantDestructionMode);
        }
    }
}

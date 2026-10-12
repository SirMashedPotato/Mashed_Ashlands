using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class Plant_SecondaryDrop : Plant
    {
        public override IEnumerable<ThingDefCountClass> GetAdditionalLeavings(DestroyMode mode)
        {
            foreach (ThingDefCountClass additionalLeaving in base.GetAdditionalLeavings(mode))
            {
                yield return additionalLeaving;
            }
            PlantProperties props = PlantProperties.Get(def);
            if (props != null && props.secondaryDrop != null)
            {
                if (!props.secondaryNotWhenLeafless || !LeaflessNow)
                {
                    if (Rand.Chance(props.secondaryDropChance))
                    {
                        ThingDefCountClass extraDrop = new ThingDefCountClass(props.secondaryDrop, props.secondaryDropAmountRange.RandomInRange);
                        yield return extraDrop;
                    }
                }
            }
        }
    }
}

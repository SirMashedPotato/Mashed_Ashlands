using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class ScattererValidator_NoChunks : ScattererValidator
    {
        public override bool Allows(IntVec3 c, Map map)
        {
            HashSet<Thing> hashSet = new HashSet<Thing>(c.GetThingList(map));
            if (hashSet != null)
            {
                foreach (Thing thing in hashSet)
                {
                    if (!thing.def.thingCategories.NullOrEmpty() && thing.def.thingCategories.Contains(ThingCategoryDefOf.StoneChunks))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

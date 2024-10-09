using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class ThingSetMaker_RandomOptionWithNull : ThingSetMaker_RandomOption
    {
        public float nullChance = 0.1f;

        protected override void Generate(ThingSetMakerParams parms, List<Thing> outThings)
        {
            if (Rand.Chance(nullChance))
            {
                return;
            }
            base.Generate(parms, outThings);
        }
    }
}

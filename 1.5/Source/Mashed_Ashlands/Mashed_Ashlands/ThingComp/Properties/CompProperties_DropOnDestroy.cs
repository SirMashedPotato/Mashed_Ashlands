using Verse;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class CompProperties_DropOnDestroy : CompProperties
	{
		public CompProperties_DropOnDestroy()
		{
			compClass = typeof(Comp_DropOnDestroy);
		}
        public List<PotentialDrops> guaranteedDrops;
        public List<PotentialDrops> potentialDrops;
	}

	public class PotentialDrops
    {
		public ThingDef thingDef;
		public IntRange amountRange;
		public float weight = 1;
	}
}

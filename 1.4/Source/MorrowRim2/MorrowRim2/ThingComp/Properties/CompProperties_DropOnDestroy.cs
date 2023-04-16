using Verse;
using System.Collections.Generic;

namespace MorrowRim2
{
    public class CompProperties_DropOnDestroy : CompProperties
	{
		public CompProperties_DropOnDestroy()
		{
			compClass = typeof(Comp_DropOnDestroy);
		}

		public List<PotentialDrops> potentialDrops;
	}

	public class PotentialDrops
    {
		public ThingDef thingDef;
		public IntRange amountRange;
		public float weight;
	}
}

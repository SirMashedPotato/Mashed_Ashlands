using Verse;

namespace MorrowRim2
{
	public class CompProperties_GasOnDestroy : CompProperties
	{
		public CompProperties_GasOnDestroy()
		{
			compClass = typeof(Comp_GasOnDestroy);
		}

		public GasType gasType;
		public float radius = 3f;
	}
}

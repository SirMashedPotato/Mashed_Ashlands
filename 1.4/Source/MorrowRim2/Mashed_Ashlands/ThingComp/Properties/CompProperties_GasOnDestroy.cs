using Verse;

namespace Mashed_Ashlands
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

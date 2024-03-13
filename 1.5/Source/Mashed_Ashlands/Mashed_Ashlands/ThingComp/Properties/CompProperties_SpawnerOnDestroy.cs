using Verse;

namespace Mashed_Ashlands
{
	public class CompProperties_SpawnerOnDestroy : CompProperties
	{
		public CompProperties_SpawnerOnDestroy()
		{
			compClass = typeof(Comp_SpawnerOnDestroy);
		}

		public PawnKindDef pawnKindDef;
		public int numberToSpawn = 1;
	}
}

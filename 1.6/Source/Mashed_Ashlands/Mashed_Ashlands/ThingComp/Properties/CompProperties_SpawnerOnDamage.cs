using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_SpawnerOnDamage : CompProperties
	{
		public CompProperties_SpawnerOnDamage()
		{
			compClass = typeof(Comp_SpawnerOnDamage);
		}

		public PawnKindDef pawnKindDef;
		public float spawnChance = 1f;
		public int cooldownTicks = 500;
	}
}

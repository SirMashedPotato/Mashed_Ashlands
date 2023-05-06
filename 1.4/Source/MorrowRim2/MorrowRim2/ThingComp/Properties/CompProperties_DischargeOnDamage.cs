using Verse;

namespace MorrowRim2
{
	public class CompProperties_DischargeOnDamage : CompProperties
	{
		public CompProperties_DischargeOnDamage()
		{
			compClass = typeof(Comp_DischargeOnDamage);
		}

		public DamageDef damageDef;
		public int damageAmount = 1;
		public float radius = 3;
		public int cooldownTicks = 500;
	}
}

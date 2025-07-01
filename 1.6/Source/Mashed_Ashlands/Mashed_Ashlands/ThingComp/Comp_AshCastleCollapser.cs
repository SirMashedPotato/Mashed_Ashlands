using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class Comp_AshCastleCollapser : ThingComp
	{
		public override void CompTickRare()
		{
			int num = GenMath.RoundRandom(0.15f * parent.Map.windManager.WindSpeed);
			if (Utility.MapHasAshStorm(parent.Map)) num *= 3;
			if (num > 0)
			{
				parent.TakeDamage(new DamageInfo(DamageDefOf.Rotting, num, 0f, -1f, null, null, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, false));
			}
		}
    }
}

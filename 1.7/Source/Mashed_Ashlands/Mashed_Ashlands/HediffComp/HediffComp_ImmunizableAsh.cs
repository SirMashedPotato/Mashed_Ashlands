using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class HediffComp_ImmunizableAsh : HediffComp_Immunizable
    {
		public override float SeverityChangePerDay()
		{
			float num = base.SeverityChangePerDay();
			if (num < 0f && Pawn.Spawned)
			{
				if (!Pawn.Position.Roofed(Pawn.Map))
				{
					if (Utility.MapHasAshStorm(Pawn)
						&& Pawn.GetStatValue(StatDefOf.Mashed_Ashlands_AshResistance, true, -1) < 1f)
					{
						num = 0f;
					}
				}
			}
			return num;
		}
	}
}

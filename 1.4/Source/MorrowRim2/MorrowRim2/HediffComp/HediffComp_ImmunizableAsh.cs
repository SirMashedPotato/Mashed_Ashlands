using RimWorld;
using Verse;

namespace MorrowRim2
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
					if (Pawn.Map.gameConditionManager.ConditionIsActive(GameConditionDefOf.MorrowRim_AshStorm) 
						&& Pawn.GetStatValue(StatDefOf.MorrowRim_AshResistance, true, -1) < 1f)
					{
						num = 0f;
					}
				}
			}
			return num;
		}
	}
}

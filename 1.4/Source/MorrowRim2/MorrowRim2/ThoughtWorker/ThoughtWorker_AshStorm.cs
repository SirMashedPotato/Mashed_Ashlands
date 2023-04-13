using Verse;
using RimWorld;

namespace MorrowRim2
{
    public class ThoughtWorker_AshStorm : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			//If terrible performance, swap to: p.MapHeld.gameConditionManager.ConditionIsActive(GameConditionDefOf.MorrowRim_AshStorm))
			if (p.MapHeld != null && !p.PositionHeld.Roofed(p.MapHeld) && p.MapHeld.gameConditionManager.ActiveConditions.Any((GameCondition x) => x.def.conditionClass == typeof(GameCondition_AshStorm)))
			{
				return ThoughtState.ActiveDefault;
			}
			return ThoughtState.Inactive;
		}
	}
}

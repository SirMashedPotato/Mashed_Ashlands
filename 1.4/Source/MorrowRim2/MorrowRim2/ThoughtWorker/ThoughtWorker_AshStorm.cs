using Verse;
using RimWorld;

namespace MorrowRim2
{
    public class ThoughtWorker_AshStorm : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (p.MapHeld != null && !p.PositionHeld.Roofed(p.MapHeld) && Utility.MapHasAshStorm(p))
			{
				return ThoughtState.ActiveDefault;
			}
			return ThoughtState.Inactive;
		}
	}
}

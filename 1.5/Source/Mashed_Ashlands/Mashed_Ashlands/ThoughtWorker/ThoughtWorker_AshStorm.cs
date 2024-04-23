using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class ThoughtWorker_AshStorm : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (p.SpawnedOrAnyParentSpawned && !p.PositionHeld.Roofed(p.MapHeld) && Utility.MapHasAshStorm(p))
			{
				return ThoughtState.ActiveDefault;
			}
			return ThoughtState.Inactive;
		}
	}
}

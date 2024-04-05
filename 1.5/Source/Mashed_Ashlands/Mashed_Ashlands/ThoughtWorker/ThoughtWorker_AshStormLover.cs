using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class ThoughtWorker_AshStormLover : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (p.MapHeld != null && !p.PositionHeld.Roofed(p.MapHeld))
            {
                if (Utility.MapHasAshStorm(p))
                {
                    if (p.GetStatValue(StatDefOf.Mashed_Ashlands_AshResistance) == 1f)
                    {
                        return ThoughtState.ActiveAtStage(1);
                    }
                    else
                    {
                        return ThoughtState.ActiveAtStage(0);
                    }
                }
                if (Utility.MapHasDustStorm(p))
                {
                    return ThoughtState.ActiveAtStage(2);
                }
            }
            return ThoughtState.Inactive;
        }
    }
}

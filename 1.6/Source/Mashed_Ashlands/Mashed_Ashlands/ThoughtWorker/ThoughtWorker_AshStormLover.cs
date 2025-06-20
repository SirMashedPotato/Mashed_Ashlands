using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class ThoughtWorker_AshStormLover : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (p.SpawnedOrAnyParentSpawned && !p.PositionHeld.Roofed(p.MapHeld))
            {
                if (Utility.MapHasDustStorm(p))
                {
                    return ThoughtState.ActiveAtStage(0);
                }
                if (Utility.MapHasAshStorm(p))
                {
                    float ashResistance = p.GetStatValue(StatDefOf.Mashed_Ashlands_AshResistance);
                    if (ashResistance == 1f)
                    {
                        return ThoughtState.ActiveAtStage(1);
                    }
                    if (ashResistance <= -3f)
                    {
                        return ThoughtState.ActiveAtStage(2);
                    }
                    return ThoughtState.ActiveAtStage(3);
                }
            }
            return ThoughtState.Inactive;
        }
    }
}

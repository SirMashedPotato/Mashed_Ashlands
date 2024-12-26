using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace Mashed_Ashlands
{
    public class ThinkNode_ConditionalAshlandFlowerFeeding : ThinkNode_Conditional
    {
        protected override bool Satisfied(Pawn pawn)
        {
            return Mashed_Ashlands_ModSettings.FlowerFeeding && animalDefs.Contains(pawn.def) && pawn.needs.food.CurLevelPercentage <= 0.7f;
        }

        public List<ThingDef> animalDefs;
    }
}

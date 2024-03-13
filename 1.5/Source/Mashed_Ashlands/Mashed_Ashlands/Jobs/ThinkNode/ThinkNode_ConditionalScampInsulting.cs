using Verse;
using Verse.AI;

namespace Mashed_Ashlands
{
    public class ThinkNode_ConditionalScampInsulting : ThinkNode_Conditional
    {
        protected override bool Satisfied(Pawn pawn)
        {
            return Mashed_Ashlands_ModSettings.ScampInsulting;
        }
    }
}

using Verse;

namespace Mashed_Ashlands
{
    public class Comp_CliffRacerMutation : ThingComp
    {
        public bool hasAsexualMutation = false;

        public override void PostExposeData()
        {
            Scribe_Values.Look(ref hasAsexualMutation, "CliffRacer_HasAsexualMutation");
            base.PostExposeData();
        }
    }
}

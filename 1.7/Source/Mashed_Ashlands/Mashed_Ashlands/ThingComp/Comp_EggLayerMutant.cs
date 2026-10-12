using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class Comp_EggLayerMutant : CompEggLayer
    {
        private bool hasAsexualMutation = false;

        public bool AsexualMutation
        {
            get
            {
                return hasAsexualMutation;
            }
            set
            {
                hasAsexualMutation = value;
            }
        }

        public override void CompTick()
        {
            if (parent.IsHashIntervalTick(5000))
            {
                if (!FullyFertilized && hasAsexualMutation)
                {
                    Fertilize(parent as Pawn);
                }
            }
            base.CompTick();
        }

        public override void PostExposeData()
        {
            Scribe_Values.Look(ref hasAsexualMutation, "CliffRacer_HasAsexualMutation");
            base.PostExposeData();
        }
    }
}

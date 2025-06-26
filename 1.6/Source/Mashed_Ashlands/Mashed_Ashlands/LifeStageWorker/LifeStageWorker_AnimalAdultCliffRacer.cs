using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class LifeStageWorker_AnimalAdultCliffRacer : LifeStageWorker
    {
        public override void Notify_LifeStageStarted(Pawn pawn, LifeStageDef previousLifeStage)
        {
            base.Notify_LifeStageStarted(pawn, previousLifeStage);
            if (Rand.Chance(Mashed_Ashlands_ModSettings.CliffRacerMutantChance))
            {
                pawn.GetComp<Comp_EggLayerMutant>().AsexualMutation = true;
            }
        }
    }
}

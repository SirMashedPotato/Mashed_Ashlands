using RimWorld;

namespace Mashed_Ashlands
{
    public class IncidentWorker_MakeGameConditionVolcanoless : IncidentWorker_MakeGameCondition
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return Mashed_Ashlands_ModSettings.EnableVolcanoRemovalChanges && base.CanFireNowSub(parms);
        }
    }
}

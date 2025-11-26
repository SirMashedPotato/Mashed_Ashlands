using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class IncidentWorker_SiltStriderCrossing : IncidentWorker_SiltStriderPasses
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            if (parms.target is Map map)
            {
                if (map.TileInfo.mutatorsNullable.NullOrEmpty() || !map.TileInfo.Mutators.Contains(TileMutatorDefOf.Mashed_Ashlands_StriderCrossing))
                {
                    return false;
                }

                return base.CanFireNowSub(parms);
            }
            return false;
        }
    }
}

using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class IncidentWorker_MiasmicEruption : IncidentWorker_MakeGameCondition
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            if (!ModsConfig.OdysseyActive)
            {
                return false;
            }

            if (parms.target is Map map)
            {
                if (map.TileInfo.mutatorsNullable.NullOrEmpty() || !map.TileInfo.Mutators.Contains(TileMutatorDefOf.Mashed_Ashlands_Miasmic))
                {
                    return false;
                }

                return base.CanFireNowSub(parms);
            }
            return false;
        }
    }
}

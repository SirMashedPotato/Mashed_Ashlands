using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public abstract class IncidentWorker_AshlandsSpecific : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            BiomeProperties props = BiomeProperties.Get(map.Biome);
            return props != null && props.allowAshlandsIncidents && base.CanFireNowSub(parms);
        }

        protected bool CanWanderIn(IncidentParms parms, ThingDef thingDef)
        {
            Map map = (Map)parms.target;
            return !map.gameConditionManager.ConditionIsActive(RimWorld.GameConditionDefOf.ToxicFallout) 
                && (!ModsConfig.BiotechActive || !map.gameConditionManager.ConditionIsActive(RimWorld.GameConditionDefOf.NoxiousHaze))
                && map.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(thingDef) && TryFindEntryCell(map, out _);
        }

        protected bool TryFindEntryCell(Map map, out IntVec3 cell)
        {
            return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f, false, null);
        }
    }
}

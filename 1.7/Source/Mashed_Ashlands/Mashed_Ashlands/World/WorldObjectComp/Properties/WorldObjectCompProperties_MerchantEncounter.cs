using RimWorld;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class WorldObjectCompProperties_MerchantEncounter : WorldObjectCompProperties
    {
        public WorldObjectCompProperties_MerchantEncounter() => compClass = typeof(WorldObjectComp_MerchantEncounter);

        public List<IncidentDef> incidentDefs;
        public float chance = 0.03f;
    }
}

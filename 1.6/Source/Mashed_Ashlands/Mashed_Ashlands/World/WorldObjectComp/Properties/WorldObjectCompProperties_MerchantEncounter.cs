using RimWorld;

namespace Mashed_Ashlands
{
    public class WorldObjectCompProperties_MerchantEncounter : WorldObjectCompProperties
    {
        public WorldObjectCompProperties_MerchantEncounter() => compClass = typeof(WorldObjectComp_MerchantEncounter);

        public IncidentDef incidentDef;
        public float chance = 0.03f;
    }
}

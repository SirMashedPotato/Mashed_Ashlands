using RimWorld;

namespace Mashed_Ashlands
{
    public class WorldObjectCompProperties_PermanentCondition : WorldObjectCompProperties
    {
        public WorldObjectCompProperties_PermanentCondition() => compClass = typeof(WorldObjectComp_PermanentCondition);

        public VolcanicConditionDef volcanicConditionDef;
        public bool preventConditionStacking = true;
    }
}

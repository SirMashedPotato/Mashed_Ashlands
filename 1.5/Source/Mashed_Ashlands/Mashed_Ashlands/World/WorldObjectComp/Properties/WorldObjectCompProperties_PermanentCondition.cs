using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class WorldObjectCompProperties_PermanentCondition : WorldObjectCompProperties
    {
        public WorldObjectCompProperties_PermanentCondition()
        {
            compClass = typeof(WorldObjectComp_PermanentCondition);
        }


        public GameConditionDef conditionDef;
        public bool preventConditionStacking = true;
    }
}

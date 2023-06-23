using RimWorld;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class WorldObjectDefOf
    {
        static WorldObjectDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(WorldObjectDefOf));
        }
        public static WorldObjectDef Mashed_Ashlands_VolcanoDormant;
        public static WorldObjectDef Mashed_Ashlands_VolcanoActive;
        public static WorldObjectDef Mashed_Ashlands_VolcanoBlighted;
        public static WorldObjectDef Mashed_Ashlands_VolcanoExtinct;
        public static WorldObjectDef Mashed_Ashlands_KwamaNest;
    }
}
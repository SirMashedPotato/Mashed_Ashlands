using RimWorld;

namespace MorrowRim2
{
    [DefOf]
    public static class WorldObjectDefOf
    {
        static WorldObjectDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(WorldObjectDefOf));
        }
        public static WorldObjectDef MorrowRim_VolcanoDormant;
        public static WorldObjectDef MorrowRim_VolcanoActive;
        public static WorldObjectDef MorrowRim_VolcanoBlighted;
        public static WorldObjectDef MorrowRim_VolcanoExtinct;
    }
}
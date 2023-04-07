using RimWorld.Planet;
using Verse;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace MorrowRim2
{
    public static class WorldGenUtility
    {
        public static readonly List<WorldObjectDef> volcanoDefs = new List<WorldObjectDef>
        {
            WorldObjectDefOf.MorrowRim_VolcanoActive,
            WorldObjectDefOf.MorrowRim_VolcanoBlighted,
            WorldObjectDefOf.MorrowRim_VolcanoDormant,
            WorldObjectDefOf.MorrowRim_VolcanoExtinct
        };

        public static float DistanceToClosestVolcano(int tileID)
        {
            WorldObjectsHolder worldObjectsHolder = Find.WorldObjects;
            List<WorldObject> volcanos = new List<WorldObject>(worldObjectsHolder.AllWorldObjects.Where(x => volcanoDefs.Contains(x.def)));
            if (!volcanos.NullOrEmpty())
            {
                return BiomeWorkerUtility.DistanceToClosest(tileID, volcanos);
            }
            return 999f;
        }
    }
}

using RimWorld.Planet;
using Verse;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace Mashed_Ashlands
{
    public static class WorldGenUtility
    {
        public static readonly List<WorldObjectDef> volcanoDefs = new List<WorldObjectDef>
        {
            WorldObjectDefOf.Mashed_Ashlands_VolcanoActive,
            WorldObjectDefOf.Mashed_Ashlands_VolcanoBlighted,
            WorldObjectDefOf.Mashed_Ashlands_VolcanoDormant,
            WorldObjectDefOf.Mashed_Ashlands_VolcanoExtinct
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

        public static float DistanceToClosestKwamaNest(int tileID)
        {
            WorldObjectsHolder worldObjectsHolder = Find.WorldObjects;
            List<WorldObject> kwamaNests = new List<WorldObject>(worldObjectsHolder.AllWorldObjects.Where(x => x.def == WorldObjectDefOf.Mashed_Ashlands_KwamaNest));
            if (!kwamaNests.NullOrEmpty())
            {
                return BiomeWorkerUtility.DistanceToClosest(tileID, kwamaNests);
            }
            return 999f;
        }
    }
}

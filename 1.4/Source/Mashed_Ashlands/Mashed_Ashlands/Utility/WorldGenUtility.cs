using RimWorld.Planet;
using Verse;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace Mashed_Ashlands
{
    public static class WorldGenUtility
    {
        public static float DistanceToClosestVolcano(int tileID)
        {
            WorldObjectsHolder worldObjectsHolder = Find.WorldObjects;
            List<WorldObject> volcanos = new List<WorldObject>(worldObjectsHolder.AllWorldObjects.Where(x => x is Volcano));
            if (!volcanos.NullOrEmpty())
            {
                return DistanceToClosestWorldObjects(tileID, volcanos);
            }
            return 999f;
        }

        public static float DistanceToClosestWorldObject(int tileID, WorldObjectDef worldObject)
        {
            WorldObjectsHolder worldObjectsHolder = Find.WorldObjects;
            List<WorldObject> volcanos = new List<WorldObject>(worldObjectsHolder.AllWorldObjects.Where(x => x.def == worldObject));
            if (!volcanos.NullOrEmpty())
            {
                return DistanceToClosestWorldObjects(tileID, volcanos);
            }
            return -1f;
        }

        public static float DistanceToClosestWorldObjects(int tileID, List<WorldObject> worldObjects)
        {
            WorldGrid worldGrid = Find.WorldGrid;
            float distance = -1f;
            for (int i = 0; i != worldObjects.Count; i++)
            {
                float distance2 = worldGrid.ApproxDistanceInTiles(tileID, worldObjects[i].Tile);
                if (distance == -1 || distance > distance2)
                {
                    distance = distance2;
                }
            }
            return distance;
        }
    }
}

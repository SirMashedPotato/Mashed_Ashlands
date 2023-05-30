using RimWorld.Planet;
using Verse;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace Mashed_Ashlands
{
    public static class BiomeWorkerUtility
    {
        public static float DistanceToClosestVolcano(int tileID, List<WorldObjectDef> worldObjects)
        {
            float closest = -1;
            foreach (WorldObjectDef worldObject in worldObjects)
            {
                float num = DistanceToClosestVolcano(tileID, worldObject);
                if (closest == -1 || closest > num)
                {
                    closest = num;
                }
            }
            return closest;
        }

        public static float DistanceToClosestVolcano(int tileID, WorldObjectDef worldObject)
        {
            WorldObjectsHolder worldObjectsHolder = Find.WorldObjects;
            List<WorldObject> volcanos = new List<WorldObject>(worldObjectsHolder.AllWorldObjects.Where(x => x.def == worldObject));
            if (!volcanos.NullOrEmpty())
            {
                return DistanceToClosest(tileID, volcanos);
            }
            return -1f;
        }

        public static float DistanceToClosest(int tileID, List<WorldObject> volcanos)
        {
            WorldGrid worldGrid = Find.WorldGrid;
            float distance = -1f;
            for (int i = 0; i != volcanos.Count; i++)
            {
                float distance2 = worldGrid.ApproxDistanceInTiles(tileID, volcanos[i].Tile);
                if (distance == -1 || distance > distance2) distance = distance2;
            }
            return distance;
        }
    }
}

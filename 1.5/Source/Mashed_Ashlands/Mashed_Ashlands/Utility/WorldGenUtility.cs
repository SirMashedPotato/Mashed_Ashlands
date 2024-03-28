using RimWorld.Planet;
using Verse;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace Mashed_Ashlands
{
    public static class WorldGenUtility
    {
        public static List<WorldObject> GetWorldVolcanos()
        {
            WorldObjectsHolder worldObjectsHolder = Find.WorldObjects;
            return worldObjectsHolder.AllWorldObjects.Where(x => x is Volcano).ToList();
        }
        
        public static float DistanceToClosestVolcano(int tileID)
        {
            List<WorldObject> volcanos = GetWorldVolcanos();
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
            float distance = -1f;
            for (int i = 0; i != worldObjects.Count; i++)
            {
                float distance2 = DistanceToWorldObject(tileID, worldObjects[i].Tile);
                if (distance == -1 || distance > distance2)
                {
                    distance = distance2;
                }
            }
            return distance;
        }

        public static float DistanceToWorldObject(int tileID, int objectTile)
        {
            WorldGrid worldGrid = Find.WorldGrid;
            return worldGrid.ApproxDistanceInTiles(tileID, objectTile);
        }

        public static WorldObject ClosestVolcano(int tileID)
        {
            List<WorldObject> volcanos = GetWorldVolcanos();
            if (!volcanos.NullOrEmpty())
            {
                WorldGrid worldGrid = Find.WorldGrid;
                float closestDistance = 999999f;
                WorldObject closestVolcano = null;
                foreach(WorldObject volcano in volcanos)
                {
                    float distance2 = worldGrid.ApproxDistanceInTiles(tileID, volcano.Tile);
                    if (distance2 < closestDistance)
                    {
                        closestDistance = distance2;
                        closestVolcano = volcano;
                    }
                }
                return closestVolcano;
            }
            return null;
        }

        public static int BiomeMaxDistanceForWorld()
        {
            int maxDistance = Mashed_Ashlands_ModSettings.BiomesMaxDistance;
            if (Mashed_Ashlands_ModSettings.BiomeScaleWithWorldSize)
            {
                maxDistance = (int)(maxDistance * ((Find.World.PlanetCoverage * 2) + 0.4f));
                if (maxDistance < 10)
                {
                    maxDistance = 10;
                }
            }
            return maxDistance;
        }
    }
}

using RimWorld.Planet;
using Verse;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace MorrowRim2
{
    public static class BiomeWorkerUtility
    {
        public static readonly List<BiomeDef> ashlandBiomeDefs = new List<BiomeDef>
        {
            BiomeDefOf.MorrowRim_Ashlands,
            BiomeDefOf.MorrowRim_BlightedAshlands,
            BiomeDefOf.MorrowRim_VolcanicAshlands
        };

        public static readonly List<BiomeDef> lateAshlandBiomeDefs = new List<BiomeDef>
        {
            BiomeDefOf.MorrowRim_SwampAshlands
        };

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

using Verse;
using RimWorld.Planet;
using RimWorld;

namespace MorrowRim2
{
    public abstract class WorldGenStep_Volcano : WorldGenStep
    {
        public void GenerateVolcanos(WorldObjectDef volcanoDef, float initialMaxNum)
        {
            int numGenerated = 0;
            int maxNumber = (int)initialMaxNum;
            if (MorrowRim_ModSettings.VolcanoScaleWithWorldSize)
            {
                maxNumber = (int)(initialMaxNum * ((Find.World.PlanetCoverage * 3) + 0.1f));
                if (maxNumber < 1)
                {
                    maxNumber = 1;
                }
            }
            WorldGrid grid = Find.WorldGrid;
            for (int i = 0; i < grid.TilesCount; i++)
            {
                if (numGenerated >= maxNumber)
                {
                    return;
                }
                if (grid[i].hilliness == Hilliness.Impassable)
                {
                    if (grid[i].biome != RimWorld.BiomeDefOf.IceSheet && grid[i].biome != RimWorld.BiomeDefOf.SeaIce)
                    {
                        float distanceToClosestVolcano = WorldGenUtility.DistanceToClosestVolcano(i);
                        if (distanceToClosestVolcano >= MorrowRim_ModSettings.VolcanoMinDistance)
                        {
                            WorldObject volcano = WorldObjectMaker.MakeWorldObject(volcanoDef);
                            volcano.Tile = i;
                            Find.WorldObjects.Add(volcano);
                            numGenerated++;
                        }
                    }
                }
            }
        }
    }
}

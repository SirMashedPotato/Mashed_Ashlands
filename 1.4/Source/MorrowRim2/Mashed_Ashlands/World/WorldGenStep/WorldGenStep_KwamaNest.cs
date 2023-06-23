using Verse;
using RimWorld.Planet;
using RimWorld;

namespace Mashed_Ashlands
{
    public class WorldGenStep_KwamaNest : WorldGenStep
    {
        public override int SeedPart => 1245234752;

        public override void GenerateFresh(string seed)
        {
            if (Mashed_Ashlands_ModSettings.EnableWorldKwamaNests)
            {
                GenerateKwamaNests(WorldObjectDefOf.Mashed_Ashlands_KwamaNest, Mashed_Ashlands_ModSettings.NumberOfWorldKwamaNests);
            }
        }

        public void GenerateKwamaNests(WorldObjectDef kwamaNestDef, float initialMaxNum)
        {
            int numGenerated = 0;
            int maxNumber = (int)initialMaxNum;
            if (Mashed_Ashlands_ModSettings.KwamaNestsScaleWithWorldSize)
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
                if (grid[i].hilliness == Hilliness.Impassable && !Find.WorldObjects.AnyWorldObjectAt(i))
                {
                    if (OnStartupUtility.baseAshlandBiomeDefs.Contains(grid[i].biome))
                    {
                        float distanceToClosestKwamaNest = WorldGenUtility.DistanceToClosestKwamaNest(i);
                        if (distanceToClosestKwamaNest >= Mashed_Ashlands_ModSettings.WorldKwamaNestMinDistance)
                        {
                            WorldObject volcano = WorldObjectMaker.MakeWorldObject(kwamaNestDef);
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

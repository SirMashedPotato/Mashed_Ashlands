using Verse;
using RimWorld.Planet;

namespace MorrowRim2
{
    public class WorldGenStep_VolcanoActive : WorldGenStep
    {
        public override int SeedPart => 238931215;

        //TODO settings
        public int numGenerated = 0;
        public int maxGenerated = 1;

        public override void GenerateFresh(string seed)
        {
            numGenerated = 0;
            GenerateVolcanos();
        }

        private void GenerateVolcanos()
        {
            WorldGrid grid = Find.WorldGrid;
            for (int i = 0; i < grid.TilesCount; i++)
            {
                if (numGenerated >= maxGenerated)
                {
                    return;
                }

                if (grid[i].hilliness == Hilliness.Impassable)
                {
                    float distanceToClosestVolcano = WorldGenUtility.DistanceToClosestVolcano(i);
                    if (distanceToClosestVolcano >= 20)
                    {
                        WorldObject volcano = WorldObjectMaker.MakeWorldObject(WorldObjectDefOf.MorrowRim_VolcanoActive);
                        volcano.Tile = i;
                        Find.WorldObjects.Add(volcano);
                        numGenerated++;
                    }
                }
            }
        }
    }
}

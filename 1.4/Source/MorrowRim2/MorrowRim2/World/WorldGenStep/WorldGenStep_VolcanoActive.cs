using Verse;
using RimWorld.Planet;

namespace MorrowRim2
{
    public class WorldGenStep_VolcanoActive : WorldGenStep
    {
        public override int SeedPart => 238931215;
        public int numGenerated = 0;

        public override void GenerateFresh(string seed)
        {
            if (MorrowRim_ModSettings.EnableActiveVolcano)
            {
                numGenerated = 0;
                GenerateVolcanos();
            }
        }

        private void GenerateVolcanos()
        {
            int maxNumber = MorrowRim_ModSettings.NumberOfActiveVolcano;
            WorldGrid grid = Find.WorldGrid;
            for (int i = 0; i < grid.TilesCount; i++)
            {
                if (numGenerated >= maxNumber)
                {
                    return;
                }

                if (grid[i].hilliness == Hilliness.Impassable)
                {
                    float distanceToClosestVolcano = WorldGenUtility.DistanceToClosestVolcano(i);
                    if (distanceToClosestVolcano >= MorrowRim_ModSettings.VolcanoMinDistance)
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

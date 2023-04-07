using Verse;
using RimWorld.Planet;

namespace MorrowRim2
{
    public class WorldGenStep_VolcanoExtinct : WorldGenStep
    {
        public override int SeedPart => 1249643413;
        public int numGenerated = 0;

        public override void GenerateFresh(string seed)
        {
            if (MorrowRim_ModSettings.EnableExtinctVolcano)
            {
                numGenerated = 0;
                GenerateVolcanos();
            }
        }

        private void GenerateVolcanos()
        {
            int maxNumber = MorrowRim_ModSettings.NumberOfExtinctVolcano;
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
                        WorldObject volcano = WorldObjectMaker.MakeWorldObject(WorldObjectDefOf.MorrowRim_VolcanoExtinct);
                        volcano.Tile = i;
                        Find.WorldObjects.Add(volcano);
                        numGenerated++;
                    }
                }
            }
        }
    }
}

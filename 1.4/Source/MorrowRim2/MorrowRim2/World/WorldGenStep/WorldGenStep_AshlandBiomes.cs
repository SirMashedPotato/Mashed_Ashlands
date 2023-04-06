using Verse;
using RimWorld;
using RimWorld.Planet;

namespace MorrowRim2
{
    public class WorldGenStep_AshlandBiomes : WorldGenStep
    {
        public override int SeedPart => 48151623;

        public override void GenerateFresh(string seed)
        {
            WorldGrid grid = Find.WorldGrid;
            for (int i = 0; i < grid.TilesCount; i++)
            {
                if (!grid[i].WaterCovered)
                {
                    grid[i].biome = AshlandBiomeFrom(grid[i], i);
                }
            }
        }

        private BiomeDef AshlandBiomeFrom(Tile tile, int tileID)
        {
            BiomeDef biomeDef = null;
            float num = 0f;
            foreach(BiomeDef biomeDef2 in BiomeWorkerUtility.ashlandBiomeDefs)
            {
                if (biomeDef2.implemented && biomeDef2.Worker is AshlandBiomeWorker)
                {
                    AshlandBiomeWorker biomeWorker = biomeDef2.Worker as AshlandBiomeWorker;
                    float score = biomeWorker.GetScore_Main(tile, tileID);
                    if (score > num || biomeDef == null)
                    {
                        biomeDef = biomeDef2;
                        num = score;
                    }
                }
            }
            if (num < 15)
            {
                biomeDef = tile.biome;
            }
            return biomeDef;
        }
    }
}

using Verse;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class WorldGenStep_AshlandBiomesLate : WorldGenStep_AshlandBiomes
    {
        public override int SeedPart => 48151623;

        public static void DebugGenerate(string seed)
        {
            WorldGenStep_AshlandBiomesLate instance = new WorldGenStep_AshlandBiomesLate();
            instance.GenerateFresh(seed);
        }

        public override void GenerateFresh(string seed)
        {
            WorldGrid grid = Find.WorldGrid;
            for (int i = 0; i < grid.TilesCount; i++)
            {
                if (!grid[i].WaterCovered && OnStartupUtility.baseAshlandBiomeDefs.Contains(grid[i].biome))
                {
                    grid[i].biome = AshlandBiomeFrom(grid[i], i, OnStartupUtility.lateAshlandBiomeDefs);
                }
            }
        }
    }
}

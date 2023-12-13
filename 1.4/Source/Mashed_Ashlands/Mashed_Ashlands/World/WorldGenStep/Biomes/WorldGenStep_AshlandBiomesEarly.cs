using Verse;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class WorldGenStep_AshlandBiomesEarly : WorldGenStep_AshlandBiomes
    {
        public override int SeedPart => 48151623;

        public override void GenerateFresh(string seed)
        {
            WorldGrid grid = Find.WorldGrid;
            for (int i = 0; i < grid.TilesCount; i++)
            {
                if (PreventAshlandOverride.Get(grid[i].biome) == null)
                {
                    grid[i].biome = AshlandBiomeFrom(grid[i], i, OnStartupUtility.earlyAshlandBiomeDefs);
                }
            }
        }
    }
}

using Verse;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class WorldGenStep_AshlandBiomesLate : WorldGenStep_AshlandBiomes
    {
        public override int SeedPart => 48151623;

        public static void DebugGenerate(string seed, PlanetLayer layer)
        {
            WorldGenStep_AshlandBiomesLate instance = new WorldGenStep_AshlandBiomesLate();
            instance.GenerateFresh(seed, layer);
        }

        public override void GenerateFresh(string seed, PlanetLayer layer)
        {
            for (int i = 0; i < layer.TilesCount; i++)
            {
                if (!layer[i].WaterCovered && OnStartupUtility.baseAshlandBiomeDefs.Contains(layer[i].PrimaryBiome))
                {
                    layer[i].PrimaryBiome = AshlandBiomeFrom(layer[i], i, layer, OnStartupUtility.lateAshlandBiomeDefs);
                }
            }
        }
    }
}

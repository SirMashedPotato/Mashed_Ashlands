using Verse;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public abstract class WorldGenStep_AshlandBiomes : WorldGenStep
    {
        public BiomeDef AshlandBiomeFrom(Tile tile, int tileID, List<BiomeDef> biomeDefs)
        {
            BiomeDef biomeDef = null;
            float num = 0f;
            foreach (BiomeDef biomeDef2 in biomeDefs)
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

            BiomeProperties props = BiomeProperties.Get(biomeDef);
            if (props != null)
            {
                if (props.forceHilliness)
                {
                    ///Necessary for rock walls to generate
                    tile.elevation = Rand.Range(1, 10);
                    tile.hilliness = Rand.Chance(0.75f) ? Hilliness.SmallHills : Rand.Chance(0.75f) ? Hilliness.Flat : Hilliness.LargeHills;
                }
            }

            return biomeDef;
        }
    }
}

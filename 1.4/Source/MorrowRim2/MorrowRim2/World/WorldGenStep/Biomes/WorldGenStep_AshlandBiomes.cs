using Verse;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;

namespace MorrowRim2
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
            return biomeDef;
        }
    }
}

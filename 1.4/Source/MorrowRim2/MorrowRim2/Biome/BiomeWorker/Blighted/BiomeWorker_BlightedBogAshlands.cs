using RimWorld.Planet;
using Verse;
using Verse.Noise;

namespace MorrowRim2
{
    public class BiomeWorker_BlightedBogAshlands : AshlandBiomeWorker
    {
        /// <summary>
        /// Only here to prevent gen through standard methods
        /// Possibly add in alternative gen, with setting to disable volcano based gen
        /// </summary>
        public override float GetScore(Tile tile, int tileID)
        {
            if (MorrowRim_ModSettings.OldBiomeGen)
            {

            }

            return 0;
        }

        public int perlinSeed = 35;
        public float perlinCulling = 0.5f;

        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!MorrowRim_ModSettings.EnableBlightedBogAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.MorrowRim_BlightedAshlands)
            {
                return -100f;
            }
            if (tile.hilliness == Hilliness.Mountainous || tile.hilliness == Hilliness.Impassable)
            {
                return 0f;
            }

            Perlin perlin = new Perlin(0.1, 10, 0.6, 12, perlinSeed, QualityMode.Low);
            float perlinValue = perlin.GetValue(Find.WorldGrid.GetTileCenter(tileID));

            if (perlinValue <= perlinCulling)
            {
                return 0f;
            }

            return 16;
        }
    }
}

using RimWorld.Planet;
using Verse;

namespace MorrowRim2
{
    public class BiomeWorker_BlightedAshlands : AshlandBiomeWorker
    {
        /// <summary>
        /// Only here to prevent gen through standard methods
        /// Possibly add in alternative gen, with setting to disable volcano based gen
        /// </summary>
        public override float GetScore(Tile tile, int tileID)
        {
            return 0;
        }

        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (tile.WaterCovered)
            {
                return -100f;
            }
            float distanceToClosestVolcano = BiomeWorkerUtility.DistanceToClosestVolcano(tileID, WorldObjectDefOf.MorrowRim_VolcanoBlighted);
            if (distanceToClosestVolcano > 50 || distanceToClosestVolcano == -1)
            {
                return 0;
            }
            return Rand.Range(200, 400) / distanceToClosestVolcano;
        }
    }
}

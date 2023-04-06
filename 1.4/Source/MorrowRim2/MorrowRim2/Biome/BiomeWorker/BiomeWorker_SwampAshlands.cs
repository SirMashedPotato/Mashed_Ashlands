using RimWorld.Planet;
using Verse;

namespace MorrowRim2
{
    public class BiomeWorker_SwampAshlands : AshlandBiomeWorker
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

        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!MorrowRim_ModSettings.EnableSwampAshlands)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            if (tile.swampiness < 0.5f && tile.rainfall < 2500f)
            {
                return 0f;
            }
            float distanceToClosestVolcano = BiomeWorkerUtility.DistanceToClosestVolcano(tileID, WorldObjectDefOf.MorrowRim_VolcanoDormant);
            if (distanceToClosestVolcano > MorrowRim_ModSettings.BiomesMaxDistance || distanceToClosestVolcano == -1)
            {
                return 0;
            }
            return Rand.Range(10, 16) * (MorrowRim_ModSettings.BiomesMaxDistance / 2) / distanceToClosestVolcano;
        }
    }
}

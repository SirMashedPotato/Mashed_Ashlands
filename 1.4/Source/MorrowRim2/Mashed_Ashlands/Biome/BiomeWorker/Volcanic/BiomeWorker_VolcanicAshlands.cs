using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_VolcanicAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!Mashed_Ashlands_ModSettings.EnableVolcanicAshlands)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            return BaseBiomeWorker(tileID, WorldObjectDefOf.Mashed_Ashlands_VolcanoActive);
        }
    }
}

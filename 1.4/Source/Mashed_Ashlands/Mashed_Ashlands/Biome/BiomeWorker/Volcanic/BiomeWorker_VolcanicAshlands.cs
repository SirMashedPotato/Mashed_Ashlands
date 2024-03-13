using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class BiomeWorker_VolcanicAshlands : AshlandBiomeWorker
    {
        public override float GetScore_Main(Tile tile, int tileID, WorldObject sourceObject)
        {
            if (!Mashed_Ashlands_ModSettings.EnableVolcanicAshlands)
            {
                return -100f;
            }
            if (tile.WaterCovered)
            {
                return -100f;
            }
            if (sourceObject.def != WorldObjectDefOf.Mashed_Ashlands_VolcanoActive)
            {
                return -100f;
            }
            return BaseBiomeWorker(tileID, sourceObject, BiomeDefOf.Mashed_Ashlands_VolcanicAshlands);
        }
    }
}

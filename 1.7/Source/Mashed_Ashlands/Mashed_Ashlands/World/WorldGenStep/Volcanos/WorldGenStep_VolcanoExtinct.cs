using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class WorldGenStep_VolcanoExtinct : WorldGenStep_Volcano
    {
        public override int SeedPart => 1249643413;

        public static void DebugGenerate(string seed, PlanetLayer layer)
        {
            WorldGenStep_VolcanoExtinct instance = new WorldGenStep_VolcanoExtinct();
            instance.GenerateFresh(seed, layer);
        }

        public override void GenerateFresh(string seed, PlanetLayer layer)
        {
            if (Mashed_Ashlands_ModSettings.EnableExtinctVolcano)
            {
                GenerateVolcanos(layer, WorldObjectDefOf.Mashed_Ashlands_VolcanoExtinct, Mashed_Ashlands_ModSettings.NumberOfExtinctVolcano);
            }
        }
    }
}

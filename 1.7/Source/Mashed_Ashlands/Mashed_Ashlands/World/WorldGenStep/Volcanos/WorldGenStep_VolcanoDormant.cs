using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class WorldGenStep_VolcanoDormant : WorldGenStep_Volcano
    {
        public override int SeedPart => 481516233;

        public static void DebugGenerate(string seed, PlanetLayer layer)
        {
            WorldGenStep_VolcanoDormant instance = new WorldGenStep_VolcanoDormant();
            instance.GenerateFresh(seed, layer);
        }

        public override void GenerateFresh(string seed, PlanetLayer layer)
        {
            if (Mashed_Ashlands_ModSettings.EnableDormantVolcano)
            {
                GenerateVolcanos(layer, WorldObjectDefOf.Mashed_Ashlands_VolcanoDormant, Mashed_Ashlands_ModSettings.NumberOfDormantVolcano);
            }
        }
    }
}

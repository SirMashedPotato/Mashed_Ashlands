using RimWorld.Planet;
using Verse;

namespace Mashed_Ashlands
{
    public class WorldGenStep_VolcanoActive : WorldGenStep_Volcano
    {
        public override int SeedPart => 238931215;

        public static void DebugGenerate(string seed, PlanetLayer layer)
        {
            WorldGenStep_VolcanoActive instance = new WorldGenStep_VolcanoActive();
            instance.GenerateFresh(seed, layer);
        }

        public override void GenerateFresh(string seed, PlanetLayer layer)
        {
            if (Mashed_Ashlands_ModSettings.EnableActiveVolcano)
            {
                GenerateVolcanos(layer, WorldObjectDefOf.Mashed_Ashlands_VolcanoActive, Mashed_Ashlands_ModSettings.NumberOfActiveVolcano);
            }
        }
    }
}

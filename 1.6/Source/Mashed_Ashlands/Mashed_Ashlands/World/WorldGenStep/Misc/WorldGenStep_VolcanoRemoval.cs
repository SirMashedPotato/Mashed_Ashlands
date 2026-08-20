using RimWorld.Planet;
using Verse;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class WorldGenStep_VolcanoRemoval : WorldGenStep
    {
        public override int SeedPart => 0;

        public override void GenerateFresh(string seed, PlanetLayer layer)
        {
            if (Mashed_Ashlands_ModSettings.EnableVolcanoRemoval)
            {
                List<WorldObject> volcanos = WorldGenUtility.GetWorldVolcanosForLayer(layer);
                foreach (WorldObject volcano in volcanos)
                {
                    volcano.Destroy();
                }
            }
        }
    }
}

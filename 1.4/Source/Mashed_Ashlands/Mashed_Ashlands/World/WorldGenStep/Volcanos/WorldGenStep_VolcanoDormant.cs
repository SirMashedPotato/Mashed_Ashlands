namespace Mashed_Ashlands
{
    public class WorldGenStep_VolcanoDormant : WorldGenStep_Volcano
    {
        public override int SeedPart => 481516233;

        public override void GenerateFresh(string seed)
        {
            if (Mashed_Ashlands_ModSettings.EnableDormantVolcano)
            {
                GenerateVolcanos(WorldObjectDefOf.Mashed_Ashlands_VolcanoDormant, Mashed_Ashlands_ModSettings.NumberOfDormantVolcano);
            }
        }
    }
}

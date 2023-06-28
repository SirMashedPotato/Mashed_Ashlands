namespace Mashed_Ashlands
{
    public class WorldGenStep_VolcanoBlighted : WorldGenStep_Volcano
    {
        public override int SeedPart => 1249643413;

        public override void GenerateFresh(string seed)
        {
            if (Mashed_Ashlands_ModSettings.EnableBlightedVolcano)
            {
                GenerateVolcanos(WorldObjectDefOf.Mashed_Ashlands_VolcanoBlighted, Mashed_Ashlands_ModSettings.NumberOfBlightedVolcano);
            }
        }
    }
}

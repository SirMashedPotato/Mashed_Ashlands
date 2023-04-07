namespace MorrowRim2
{
    public class WorldGenStep_VolcanoBlighted : WorldGenStep_Volcano
    {
        public override int SeedPart => 1249643413;

        public override void GenerateFresh(string seed)
        {
            if (MorrowRim_ModSettings.EnableBlightedVolcano)
            {
                GenerateVolcanos(WorldObjectDefOf.MorrowRim_VolcanoBlighted, MorrowRim_ModSettings.NumberOfBlightedVolcano);
            }
        }
    }
}

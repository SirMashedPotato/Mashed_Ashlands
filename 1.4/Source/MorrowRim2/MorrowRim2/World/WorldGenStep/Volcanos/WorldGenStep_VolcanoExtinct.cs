namespace MorrowRim2
{
    public class WorldGenStep_VolcanoExtinct : WorldGenStep_Volcano
    {
        public override int SeedPart => 1249643413;

        public override void GenerateFresh(string seed)
        {
            if (MorrowRim_ModSettings.EnableExtinctVolcano)
            {
                GenerateVolcanos(WorldObjectDefOf.MorrowRim_VolcanoExtinct, MorrowRim_ModSettings.NumberOfExtinctVolcano);
            }
        }
    }
}

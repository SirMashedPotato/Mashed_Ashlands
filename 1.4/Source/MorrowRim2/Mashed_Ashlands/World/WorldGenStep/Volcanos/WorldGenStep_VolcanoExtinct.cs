namespace Mashed_Ashlands
{
    public class WorldGenStep_VolcanoExtinct : WorldGenStep_Volcano
    {
        public override int SeedPart => 1249643413;

        public override void GenerateFresh(string seed)
        {
            if (Mashed_Ashlands_ModSettings.EnableExtinctVolcano)
            {
                GenerateVolcanos(WorldObjectDefOf.MorrowRim_VolcanoExtinct, Mashed_Ashlands_ModSettings.NumberOfExtinctVolcano);
            }
        }
    }
}

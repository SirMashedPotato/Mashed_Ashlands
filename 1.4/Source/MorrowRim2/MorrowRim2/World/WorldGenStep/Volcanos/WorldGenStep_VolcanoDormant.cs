namespace MorrowRim2
{
    public class WorldGenStep_VolcanoDormant : WorldGenStep_Volcano
    {
        public override int SeedPart => 481516233;

        public override void GenerateFresh(string seed)
        {
            if (MorrowRim_ModSettings.EnableDormantVolcano)
            {
                GenerateVolcanos(WorldObjectDefOf.MorrowRim_VolcanoDormant, MorrowRim_ModSettings.NumberOfDormantVolcano);
            }
        }
    }
}

namespace MorrowRim2
{
    public class WorldGenStep_VolcanoActive : WorldGenStep_Volcano
    {
        public override int SeedPart => 238931215;

        public override void GenerateFresh(string seed)
        {
            if (MorrowRim_ModSettings.EnableActiveVolcano)
            {
                GenerateVolcanos(WorldObjectDefOf.MorrowRim_VolcanoActive, MorrowRim_ModSettings.NumberOfActiveVolcano);
            }
        }
    }
}

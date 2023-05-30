namespace Mashed_Ashlands
{
    public class WorldGenStep_VolcanoActive : WorldGenStep_Volcano
    {
        public override int SeedPart => 238931215;

        public override void GenerateFresh(string seed)
        {
            if (Mashed_Ashlands_ModSettings.EnableActiveVolcano)
            {
                GenerateVolcanos(WorldObjectDefOf.MorrowRim_VolcanoActive, Mashed_Ashlands_ModSettings.NumberOfActiveVolcano);
            }
        }
    }
}

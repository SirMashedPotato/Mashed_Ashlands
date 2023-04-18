using Verse;

namespace MorrowRim2
{
    public class AnimalProperties : DefModExtension
    {
        public bool requireRiver = false;
        public bool requireCoast = false;
        public bool requireCaves = false;
        public bool requireHills = false;

        public static AnimalProperties Get(Def def)
        {
            return def.GetModExtension<AnimalProperties>();
        }
    }
}

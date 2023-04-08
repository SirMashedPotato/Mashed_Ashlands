using Verse;

namespace MorrowRim2
{
    public class RaceProperties : DefModExtension
    {

        public static RaceProperties Get(Def def)
        {
            return def.GetModExtension<RaceProperties>();
        }
    }
}

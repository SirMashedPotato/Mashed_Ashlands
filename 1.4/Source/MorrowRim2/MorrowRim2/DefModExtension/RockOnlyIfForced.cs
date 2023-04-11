using Verse;

namespace MorrowRim2
{
    public class RockOnlyIfForced : DefModExtension
    {
        public static RockOnlyIfForced Get(Def def)
        {
            return def.GetModExtension<RockOnlyIfForced>();
        }
    }
}

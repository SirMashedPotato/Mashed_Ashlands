using Verse;

namespace MorrowRim2
{
    public class RockProperties : DefModExtension
    {
        public bool onlyAllowIfForced = false;

        public static RockProperties Get(Def def)
        {
            return def.GetModExtension<RockProperties>();
        }
    }
}

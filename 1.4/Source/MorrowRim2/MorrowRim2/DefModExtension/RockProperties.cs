using Verse;

namespace MorrowRim2
{
    public class RockProperties : DefModExtension
    {
        public bool onlyAllowIfForced = false;
        public string roughTexPathReplacer;
        public string roughHewnTexPathReplacer;
        public string smoothTexPathReplacer;
        public string scatterTypeReplacer = null;
        public bool applyToPolluted = false;

        public static RockProperties Get(Def def)
        {
            return def.GetModExtension<RockProperties>();
        }
    }
}

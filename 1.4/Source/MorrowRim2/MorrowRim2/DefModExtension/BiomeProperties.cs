using Verse;

namespace MorrowRim2
{
    public class BiomeProperties : DefModExtension
    {
        public bool earlyLoader = false;
        public bool lateLoader = false;
        public bool baseBiome = false;

        public static BiomeProperties Get(Def def)
        {
            return def.GetModExtension<BiomeProperties>();
        }
    }
}

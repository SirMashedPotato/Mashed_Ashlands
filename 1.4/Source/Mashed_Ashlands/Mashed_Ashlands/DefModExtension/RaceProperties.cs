using Verse;

namespace Mashed_Ashlands
{
    public class RaceProperties : DefModExtension
    {

        public static RaceProperties Get(Def def)
        {
            return def.GetModExtension<RaceProperties>();
        }
    }
}

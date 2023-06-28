using Verse;

namespace Mashed_Ashlands
{
    public class PollutionProperties : DefModExtension
    {
        public bool AllowPollutionStimulis = false;
        public HediffDef alternativePollutionStimulis = null;

        public static PollutionProperties Get(Def def)
        {
            return def.GetModExtension<PollutionProperties>();
        }
    }
}

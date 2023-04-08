using Verse;

namespace MorrowRim2
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

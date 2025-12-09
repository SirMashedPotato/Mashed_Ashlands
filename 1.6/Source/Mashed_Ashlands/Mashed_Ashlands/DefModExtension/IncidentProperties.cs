using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class IncidentProperties : DefModExtension
    {
        public TraderKindDef traderKindDef;

        public static IncidentProperties Get(Def def) => def.GetModExtension<IncidentProperties>();
    }
}
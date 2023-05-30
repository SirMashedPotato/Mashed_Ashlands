using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class Alert_AshBuildup : Alert
    {
        public Alert_AshBuildup()
        {
            defaultLabel = "MorrowRim_AlertAshBuildup".Translate();
            defaultPriority = AlertPriority.High;
        }

        private List<Pawn> AshBuildupColonists
        {
            get
            {
                ashBuildupColonists.Clear();
                foreach (Pawn pawn in PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoSuspended)
                {
                    Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_AshBuildup, false);
                    if (firstHediffOfDef != null && firstHediffOfDef.Severity >= ashBuildupSeverityThreshold)
                    {
                        ashBuildupColonists.Add(pawn);
                    }
                }
                return ashBuildupColonists;
            }
        }

        public override TaggedString GetExplanation()
        {
            string value = (from p in AshBuildupColonists
                            select p.NameShortColored.Resolve()).ToLineList(" - ", false);
            return "MorrowRim_AlertAshBuildupDesc".Translate(value);
        }

        public override AlertReport GetReport()
        {
            return AlertReport.CulpritsAre(AshBuildupColonists);
        }

        private const float ashBuildupSeverityThreshold = 0.6f; //TODO Potential setting
        private List<Pawn> ashBuildupColonists = new List<Pawn>();
    }
}

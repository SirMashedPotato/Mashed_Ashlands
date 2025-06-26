using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class IncidentWorker_BlightedAnimalEnters : IncidentWorker_AshlandsSpecific
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return base.CanFireNowSub(parms) && Mashed_Ashlands_ModSettings.AshBlightWandersIn;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            if (!TryFindEntryCell(map, out IntVec3 intVec))
            {
                return false;
            }
            Pawn pawn = null;

            List<PawnKindDef> kinds = new List<PawnKindDef> {PawnKindDefOf.Mashed_Ashlands_Alit, PawnKindDefOf.Mashed_Ashlands_Kagouti, PawnKindDefOf.Mashed_Ashlands_Netch};
            IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
            pawn = PawnGenerator.GeneratePawn(kinds.RandomElement(), null);
            pawn.gender = Gender.Male;
            pawn.ageTracker.AgeBiologicalTicks = pawn.ageTracker.AdultMinAgeTicks;
            pawn.health.AddHediff(HediffDefOf.Mashed_Ashlands_AshBlight);
            GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);

            SendStandardLetter(def.letterLabel.Formatted(pawn), def.letterText.Formatted(pawn), def.letterDef, parms, pawn);
            return true;
        }
    }
}

using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class IncidentWorker_BlightedCaravanAmbush : IncidentWorker_Ambush
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return false;
        }

        protected override List<Pawn> GeneratePawns(IncidentParms parms)
        {
            
            return AggressiveAnimalIncidentUtility.GenerateAnimals(Utility.BlightedKindDefs().RandomElement(), parms.target.Tile, 666, 1);
        }

        protected override void PostProcessGeneratedPawnsAfterSpawning(List<Pawn> generatedPawns)
        {
            for (int i = 0; i < generatedPawns.Count; i++)
            {
                generatedPawns[i].health.AddHediff(HediffDefOf.Mashed_Ashlands_AshBlight);
                generatedPawns[i].mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Mashed_Ashlands_BlightedPermanent);
            }
        }

        protected override string GetLetterLabel(Pawn anyPawn, IncidentParms parms)
        {
            return def.letterLabel.Formatted(anyPawn.Label).CapitalizeFirst();
        }

        protected override string GetLetterText(Pawn anyPawn, IncidentParms parms)
        {
            return def.letterText.Formatted((parms.target is Caravan caravan) ? caravan.Name : "yourCaravan".TranslateSimple(), anyPawn.Label).CapitalizeFirst();
        }
    }
}

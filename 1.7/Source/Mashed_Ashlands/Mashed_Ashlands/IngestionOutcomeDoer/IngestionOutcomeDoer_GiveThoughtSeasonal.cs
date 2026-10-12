using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class IngestionOutcomeDoer_GiveThoughtSeasonal : IngestionOutcomeDoer
    {
        public ThoughtDef thoughtDef;
        public Quadrum quadrum = Quadrum.Undefined;

        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            if (pawn.needs?.mood == null)
            {
                return;
            }

            if (GenDate.Quadrum(Find.TickManager.TicksAbs, Find.WorldGrid.LongLatOf(pawn.Tile).x) != quadrum)
            {
                return;
            }

            Thought_Memory thought_Memory = ThoughtMaker.MakeThought(thoughtDef, 0);
            pawn.needs.mood.thoughts.memories.TryGainMemory(thought_Memory);
        }
    }
}

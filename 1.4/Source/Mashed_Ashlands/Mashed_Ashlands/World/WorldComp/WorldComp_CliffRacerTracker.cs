using Verse;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class WorldComp_CliffRacerTracker : WorldComponent
    {
        public WorldComp_CliffRacerTracker(World world) : base(world)
        {
            if (wildPopulation == -1)
            { 
                wildPopulation = Mashed_Ashlands_ModSettings.CliffRacerWildPopulation;
            }
        }

        public int WildPopulation => wildPopulation;
        public bool Extinct => extinct;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref wildPopulation, "CliffRacer_WildPopulation", 0);
            Scribe_Values.Look(ref extinct, "CliffRacerExtinct");
            base.ExposeData();
        }

        public void ModifyProgress(int change, Thing source = null)
        {
            if (change < 0)
            {
                ///Don't want it going negative
                if (wildPopulation > 0)
                {
                    wildPopulation += change;
                    IncrementDeaths(source);
                }
            } 
            else
            {
                wildPopulation += change;
                IncrementAlive(source);
            }
        }

        private void IncrementDeaths(Thing source = null)
        {
            if (!extinct && ExtinctionCheck())
            {
                extinct = true;
                Find.LetterStack.ReceiveLetter("Mashed_Ashlands_CliffRacerExtinction_Label".Translate(), "Mashed_Ashlands_CliffRacerExtinction_Description".Translate(), RimWorld.LetterDefOf.PositiveEvent, source);
            }
        }

        private void IncrementAlive(Thing source = null)
        {
            if (extinct && ReturnCheck())
            {
                wildPopulation += (int)(wildPopulation * Rand.Range(0.5f, 2f));
                extinct = false;
                Find.LetterStack.ReceiveLetter("Mashed_Ashlands_CliffRacerReturn_Label".Translate(), "Mashed_Ashlands_CliffRacerReturn_Description".Translate(), RimWorld.LetterDefOf.NegativeEvent, source);
            }
        }

        public bool ExtinctionCheck()
        {
            return wildPopulation <= 0;
        }

        public bool ReturnCheck()
        {
            return Mashed_Ashlands_ModSettings.CliffRacerEnableReturn && wildPopulation >= Mashed_Ashlands_ModSettings.CliffRacerEnableReturnThreshold;
        }

        private bool extinct = false;
        private int wildPopulation = -1;
    }
}

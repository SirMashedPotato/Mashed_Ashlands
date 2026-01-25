using Verse;
using RimWorld.Planet;
using System.Text;
using RimWorld;

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

        public int WildPopulation
        {
            get
            {
                return wildPopulation;
            }
            set
            {
                wildPopulation = value;
            }
        }

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
                StringBuilder description = new StringBuilder();
                description.Append("Mashed_Ashlands_CliffRacerExtinction_Description".Translate());
                ModifyFactionGoodwill(ref description, 30, HistoryEventDefOf.Mashed_Ashlands_CliffRacerExtinction);
                Find.LetterStack.ReceiveLetter("Mashed_Ashlands_CliffRacerExtinction_Label".Translate(), description.ToString(), RimWorld.LetterDefOf.PositiveEvent, source);
            }
        }

        private void IncrementAlive(Thing source = null)
        {
            if (extinct && ReturnCheck())
            {
                wildPopulation += (int)(wildPopulation * Rand.Range(0.5f, 3f));
                extinct = false;
                StringBuilder description = new StringBuilder();
                description.Append("Mashed_Ashlands_CliffRacerReturn_Description".Translate());
                ModifyFactionGoodwill(ref description, -30, HistoryEventDefOf.Mashed_Ashlands_CliffRacerReturn);
                Find.LetterStack.ReceiveLetter("Mashed_Ashlands_CliffRacerReturn_Label".Translate(), description.ToString(), RimWorld.LetterDefOf.NegativeEvent, source);
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

        private void ModifyFactionGoodwill(ref StringBuilder description, int goodwillChange, HistoryEventDef eventDef)
        {
            description.AppendLine();
            foreach (Faction faction in Find.FactionManager.AllFactions)
            {
                if (!faction.Hidden && !faction.IsPlayer && !faction.def.permanentEnemy)
                {
                    if (ModsConfig.IdeologyActive)
                    {
                        if (faction.ideos != null && !faction.ideos.PrimaryIdeo.VeneratedAnimals.NullOrEmpty())
                        {
                            if (faction.ideos.PrimaryIdeo.VeneratedAnimals.Contains(ThingDefOf.Mashed_Ashlands_CliffRacer))
                            {
                                ModifyGoodWill(faction, ref description, goodwillChange * -1, eventDef);
                                continue;
                            }
                        }
                    }
                    ModifyGoodWill(faction, ref description, goodwillChange, eventDef);
                }
            }
        }

        private void ModifyGoodWill(Faction faction, ref StringBuilder description, int goodwillChange, HistoryEventDef eventDef)
        {
            FactionRelationKind playerRelationKind = faction.PlayerRelationKind;
            Faction.OfPlayer.TryAffectGoodwillWith(faction, goodwillChange, canSendMessage: false, canSendHostilityLetter: false, eventDef);
            description.AppendLine();
            description.AppendLine();
            description.Append("RelationsWith".Translate(faction.Name) + ": " + goodwillChange.ToStringWithSign());
            faction.TryAppendRelationKindChangedInfo(description, playerRelationKind, faction.PlayerRelationKind);
        }

        private bool extinct = false;
        private int wildPopulation = -1;
    }
}

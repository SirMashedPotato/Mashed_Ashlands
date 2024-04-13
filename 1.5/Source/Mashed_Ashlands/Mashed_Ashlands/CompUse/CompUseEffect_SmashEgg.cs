using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;
using Verse.Sound;
using static System.Net.Mime.MediaTypeNames;

namespace Mashed_Ashlands
{
    public class CompUseEffect_SmashEgg : CompUseEffect
    {
        public CompProperties_UseEffectSmashEgg Props => (CompProperties_UseEffectSmashEgg)props;

        public override void DoEffect(Pawn usedBy)
        {
            ///Don't call base.DoEffect or it will error
            Props.soundDef?.PlayOneShot(new TargetInfo(usedBy.Position, usedBy.Map, false));
            FilthMaker.TryMakeFilth(parent.Position, parent.Map, RimWorld.ThingDefOf.Filth_AmnioticFluid, parent.stackCount);
            TryManhunterAnimals(usedBy);
            parent.Destroy();
        }

        /// <summary>
        /// So something is broken and I have no idea why
        /// I can add the scampuss bell use comp onto this egg, and it works fine
        /// But this comp? Oh no that won't work
        /// Except it does when I just don't run base.PrepareTick
        /// </summary>
        public override void PrepareTick()
        {
        }

        public override AcceptanceReport CanBeUsedBy(Pawn p)
        {
            CompHatcher compHatcher = parent.TryGetComp<CompHatcher>();
            if (compHatcher == null)
            {
                return "Missing compHatcher";
            }
            if (compHatcher.hatcheeFaction != null)
            {
                return "Mashed_Ashlands_EggNotWild".Translate(parent.Label);
            }
            if (p.Faction == null || p.Faction != Faction.OfPlayer)
            {
                return "Mashed_Ashlands_NotPlayerFaction".Translate(p);
            }
            if (p.WorkTagIsDisabled(WorkTags.Violent) || p.WorkTagIsDisabled(WorkTags.Hunting))
            {
                return "Mashed_Ashlands_PawnRefusesSmashEgg".Translate(p);
            }
            return true;
        }

        public void TryManhunterAnimals(Pawn usedBy)
        {
            List<Thing> nearbyPawns = GenRadial.RadialDistinctThingsAround(parent.Position, parent.Map, Props.baseManhunterRadius + parent.stackCount, true).Where(x => x is Pawn p && p.kindDef == Props.manhunterKind && p.Faction == null).ToList();
            if (nearbyPawns.NullOrEmpty())
            {
                return;
            }
            List<Pawn> manhunteredPawns = new List<Pawn>();
            foreach (Pawn pawn in nearbyPawns.Cast<Pawn>())
            {
                if(pawn.mindState.mentalStateHandler.TryStartMentalState(stateDef: MentalStateDefOf.Manhunter, forced: true, forceWake: true))
                {
                    manhunteredPawns.Add(pawn);
                }
            }
            if (!manhunteredPawns.NullOrEmpty())
            {
                Find.LetterStack.ReceiveLetter("Mashed_Ashlands_EggSmashRevenge_Label".Translate(Props.manhunterKind.label), 
                    "Mashed_Ashlands_EggSmashRevenge_Description".Translate(Props.manhunterKind.label, usedBy, parent.Label),
                    (manhunteredPawns.Count == 1) ? RimWorld.LetterDefOf.ThreatSmall : RimWorld.LetterDefOf.ThreatBig, manhunteredPawns);
            }
        }
    }
}

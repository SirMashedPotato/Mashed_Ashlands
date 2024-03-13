using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class CompUseEffect_ImprintEgg : CompUseEffect
    {
        private CompProperties_UseEffectImprintEgg Props => (CompProperties_UseEffectImprintEgg)props;

        public override void DoEffect(Pawn usedBy)
        {
            CompHatcher compHatcher = parent.TryGetComp<CompHatcher>();
            if (compHatcher != null)
            {
                compHatcher.hatcheeFaction = usedBy.Faction;
                Messages.Message("Mashed_Ashlands_EggImprinted".Translate(parent.Label, compHatcher.Props.hatcherPawn.label), MessageTypeDefOf.NeutralEvent, false);
            }
        }

        public override AcceptanceReport CanBeUsedBy(Pawn p)
        {
            CompHatcher compHatcher = parent.TryGetComp<CompHatcher>();
            if (compHatcher == null)
            {
                return "Missing compHatcher";
            }
            if (compHatcher.hatcheeFaction == Faction.OfPlayer)
            {
                return "Mashed_Ashlands_EggAlreadyImprinted".Translate(parent.Label);
            }
            if (p.Faction == null || p.Faction != Faction.OfPlayer)
            {
                return "Mashed_Ashlands_NotPlayerFaction".Translate(p);
            }
            if (p.skills.GetSkill(SkillDefOf.Animals).TotallyDisabled)
            {   
                return "Mashed_Ashlands_AnimalsIncapable".Translate(p);
            }
            if (p.skills.GetSkill(SkillDefOf.Animals).Level < Props.minAnimals)
            {
                return "Mashed_Ashlands_AnimalsTooLow".Translate(parent.Label, Props.minAnimals);
            }
            return true;
        }
    }
}

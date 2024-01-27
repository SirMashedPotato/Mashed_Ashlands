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

        public override bool CanBeUsedBy(Pawn p, out string failReason)
        {
            CompHatcher compHatcher = parent.TryGetComp<CompHatcher>();
            if (compHatcher == null)
            {
                failReason = "Missing compHatcher";
                return false;
            }
            if (compHatcher.hatcheeFaction == Faction.OfPlayer)
            {
                failReason = "Mashed_Ashlands_EggAlreadyImprinted".Translate(parent.Label);
                return false;
            }
            if (p.Faction == null || p.Faction != Faction.OfPlayer)
            {
                failReason = "Mashed_Ashlands_NotPlayerFaction".Translate(p);
                return false;
            }
            if (p.skills.GetSkill(SkillDefOf.Animals).TotallyDisabled)
            {
                failReason = "Mashed_Ashlands_AnimalsIncapable".Translate(p);
                return false;
            }
            if (p.skills.GetSkill(SkillDefOf.Animals).Level < Props.minAnimals)
            {
                failReason = "Mashed_Ashlands_AnimalsTooLow".Translate(parent.Label, Props.minAnimals);
                return false;
            }
            return base.CanBeUsedBy(p, out failReason);
        }
    }
}

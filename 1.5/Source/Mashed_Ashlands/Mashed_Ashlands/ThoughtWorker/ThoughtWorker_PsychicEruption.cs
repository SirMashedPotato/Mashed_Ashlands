using Verse;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;

namespace Mashed_Ashlands
{
    public class ThoughtWorker_PsychicEruption : ThoughtWorker
    {
        public List<WorldObject> ValidVolcanos
        {
            get
            {
                if (validVolcanos.NullOrEmpty())
                {
                    validVolcanos = WorldGenUtility.GetWorldVolcanos().Where(x => x.def != WorldObjectDefOf.Mashed_Ashlands_VolcanoExtinct && x.GetComponent<WorldObjectComp_RandomConditionCauser>().Props.potentialConditions.Where(y => y.conditionDef == GameConditionDefOf.Mashed_Ashlands_PsychicEruption).Any()).ToList();
                }
                return validVolcanos;
            }
        }

        private List<WorldObject> validVolcanos;


        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (p.MapHeld != null)
            {
                if (p.SpawnedOrAnyParentSpawned && p.MapHeld.gameConditionManager.ConditionIsActive(GameConditionDefOf.Mashed_Ashlands_PsychicEruption))
                {
                    return ThoughtState.ActiveDefault;
                }
            }
            else
            {
                if (p.IsCaravanMember())
                {
                    foreach (Volcano volcano in ValidVolcanos.Cast<Volcano>())
                    {
                        WorldObjectComp_RandomConditionCauser conditionComp = volcano.GetComponent<WorldObjectComp_RandomConditionCauser>();
                        if (conditionComp.CurrentConditionDef == GameConditionDefOf.Mashed_Ashlands_PsychicEruption)
                        {
                            if (conditionComp.InAoE(p.GetCaravan().Tile, volcano.Category, volcano))
                            {
                                return ThoughtState.ActiveDefault;
                            }
                        }
                    }
                }
            }
            return ThoughtState.Inactive;
        }
    }
}
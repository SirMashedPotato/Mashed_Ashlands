using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class RecipeWorker_HarvestHive : RecipeWorker
    {
        public override void Notify_IterationCompleted(Pawn billDoer, List<Thing> ingredients)
        {
            if (billDoer.CurJob.targetA != null && billDoer.CurJob.targetA.Thing is Building b)
            {
                DamageInfo damageInfo = new DamageInfo { Def = DamageDefOf.Mining };
                damageInfo.SetAmount(60 / (Mathf.Clamp(billDoer.skills.GetSkill(SkillDefOf.Animals).levelInt, 1, 20) / 2));
                b.TakeDamage(damageInfo);
            }
            base.Notify_IterationCompleted(billDoer, ingredients);
        }
    }
}

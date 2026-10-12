using Verse;
using RimWorld;
using UnityEngine;

namespace Mashed_Ashlands
{
    public class DamageWorker_DrainingStab : DamageWorker_Stab
    {
        public override DamageResult Apply(DamageInfo dinfo, Thing thing)
        {
            if (thing is Pawn target && target.RaceProps.IsFlesh)
            {
                float num = 0.0230066683f;
                num *= (dinfo.Amount * 0.3f);
                if (num != 0f)
                {
                    float num2 = Mathf.Lerp(0.85f, 1.15f, Rand.ValueSeeded(target.thingIDNumber ^ 74374237));
                    num *= num2;
                    HealthUtility.AdjustSeverity(target, RimWorld.HediffDefOf.BloodLoss, num);

                    Pawn pawn2 = dinfo.Instigator as Pawn;
                    Need foodNeed = pawn2.needs.TryGetNeed(NeedDefOf.Food);
                    if (foodNeed != null)
                    {
                        foodNeed.CurLevel += num;
                    }
                }
            }
            return base.Apply(dinfo, thing);
        }
    }
}

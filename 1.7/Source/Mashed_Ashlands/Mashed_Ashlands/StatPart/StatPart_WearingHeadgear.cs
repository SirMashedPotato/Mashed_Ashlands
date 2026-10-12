using Verse;
using RimWorld;
using UnityEngine;

namespace Mashed_Ashlands
{
    public class StatPart_WearingHeadgear : StatPart
    {

        public override string ExplanationPart(StatRequest req)
        {
            if (ActiveFor(req.Thing, out Thing apparel))
            {
                if (apparel != null)
                {
                    return "Mashed_Ashlands_WearingHeadGear".Translate(apparel.Label);
                }
                return "Mashed_Ashlands_WearingHeadGearSettingEnabled".Translate();
            }
			return null;
        }

        public override void TransformValue(StatRequest req, ref float val)
        {
            if (ActiveFor(req.Thing, out _))
            {
                val = Mathf.Clamp(val + Mashed_Ashlands_ModSettings.BaseAshResistanceValue, 0f, parentStat.maxValue);
            }
        }

		private bool ActiveFor(Thing t, out Thing apparel)
		{
            if (Mashed_Ashlands_ModSettings.BaseAshResistance)
            {
                if (t is Pawn pawn)
                {
                    if (pawn.apparel != null)
                    {
                        foreach (Apparel a in pawn.apparel.WornApparel)
                        {
                            if (a.def.apparel.bodyPartGroups.Contains(BodyPartGroupDefOf.FullHead))
                            {
                                apparel = a;
                                return true;
                            }
                        }
                    }
                } else
                {
                    if (t is Apparel headGear)
                    {
                        if (headGear.def.apparel.bodyPartGroups.Contains(BodyPartGroupDefOf.FullHead))
                        {
                            apparel = null;
                            return true;
                        }
                    }
                }
            }
            apparel = null;
            return false;
		}
	}
}

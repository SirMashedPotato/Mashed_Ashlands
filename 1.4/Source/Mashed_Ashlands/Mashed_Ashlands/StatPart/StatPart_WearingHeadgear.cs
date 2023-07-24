using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class StatPart_WearingHeadgear : StatPart
    {
        public float boostAmount = 0.5f;

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
                val += boostAmount;
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

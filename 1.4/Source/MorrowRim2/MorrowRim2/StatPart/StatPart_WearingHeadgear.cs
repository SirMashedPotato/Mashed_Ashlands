using Verse;
using RimWorld;

namespace MorrowRim2
{
    //TODO, maybe uses a setting?
    public class StatPart_WearingHeadgear : StatPart
    {
        public float boostAmount = 0.5f;

        public override string ExplanationPart(StatRequest req)
        {
            if (ActiveFor(req.Thing, out Thing apparel))
            {
				return "MorrowRim_TheAshlands_WearingHeadGear".Translate(apparel.Label);

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
            }
            apparel = null;
            return false;
		}
	}
}

using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Linq;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class IncidentWorker_VolcanoCategoryChange : IncidentWorker
    {
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			if (!base.CanFireNowSub(parms) || !Mashed_Ashlands_ModSettings.VolcanoEnableCategoryChange)
			{
				return false;
			}
			return GetTarget() != null;
		}

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
			Volcano volcano = GetTarget() as Volcano;
			WorldObjectComp_VolcanoDetails compDetails = volcano.GetComponent<WorldObjectComp_VolcanoDetails>();
			int originalCategory = volcano.Category;
			if (Rand.Bool)
			{
				DecreaseByOne(compDetails);
			}
			else
			{
				IncreaseByOne(compDetails);
			}
			Find.LetterStack.ReceiveLetter(def.letterLabel.Formatted(volcano.Name).CapitalizeFirst(), def.letterText.Formatted(volcano.Name, originalCategory, volcano.Category), def.letterDef, volcano, null, null);
			return true;
        }

		private WorldObject GetTarget()
        {
			List<WorldObject> potentialTargets = Find.WorldObjects.AllWorldObjects.Where(x => x is Volcano && x.def != WorldObjectDefOf.MorrowRim_VolcanoExtinct).ToList();
			return potentialTargets.Where(x => x.GetComponent<WorldObjectComp_VolcanoDetails>().CategoryCanBeChanged()).RandomElement();
		}

		private void DecreaseByOne(WorldObjectComp_VolcanoDetails compDetails)
		{
            if (!compDetails.CategoryCanBeDecreasedByOne())
            {
				IncreaseByOne(compDetails);
				return;
			}
			compDetails.ParentVolcano.Category--;
		}

		private void IncreaseByOne(WorldObjectComp_VolcanoDetails compDetails)
        {
			if (!compDetails.CategoryCanBeIncreasedByOne())
			{
				DecreaseByOne(compDetails);
				return;
			}
			compDetails.ParentVolcano.Category++;
		}
	}
}

using Verse;
using RimWorld;
using RimworldExploration;
using Mashed_Ashlands;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Mashed_Ashlands_ExplorationMode
{
    public class CompUseEffect_VolcanoMap : CompUseEffect
	{
		public CompProperties_UseEffectVolcanoMap Props
		{
			get
			{
				return (CompProperties_UseEffectVolcanoMap)props;
			}
		}

        public override void DoEffect(Pawn usedBy)
        {
            base.DoEffect(usedBy);
            LearnLocation();
        }

        public void LearnLocation()
        {
            List<WorldObject> unknownVolcanos = UndiscoveredVolcanos();
            if (!unknownVolcanos.NullOrEmpty())
            {
                Thing mapItem = parent;
                int parentIntegrity = (int)Math.Round(mapItem.HitPoints / (double)mapItem.MaxHitPoints);
                Random random = new Random();
                IEnumerable<WorldObject> selectedVolcanos = (from x in unknownVolcanos
                                                             orderby random.Next()
                                                             select x).Take(Math.Min(unknownVolcanos.Count, Props.locations));
                foreach (WorldObject volcano in selectedVolcanos)
                {
                    VisibilityManager.RevealAt(volcano, Props.size * parentIntegrity);
                    Message msg = new Message("RWE_RevealedLocation".Translate().Formatted(volcano.LabelCap), MessageTypeDefOf.PositiveEvent, volcano);
                    Messages.Message(msg, true);
                }
                VisibilityManager.UpdateGraphics();
            }
        }

        public List<WorldObject> UndiscoveredVolcanos()
        {
            WorldObjectsHolder worldObjectsHolder = Find.WorldObjects;
            return new List<WorldObject>(worldObjectsHolder.AllWorldObjects.Where(x => x is Volcano && !VisibilityManager.IsFounded(x)));
        }

        public override bool CanBeUsedBy(Pawn p, out string failReason)
        {
            if (!p.health.capacities.CapableOf(PawnCapacityDefOf.Sight) || p.health.capacities.GetLevel(PawnCapacityDefOf.Sight) <= 0)
            {
                failReason = "Mashed_Ashlands_PawnIsBlind".Translate(p.Name);
                return false;
            }
            if (UndiscoveredVolcanos().NullOrEmpty())
            {
                failReason = "Mashed_Ashlands_NoUndiscoveredVolcano".Translate();
                return false;
            }
            return base.CanBeUsedBy(p, out failReason);
        }
    }
}

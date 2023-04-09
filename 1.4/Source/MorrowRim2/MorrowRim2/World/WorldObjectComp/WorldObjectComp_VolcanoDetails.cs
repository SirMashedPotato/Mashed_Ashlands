using RimWorld;
using RimWorld.Planet;
using Verse.Grammar;
using Verse;
using System.Collections.Generic;

namespace MorrowRim2
{
    public class WorldObjectComp_VolcanoDetails : WorldObjectComp
    {
		public WorldObjectCompProperties_VolcanoDetails Props
		{
			get
			{
				return (WorldObjectCompProperties_VolcanoDetails)props;
			}
		}

        public Volcano ParentVolcano
        {
            get
            {
                return parent as Volcano;
            }
        }

        public override void Initialize(WorldObjectCompProperties props)
        {
            base.Initialize(props);
            if (Props.nameNamer != null)
            {
                ParentVolcano.Name = GrammarResolver.Resolve("r_name", new GrammarRequest { Includes = { Props.nameNamer } });
            }
            if (!Props.categoryWeights.NullOrEmpty())
            {
                ParentVolcano.Category = Props.categoryWeights.RandomElementByWeight(x => x.weight).category;
            }
        }

        public override string CompInspectStringExtra()
        {
            return "MorrowRim_TheAshlands_VolcanoDescription".Translate(ParentVolcano.Category, parent.def.label);
        }

        public override void PostDrawExtraSelectionOverlays()
        {
            base.PostDrawExtraSelectionOverlays();
            if (!Props.extinct && ParentVolcano.MaximumEffectRadius != -1)
            {
                GenDraw.DrawWorldRadiusRing(parent.Tile, ParentVolcano.MaximumEffectRadius);
            }
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach (Gizmo gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }

            if (DebugSettings.ShowDevGizmos)
            {
                int categoryIndex = Props.categoryWeights.FindIndex(x => x.category == ParentVolcano.Category);

                yield return new Command_Action
                {
                    defaultLabel = "DEV: Decrease category by 1",
                    action = delegate ()
                    {
                        ParentVolcano.Category -= 1;
                    },
                    disabled = categoryIndex <= 0
                };

                yield return new Command_Action
                {
                    defaultLabel = "DEV: Increase category by 1",
                    action = delegate ()
                    {
                        ParentVolcano.Category += 1;
                    },
                    disabled = categoryIndex >= Props.categoryWeights.Count - 1
                };
            }
        }
    }
}

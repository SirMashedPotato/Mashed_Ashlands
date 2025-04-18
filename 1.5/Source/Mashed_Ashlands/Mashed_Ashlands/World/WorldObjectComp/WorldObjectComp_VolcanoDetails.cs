﻿using RimWorld;
using RimWorld.Planet;
using Verse.Grammar;
using Verse;
using System.Collections.Generic;

namespace Mashed_Ashlands
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

        private bool IsRedMountain => ParentVolcano.Name.ToLower().Contains("Mashed_Ashlands_RedMountain".Translate().ToLower());

        public override void Initialize(WorldObjectCompProperties props)
        {
            base.Initialize(props);
            if (Props.nameNamer != null)
            {
                ParentVolcano.Name = GrammarResolver.Resolve("r_name", new GrammarRequest { Includes = { Props.nameNamer } });
            }
            if (!Props.categoryWeights.NullOrEmpty())
            {
                if (IsRedMountain)
                {
                    ParentVolcano.Category = Props.categoryWeights[Props.categoryWeights.Count-1].category;
                }
                else
                {
                    ParentVolcano.Category = Props.categoryWeights.RandomElementByWeight(x => x.weight).category;
                }
            }
        }

        public override string CompInspectStringExtra()
        {
            string output = "Mashed_Ashlands_VolcanoDescription".Translate(ParentVolcano.Category, parent.def.label, ParentVolcano.EffectRadiusFor(ParentVolcano.Category), ParentVolcano.TotalIncidents, ParentVolcano.LastIncident);
            return output;
        }

        public override void PostDrawExtraSelectionOverlays()
        {
            base.PostDrawExtraSelectionOverlays();
            if (!Props.extinct)
            {
                int radius = ParentVolcano.EffectRadiusFor(ParentVolcano.Category);
                if (radius != -1)
                {
                    GenDraw.DrawWorldRadiusRing(parent.Tile, radius);
                }
            }
        }

        public bool TryChangeCategory()
        {
            bool categoryChanged = false;
            if (CategoryCanBeChanged())
            {
                if (Rand.Bool)
                {
                    categoryChanged = DecreaseByOne();
                }
                else
                {
                    categoryChanged = IncreaseByOne();
                }
            }
            return categoryChanged;
        }

        public bool CategoryCanBeChanged()
        {
            return !IsRedMountain && Props.categoryCanChange && (CategoryCanBeIncreasedByOne() || CategoryCanBeDecreasedByOne());
        }

        public bool CategoryCanBeIncreasedByOne()
        {
            int categoryIndex = Props.categoryWeights.FindIndex(x => x.category == ParentVolcano.Category);
            return categoryIndex < Props.categoryWeights.Count - 1; 
        }

        private bool IncreaseByOne()
        {
            if (!CategoryCanBeIncreasedByOne())
            {
                if (Rand.Bool)
                {
                    return DecreaseByOne();
                }
                return false;
            }
            ParentVolcano.Category++;
            return true;
        }

        public bool CategoryCanBeDecreasedByOne()
        {
            int categoryIndex = Props.categoryWeights.FindIndex(x => x.category == ParentVolcano.Category);
            return categoryIndex > 1;
        }

        private bool DecreaseByOne()
        {
            if (!CategoryCanBeDecreasedByOne())
            {
                if (Rand.Bool)
                {
                    return IncreaseByOne();
                }
                return false;
            }
            ParentVolcano.Category--;
            return true;
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
                    Disabled = categoryIndex <= 0
                };

                yield return new Command_Action
                {
                    defaultLabel = "DEV: Increase category by 1",
                    action = delegate ()
                    {
                        ParentVolcano.Category += 1;
                    },
                    Disabled = categoryIndex >= Props.categoryWeights.Count - 1
                };
            }
        }
    }
}

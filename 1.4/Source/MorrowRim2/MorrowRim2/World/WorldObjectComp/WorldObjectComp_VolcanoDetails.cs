using RimWorld;
using RimWorld.Planet;
using Verse.Grammar;
using Verse;

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
            return "MorrowRim_TheAshlands_VolcanoDescription".Translate(parent.def.label, ParentVolcano.Category);
        }
    }
}

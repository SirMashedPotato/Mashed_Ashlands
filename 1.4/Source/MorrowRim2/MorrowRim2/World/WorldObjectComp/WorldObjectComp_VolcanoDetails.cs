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

        public override void Initialize(WorldObjectCompProperties props)
        {
            base.Initialize(props);
            if (parent is Volcano volcano)
            {
                if (Props.nameNamer != null && !volcano.HasName)
                {
                    volcano.Name = GrammarResolver.Resolve("r_name", new GrammarRequest { Includes = { Props.nameNamer } });
                }
            }
        }

        public override string CompInspectStringExtra()
        {
            return "MorrowRim_TheAshlands_VolcanoDescription".Translate(parent.def.label);
        }
    }
}

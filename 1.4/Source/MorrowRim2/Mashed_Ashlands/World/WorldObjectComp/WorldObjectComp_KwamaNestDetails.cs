using RimWorld;
using RimWorld.Planet;
using Verse.Grammar;
using Verse;

namespace Mashed_Ashlands
{
    public class WorldObjectComp_KwamaNestDetails : WorldObjectComp
    {
        public WorldObjectCompProperties_KwamaNestDetails Props
        {
            get
            {
                return (WorldObjectCompProperties_KwamaNestDetails)props;
            }
        }

        public KwamaNest ParentNest
        {
            get
            {
                return parent as KwamaNest;
            }
        }

        public override void Initialize(WorldObjectCompProperties props)
        {
            base.Initialize(props);
            if (Props.nameNamer != null)
            {
                ParentNest.Name = GrammarResolver.Resolve("r_name", new GrammarRequest { Includes = { Props.nameNamer } });
            }
            if (Props.sizeRange != null)
            {
                ParentNest.NestSize = Props.sizeRange.RandomInRange;
            }
            else
            {
                ParentNest.NestSize = 3;
            }
        }

        public override string CompInspectStringExtra()
        {
            string output = "Mashed_Ashlands_KwamaNestDescription".Translate(ParentNest.NestSize, parent.def.label, ParentNest.EffectRadiusFor(ParentNest.NestSize));
            return output;
        }

        public override void PostDrawExtraSelectionOverlays()
        {
            base.PostDrawExtraSelectionOverlays();
            int radius = ParentNest.EffectRadiusFor(ParentNest.NestSize);
            if (radius != -1)
            {
                GenDraw.DrawWorldRadiusRing(parent.Tile, radius);
            }
        }
    }
}

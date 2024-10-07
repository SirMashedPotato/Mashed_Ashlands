using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class PawnRenderNode_AnimalBlighted : PawnRenderNode_AnimalPart
    {
        public PawnRenderNode_AnimalBlighted(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree) : base(pawn, props, tree)
        {
        }

        public override Graphic GraphicFor(Pawn pawn)
        {
            Graphic baseGraphic = base.GraphicFor(pawn);
            return baseGraphic.GetColoredVersion(ShaderDatabase.Transparent, blightColour, blightColour);
        }

        private static Color blightColour = new Color(0.3f,0.1f,0.1f,0.3f);
    }
}

using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    public class PawnRenderNode_AnimalGlow : PawnRenderNode_AnimalPart
    {
        public PawnRenderNode_AnimalGlow(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree) : base(pawn, props, tree)
        {
        }

        public override Graphic GraphicFor(Pawn pawn)
        {
            if (!OnStartupUtility.glowOverlayAnimals.Contains(pawn.def))
            {
                return null;
            }
            PawnKindLifeStage curKindLifeStage = pawn.ageTracker.CurKindLifeStage;
            Graphic graphic = ((pawn.gender == Gender.Female && curKindLifeStage.femaleGraphicData != null) ? curKindLifeStage.femaleGraphicData.Graphic : curKindLifeStage.bodyGraphicData.Graphic);
            return GraphicDatabase.Get<Graphic_Multi>(graphic.path + "Glow", ShaderDatabase.TransparentPostLight, graphic.drawSize, Color.white);
        }
    }
}

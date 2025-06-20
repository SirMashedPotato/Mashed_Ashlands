using Verse;

namespace Mashed_Ashlands
{
    public class PawnRenderNodeWorker_AnimalGlow : PawnRenderNodeWorker
    {
        public override bool CanDrawNow(PawnRenderNode node, PawnDrawParms parms)
        {
            if (base.CanDrawNow(node, parms) && !parms.Portrait && parms.pawn.RaceProps.Animal)
            {
                return OnStartupUtility.glowOverlayAnimals.Contains(parms.pawn.def);
            }
            return false;
        }
    }
}

using RimWorld;
using Verse;
using Verse.Sound;

namespace Mashed_Ashlands
{
    public class GameCondition_PsychicEruption : GameCondition
    {
        public override void PostMake()
        {
            if (ModsConfig.RoyaltyActive)
            {
                SoundDefOf.AnimaTreeScream.PlayOneShotOnCamera();
            }
            else
            {
                RimWorld.SoundDefOf.PsychicPulseGlobal.PlayOneShotOnCamera();
            }
            base.PostMake();
        }
    }
}

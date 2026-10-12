using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    internal class CaravanEventWorker_VolcanicMiasma : CaravanVolcanicEventWorker
    {
        public override void CaravanEventWorker(Volcano parentVolcano, List<Caravan> targets)
        {
            if (!Mashed_Ashlands_ModSettings.MiasmaAffectsCaravan)
            {
                return;
            }
            foreach (Caravan caravan in targets)
            {
                if (caravan.pather.MovingNow)
                {
                    foreach (Pawn p in caravan.PawnsListForReading)
                    {
                        ToxicUtility.DoAirbornePawnToxicDamage(p);
                    }
                }
            }
        }
    }
}

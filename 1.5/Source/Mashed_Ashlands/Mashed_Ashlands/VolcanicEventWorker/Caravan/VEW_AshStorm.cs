using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// TODO switch to using this in 1.6
    /// </summary>
    public class VEW_AshStorm : CaravanVolcanicEventWorker
    {
        public override void CaravanEventWorker(Volcano parentVolcano, int category, List<Caravan> targets)
        {
            if (!Mashed_Ashlands_ModSettings.AshStormCauseBuildup || !Mashed_Ashlands_ModSettings.AshStormAffectsCaravan)
            {
                return;
            }
            foreach (Caravan caravan in targets)
            {
                if (caravan.pather.MovingNow)
                {
                    foreach (Pawn p in caravan.PawnsListForReading)
                    {
                        GameCondition_AshStorm.DoPawnAshDamage(p, false);
                    }
                }
            }
        }
    }
}

using Verse;

namespace Mashed_Ashlands
{
    class DeathActionWorker_CliffRacer : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse)
        {
            if (corpse.InnerPawn.Faction == null && Mashed_Ashlands_ModSettings.EnableCliffRacerExtinction)
            {
                CliffRacerTrackerUtility.ModifyProgress(-1, corpse);
            }
        }
    }
}
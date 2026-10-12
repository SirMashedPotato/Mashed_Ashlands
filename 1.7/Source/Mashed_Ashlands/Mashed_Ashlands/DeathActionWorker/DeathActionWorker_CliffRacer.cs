using Verse;
using Verse.AI.Group;

namespace Mashed_Ashlands
{
    class DeathActionWorker_CliffRacer : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            if (corpse.InnerPawn.Faction == null && Mashed_Ashlands_ModSettings.CliffRacerEnableExtinction)
            {
                CliffRacerTrackerUtility.ModifyProgress(-1, corpse);
            }
        }
    }
}
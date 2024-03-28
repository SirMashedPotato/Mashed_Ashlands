using Verse;
using Verse.AI.Group;

namespace Mashed_Ashlands
{
    class DeathActionWorker_Destroy : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            corpse.InnerPawn.Destroy();
        }
    }
}
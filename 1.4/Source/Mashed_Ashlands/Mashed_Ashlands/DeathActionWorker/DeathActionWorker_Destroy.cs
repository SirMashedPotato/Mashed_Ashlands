using Verse;

namespace Mashed_Ashlands
{
    class DeathActionWorker_Destroy : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse)
        {
            corpse.Destroy();
        }
    }
}
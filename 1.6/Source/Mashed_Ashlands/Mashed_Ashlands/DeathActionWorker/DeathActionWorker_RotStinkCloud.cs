using RimWorld;
using Verse;
using Verse.AI.Group;

namespace Mashed_Ashlands
{
    internal class DeathActionWorker_RotStinkCloud : DeathActionWorker
    {
        public override bool DangerousInMelee => true;

        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            GenExplosion.DoExplosion(radius: (corpse.InnerPawn.ageTracker.CurLifeStageIndex == 0) ? 0.9f : ((corpse.InnerPawn.ageTracker.CurLifeStageIndex != 1) ? 2.9f : 1.9f), 
                center: corpse.Position, map: corpse.Map, damType: DamageDefOf.Smoke, instigator: corpse.InnerPawn, damAmount: -1, postExplosionGasType: GasType.RotStink);
        }
    }
}

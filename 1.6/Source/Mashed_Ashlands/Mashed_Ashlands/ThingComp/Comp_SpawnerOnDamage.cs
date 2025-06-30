using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class Comp_SpawnerOnDamage : ThingComp
    {
        private CompProperties_SpawnerOnDamage Props => (CompProperties_SpawnerOnDamage)props;

        private int cooldownTicksLeft = 0;

        public override void PostPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            if (!parent.Destroyed)
            {
                if (cooldownTicksLeft <= 0 && Rand.Chance(Props.spawnChance))
                {
                    TryDoSpawn();
                    cooldownTicksLeft = Props.cooldownTicks;

                }
            }
            base.PostPostApplyDamage(dinfo, totalDamageDealt);
        }

        public void TryDoSpawn()
        {
            Pawn pawn = PawnGenerator.GeneratePawn(Props.pawnKindDef, null);
            GenSpawn.Spawn(pawn, parent.Position, parent.Map, Rot4.Random, WipeMode.Vanish, false);
            pawn.mindState.mentalStateHandler.TryStartMentalState(RimWorld.MentalStateDefOf.ManhunterPermanent);
        }

        public override void CompTick()
        {
            if (cooldownTicksLeft > 0)
            {
                cooldownTicksLeft--;
            }
            base.CompTick();
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref cooldownTicksLeft, "cooldownTicksLeft", 0);
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            if (DebugSettings.ShowDevGizmos)
            {
                yield return new Command_Action
                {
                    defaultLabel = "DEV: Trigger " + Props.pawnKindDef.label,
                    icon = TexCommand.DesirePower,
                    action = delegate ()
                    {
                        TryDoSpawn();
                    }
                };
            }
            yield break;
        }
    }
}

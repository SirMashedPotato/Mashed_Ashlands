using Verse;

namespace Mashed_Ashlands
{
    public class Comp_DischargeOnDamage : ThingComp
    {
        private CompProperties_DischargeOnDamage Props
        {
            get
            {
                return (CompProperties_DischargeOnDamage)props;
            }
        }

        private int cooldownTicksLeft = 0;

        public override void PostPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            Pawn p = parent as Pawn;
            if (p.Spawned && !p.Dead)
            {
                if(cooldownTicksLeft <= 0)
                {
                    GenExplosion.DoExplosion(p.Position, p.Map, Props.radius, Props.damageDef, p, Props.damageAmount, -1);
                    cooldownTicksLeft = Props.cooldownTicks;
                }
            }
            base.PostPostApplyDamage(dinfo, totalDamageDealt);
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
    }
}

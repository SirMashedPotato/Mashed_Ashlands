﻿using Verse;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class Comp_DischargeOnDamage : ThingComp
    {
        private CompProperties_DischargeOnDamage Props => (CompProperties_DischargeOnDamage)props;

        private int cooldownTicksLeft = 0;
        private const int cooldownTicks = 300;

        public override void PostPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            Pawn p = parent as Pawn;
            if (p.Spawned && !p.Dead)
            {
                if(cooldownTicksLeft <= 0)
                {
                    GenExplosion.DoExplosion(
                        center: p.Position,
                        map: p.Map,
                        radius: Props.radius,
                        damType: Props.damageDef,
                        damAmount: Props.damageAmount,
                        instigator: p,
                        ignoredThings: new List<Thing> { p },
                        damageFalloff: true
                        );
                    cooldownTicksLeft = Props.cooldownTicks;
                }
            }
            base.PostPostApplyDamage(dinfo, totalDamageDealt);
        }

        public override void CompTickInterval(int delta)
        {
            if (parent.IsHashIntervalTick(cooldownTicks, delta))
            {
                if (cooldownTicksLeft > 0)
                {
                    cooldownTicksLeft -= delta + cooldownTicks;
                }
            }
            base.CompTickInterval(delta);
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref cooldownTicksLeft, "cooldownTicksLeft", 0);
        }
    }
}

﻿using Verse;
using RimWorld;
using System.Linq;

namespace Mashed_Ashlands
{
    public class HediffComp_Regeneration : HediffComp
    {

        public HediffCompProperties_Regeneration Props => (HediffCompProperties_Regeneration)props;

        public override void CompPostTickInterval(ref float severityAdjustment, int delta)
        {
            base.CompPostTickInterval(ref severityAdjustment, delta);
            Pawn pawn = Pawn;
            if (pawn.IsHashIntervalTick(Props.ticks, delta))
            {
                if ((pawn.IsBurning() && Props.fireDisables) || pawn.Dead || !pawn.Spawned)
                {
                    return;
                }
                else
                {
                    for (int i = 0; i != Props.baseNumber; i++)
                    {
                        if (!(from hd in pawn.health.hediffSet.hediffs
                              where hd.def.displayWound
                              select hd).TryRandomElement(out Hediff hediff))
                        {
                            return;
                        }
                        if (pawn.health.hediffSet.PartIsMissing(hediff.Part) && Props.regenParts)
                        {
                            HealthUtility.Cure(hediff);
                        }
                        else
                        {
                            hediff.Severity -= Props.severity;
                        }
                    }
                }
            }
        }
    }
}
using System;
using Verse;
using RimWorld;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class Gas_FetcherflySwarm : Gas
    {
        private readonly int tickInterval = 60;

        public override void Tick()
        {
            base.Tick();
            TickEffecter();
            try
            {
                if (this.IsHashIntervalTick(tickInterval))
                {
                    HashSet<Thing> hashSet = new HashSet<Thing>(Position.GetThingList(Map));
                    if (hashSet != null)
                    {
                        foreach (Thing thing in hashSet)
                        {
                            if (thing != null && thing is Pawn p)
                            {
                                DamageInfo damageInfo = new DamageInfo() 
                                { 
                                    Def = DamageDefOf.Burn
                                };
                                damageInfo.SetAmount(Rand.RangeInclusive(1, 5));
                                thing.TakeDamage(damageInfo);
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        public void TickEffecter()
        {
            if (!Spawned)
            {
                Effecter temp = effecter;
                if (temp != null)
                {
                    temp.Cleanup();
                }
                effecter = null;
                return;
            }
            if (effecter == null)
            {
                effecter = EffecterDefOf.Mashed_Ashlands_FetcherflySwarmEffecter.SpawnAttached(this, Map, 1f);
            }
            Effecter effecter2 = effecter;
            if (effecter2 == null)
            {
                return;
            }
            effecter2.EffectTick(this, this);
        }

        private Effecter effecter;
    }
}

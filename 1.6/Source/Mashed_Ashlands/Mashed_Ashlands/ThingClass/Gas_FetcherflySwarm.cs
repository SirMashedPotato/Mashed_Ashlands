using System;
using Verse;
using RimWorld;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class Gas_FetcherflySwarm : Gas
    {
        private readonly int tickInterval = 60;

        protected override void Tick()
        {
            base.Tick();
            TickEffecter();
        }

        protected override void TickInterval(int delta)
        {
            base.TickInterval(delta);
            try
            {
                if (this.IsHashIntervalTick(tickInterval, delta))
                {
                    HashSet<Thing> hashSet = new HashSet<Thing>(Position.GetThingList(Map));
                    if (hashSet != null)
                    {
                        foreach (Thing thing in hashSet)
                        {
                            if (thing != null && thing is Pawn p && p.def != ThingDefOf.Mashed_Ashlands_FetcherflySwarmAnimal)
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
                temp?.Cleanup();
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

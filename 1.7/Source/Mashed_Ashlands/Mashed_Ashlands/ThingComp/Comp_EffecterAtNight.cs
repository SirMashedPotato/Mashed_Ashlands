using RimWorld;
using Verse;


namespace Mashed_Ashlands
{
    public class Comp_EffecterExtendedAtNight : ThingComp
    {
        public CompProperties_EffecterAtNight Props => (CompProperties_EffecterAtNight)props;

        public override void CompTickInterval(int delta)
        {
            if (parent.IsHashIntervalTick(Props.tickInterval, delta))
            {
                if (GenLocalDate.DayPercent(parent) < 0.25f || GenLocalDate.DayPercent(parent) > 0.8f)
                {
                    TickEffecter();
                }
            }
            base.CompTickInterval(delta);
        }

        //used by plants
        public override void CompTickLong()
        {
            if (parent.IsHashIntervalTick(Props.tickInterval))
            {
                if (GenLocalDate.DayPercent(parent) < 0.25f || GenLocalDate.DayPercent(parent) > 0.8f)
                {
                    TickEffecter();
                }
            }
            base.CompTickLong();
        }

        public void TickEffecter()
        {
            if (!parent.Spawned)
            {
                Effecter temp = effecter;
                temp?.Cleanup();
                effecter = null;
                return;
            }
            if (effecter == null)
            {
                effecter = Props.effecterDef.SpawnAttached(parent, parent.MapHeld, 1f);
            }
            Effecter effecter2 = effecter;
            if (effecter2 == null)
            {
                return;
            }
            effecter2.EffectTick(parent, parent);
        }

        private Effecter effecter;
    }
}

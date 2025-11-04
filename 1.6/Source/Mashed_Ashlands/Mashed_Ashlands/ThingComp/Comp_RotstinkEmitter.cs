using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class Comp_RotstinkEmitter : ThingComp
    {
        public override void CompTickRare()
        {
            if (!parent.Spawned || parent.Map == null)
            {
                return;
            }

            if (!QualityUtility.TryGetQuality(parent, out QualityCategory quality))
            {
                return;
            }

            float chance = quality == QualityCategory.Awful ? 0.06f : quality == QualityCategory.Poor ? 0.03f : 0f;

            if (!Rand.Chance(chance))
            {
                return;
            }

            GasUtility.AddGas(parent.Position, parent.Map, GasType.RotStink, 1f);
        }
    }
}

using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class Comp_GasOnDestroy : ThingComp
    {
        private CompProperties_GasOnDestroy Props => (CompProperties_GasOnDestroy)props;

        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            if (parent is Plant p)
            {
                if ((!Props.onlyIfHarvestable || p.def.plant.Harvestable) && p.Growth >= Props.minGrowth)
                {
                    GasUtility.AddGas(parent.Position, previousMap, Props.gasType, Props.radius);
                }
            }
            base.PostDestroy(mode, previousMap);
        }
    }
}

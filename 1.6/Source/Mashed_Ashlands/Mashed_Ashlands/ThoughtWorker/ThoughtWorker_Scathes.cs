using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class ThoughtWorker_Scathes : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (!p.SpawnedOrAnyParentSpawned || !p.Awake() || p.PositionHeld.Roofed(p.MapHeld))
            {
                return ThoughtState.Inactive;
            }

            if (!p.health.capacities.CapableOf(PawnCapacityDefOf.Breathing))
            {
                return ThoughtState.Inactive;
            }

            if (p.MapHeld.Biome != BiomeDefOf.Mashed_Ashlands_VolcanicSulphurPitsAshlands && 
                p.MapHeld.MixedBiomeComp.secondaryBiome != BiomeDefOf.Mashed_Ashlands_VolcanicSulphurPitsAshlands)
            {
                return ThoughtState.Inactive;
            }

            return ThoughtState.ActiveDefault;
        }
    }
}

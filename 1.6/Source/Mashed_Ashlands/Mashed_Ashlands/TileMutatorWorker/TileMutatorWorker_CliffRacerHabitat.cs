using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_CliffRacerHabitat : TileMutatorWorker
    {
        private const float CliffRacerCommonalityFactor = 3f;
        private const float SmallAnimalCommonalityFactor = 1f;
        private const float BodySizeCutoff = 0.3f;

        public TileMutatorWorker_CliffRacerHabitat(TileMutatorDef def) : base(def)
        {
        }

        public override float AnimalCommonalityFactorFor(PawnKindDef animal, PlanetTile tile)
        {
            if (!ModsConfig.OdysseyActive)
            {
                return 1f;
            }
            if (animal == PawnKindDefOf.Mashed_Ashlands_CliffRacer && !CliffRacerTrackerUtility.ExtinctionReached())
            {
                return CliffRacerCommonalityFactor;
            }
            if (animal.RaceProps.baseBodySize <= BodySizeCutoff)
            {
                return SmallAnimalCommonalityFactor;
            }
            return 0f;
        }
    }
}

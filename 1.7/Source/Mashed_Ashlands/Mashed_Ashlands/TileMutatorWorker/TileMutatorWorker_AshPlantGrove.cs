using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class TileMutatorWorker_AshPlantGrove : TileMutatorWorker
    {
        private static readonly Dictionary<BiomeDef, List<ThingDef>> cachedPlantKinds = new Dictionary<BiomeDef, List<ThingDef>>();
        private const float PlantCommonalityFactor = 10f;

        public TileMutatorWorker_AshPlantGrove(TileMutatorDef def) : base(def)
        {
        }

        public override bool IsValidTile(PlanetTile tile, PlanetLayer layer)
        {
            return layer[tile].PrimaryBiome.AllWildPlants.Any(def.plantKinds.Contains);
        }

        public override string GetLabel(PlanetTile tile)
        {
            return GetPlantKind(tile).plant.IsTree ? "PlantGrove".Translate(GetPlantKind(tile).label) : "Mashed_Ashlands_PlantField".Translate(GetPlantKind(tile).label);
        }

        public override string GetDescription(PlanetTile tile)
        {
            return def.description.Formatted(GetPlantKind(tile).label);
        }

        public override float PlantCommonalityFactorFor(ThingDef plant, PlanetTile tile)
        {
            if (!ModsConfig.OdysseyActive)
            {
                return 1f;
            }
            if (plant != GetPlantKind(tile))
            {
                return 1f;
            }
            return PlantCommonalityFactor;
        }

        private ThingDef GetPlantKind(PlanetTile tile)
        {
            BiomeDef primaryBiome = Find.WorldGrid[tile].PrimaryBiome;
            if (!cachedPlantKinds.TryGetValue(primaryBiome, out var value))
            {
                value = new List<ThingDef>();
                foreach (ThingDef allWildPlant in primaryBiome.AllWildPlants)
                {
                    if (def.plantKinds.Contains(allWildPlant))
                    {
                        value.Add(allWildPlant);
                    }
                }
                cachedPlantKinds.Add(primaryBiome, value);
            }
            Rand.PushState();
            Rand.Seed = tile.GetHashCode();
            ThingDef result = value.RandomElement();
            Rand.PopState();
            return result;
        }
    }
}

using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Limit specific animals to tiles with specific landmarks
    /// </summary>
    [HarmonyPatch(typeof(WildAnimalSpawner))]
    [HarmonyPatch("CommonalityOfAnimalNow")]
    public static class WildAnimalSpawner_CommonalityOfAnimalNow_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_CommonalityOfAnimalNow_Patch(PawnKindDef def, ref Map ___map, ref float __result)
        {
            AnimalProperties props = AnimalProperties.Get(def.race);
            if (props != null)
            {
                if (!props.ignoreRequirementsInBiomes.NullOrEmpty() && props.ignoreRequirementsInBiomes.Contains(___map.Biome))
                {
                    return;
                }
                if (props.requireCaves && !Find.World.HasCaves(___map.Tile))
                {
                    __result = 0;
                    return;
                }
                if ((props.requireCoast || props.requireWater) && !Find.World.CoastDirectionAt(___map.Tile).IsValid)
                {
                    __result = 0;
                    return;
                }
                if (props.requireHills && Find.WorldGrid[___map.Tile].hilliness == Hilliness.Flat)
                {
                    __result = 0;
                    return;
                }
                if ((props.requireRiver || props.requireWater) && Find.WorldGrid[___map.Tile].Rivers == null)
                {
                    __result = 0;
                    return;
                }
            }
        }
    }
}

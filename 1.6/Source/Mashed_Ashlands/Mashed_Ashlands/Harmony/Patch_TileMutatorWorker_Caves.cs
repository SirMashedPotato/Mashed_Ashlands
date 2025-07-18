using HarmonyLib;
using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Replaces cave terrain generation for ashland biomes
    /// </summary>
    [HarmonyPatch(typeof(TileMutatorWorker_Caves))]
    [HarmonyPatch("GeneratePostTerrain")]
    public static class TileMutatorWorker_Caves_GeneratePostTerrain_Patch
    {
        public static void Postfix(Map map)
        {
            MapGenFloatGrid caves = MapGenerator.Caves;
            MapGenFloatGrid elevation = MapGenerator.Elevation;
            foreach (IntVec3 c in map.AllCells)
            {
                if (!(caves[c] <= 0f) && !(elevation[c] <= 0f) && c.GetTerrain(map) == RimWorld.TerrainDefOf.Gravel)
                {
                    BiomeCaveProperties props = BiomeCaveProperties.GetProps(map, c);
                    if (props != null && props.caveGravelReplacer != null)
                    {
                        map.terrainGrid.SetTerrain(c, props.caveGravelReplacer);
                    }
                }
            }
        }
    }
}

using HarmonyLib;
using Verse;
using RimWorld;
using Verse.Noise;

namespace Mashed_Ashlands
{
    

    /// <summary>
    /// Allows for custom terrain gen
    /// Largely copy pasta of GenStep_CavesTerrain.Generate
    /// </summary>
    /*
    [HarmonyPatch(typeof(GenStep_CavesTerrain))]
    [HarmonyPatch("Generate")]
    public static class GenStep_CavesTerrain_Generate_Patch
    {
        [HarmonyPrefix]
        public static bool Mashed_Ashlands_CaveTerrain_Patch(Map map)
        {
            if (!map.IsPocketMap && Find.World.HasCaves(map.Tile))
            {
                BiomeProperties props = BiomeProperties.Get(map.Biome);
                if (props != null && props.useCustomCaveTerrain)
                {
                    Perlin perlin = new Perlin(0.079999998211860657, 2.0, 0.5, 6, Rand.Int, QualityMode.Medium);
                    Perlin perlin2 = new Perlin(0.15999999642372131, 2.0, 0.5, 6, Rand.Int, QualityMode.Medium);
                    MapGenFloatGrid caves = MapGenerator.Caves;
                    foreach (IntVec3 intVec in map.AllCells)
                    {
                        if (caves[intVec] > 0f && !intVec.GetTerrain(map).IsRiver)
                        {
                            float num = (float)perlin.GetValue(intVec.x, 0.0, intVec.z);
                            float num2 = (float)perlin2.GetValue(intVec.x, 0.0, intVec.z);
                            if (num > props.waterThreshold)
                            {
                                map.terrainGrid.SetTerrain(intVec, props.waterTerrainDef);
                            }
                            else if (num2 > props.otherTerrainThreshold)
                            {
                                map.terrainGrid.SetTerrain(intVec, props.otherTerrainDef);
                            }
                        }
                    }
                    return false;
                }
            }
            return true;
        }
    }
    */
}

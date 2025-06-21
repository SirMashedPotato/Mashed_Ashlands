using HarmonyLib;
using System.Collections.Generic;
using RimWorld;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Actually prevents rivers from generating on certain ashland biomes on the world map.
    /// Unlike the vanilla field that just prevents them on the player map.
    /// </summary>
    /*
    [HarmonyPatch(typeof(WorldGenStep_Rivers))]
    [HarmonyPatch("ExtendRiver")]
    public static class WorldGenStep_Rivers_ExtendRiver_Patch
    {
        [HarmonyPrefix]
        public static bool Mashed_Ashlands_ExtendRiver_Patch(int index)
        {
            Tile tile = Find.WorldGrid.tiles[index];
            BiomeProperties props = BiomeProperties.Get(tile.biome);
            if (props != null && props.preventRivers)
            {
                return false;
            }
            return true;
        }
    }
    */
}

using HarmonyLib;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace MorrowRim2
{
    /// <summary>
    /// Allows setting animals that should recieve/not recieve pollution stimulus
    /// </summary>
    /*
    [HarmonyPatch(typeof(WorldGenStep_Terrain))]
    [HarmonyPatch("GenerateTileFor")]
    public static class WorldGenStep_Terrain_GenerateTileFor_Patch
    {
        [HarmonyPostfix]
        public static void GenerateTileFor_Patch(int tileID)
        {
            if (Rand.Chance(0.1f))
            {
                Log.Message("1 - " + tileID);
                WorldObject volcano = WorldObjectMaker.MakeWorldObject(WorldObjectDefOf.MorrowRim_VolcanoDormant);
                Log.Message("2");
                volcano.Tile = tileID;
                Log.Message("3");
                Find.WorldObjects.Add(volcano);
                Log.Message("4");
            }
        }
    }
    */
}

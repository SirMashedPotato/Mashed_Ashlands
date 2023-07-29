using HarmonyLib;
using Verse;
using System.Reflection;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            Harmony harmony = new Harmony("com.Mashed_Ashlands");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            if (LoadedModManager.RunningModsListForReading.Any(x => x.PackageId.ToLower() == "oskarpotocki.vfe.insectoid"))
            {
                harmony.Patch(AccessTools.Method(AccessTools.TypeByName("WorldGenStep_ResetHillinessForISettlement"), "GenerateFresh"), prefix: new HarmonyMethod(typeof(ConditionalHarmonyPatches), nameof(ConditionalHarmonyPatches.ResetHillinessForISettlement_Fix)));
            }
        }
    }


    public static class ConditionalHarmonyPatches
    {
        /// <summary>
        /// Fix for VE's own code
        /// Literally the only change is adding 'worldObject.Faction != null'
        /// The rest is exactly the same
        /// </summary>
        public static bool ResetHillinessForISettlement_Fix()
        {
            foreach (WorldObject worldObject in Find.World.worldObjects.AllWorldObjects)
            {
                bool flag = worldObject.Faction != null && worldObject.Faction.def.defName == "VFEI_Insect" && Find.WorldGrid[worldObject.Tile].hilliness != Hilliness.Mountainous;
                if (flag)
                {
                    Find.WorldGrid[worldObject.Tile].hilliness = Hilliness.Mountainous;
                }
            }
            return false;
        }
    }
}

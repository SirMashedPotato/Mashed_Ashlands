using HarmonyLib;
using Verse;
using System.Reflection;
using Outposts;
using VOE;
using System.Collections.Generic;
using System.Collections;

namespace Mashed_Ashlands_Outposts
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            Harmony harmony = new Harmony("com.Mashed_Ashlands_Outposts");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    /// <summary>
    /// Removes ashland plants from the list of possible plants.
    /// </summary>
    [HarmonyPatch(typeof(Outpost_Farming))]
    [HarmonyPatch("GetExtraOptions")]
    public static class Outpost_Farming_Options_Patch
    {
        [HarmonyPostfix]
        public static void Mashed_Ashlands_FarmingOutpost_Patch(ref IEnumerable<ResultOption> __result)
        {
            List<ResultOption> newResult = new List<ResultOption> { };
            foreach (ResultOption option in __result)
            {
                Log.Message(" - " + option.Thing + ", " + option.Thing.modContentPack.PackageId.ToLower());
                if (option.Thing.modContentPack.PackageId.ToLower() != "sirmashedpotato.ashlands")
                {
                    newResult.AddItem(option);
                }
            }
            IEnumerable<ResultOption> result = newResult;
            __result = result;
        }
    }
}

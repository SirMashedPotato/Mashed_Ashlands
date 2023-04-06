using HarmonyLib;
using Verse;
using System.Reflection;

namespace ESCP_NecromanticThralls
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.MorrowRimRemade");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}

using HarmonyLib;
using Verse;
using System.Reflection;

namespace MorrowRim2
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            Harmony harmony = new Harmony("com.MorrowRimRemade");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}

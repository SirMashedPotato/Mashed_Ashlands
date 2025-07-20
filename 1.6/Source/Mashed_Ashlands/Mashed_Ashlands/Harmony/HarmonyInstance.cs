using HarmonyLib;
using Verse;
using System.Reflection;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            Harmony harmony = new Harmony("com.Mashed_Ashlands");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            if (ModsConfig.BiotechActive)
            {
                harmony.Patch(AccessTools.Method(AccessTools.TypeByName("FertilityGrid"), "CalculateFertilityAt"), postfix: new HarmonyMethod(typeof(BiotechHarmonyPatches), nameof(BiotechHarmonyPatches.FertilityGrid_CalculateFertilityAt_Patch)));
                harmony.Patch(AccessTools.Method(AccessTools.TypeByName("PollutionUtility"), "StimulatedByPollution"), postfix: new HarmonyMethod(typeof(BiotechHarmonyPatches), nameof(BiotechHarmonyPatches.PollutionUtility_StimulatedByPollution_Patch)));
                harmony.Patch(AccessTools.Method(AccessTools.TypeByName("PollutionUtility"), "PawnPollutionTickInterval"), postfix: new HarmonyMethod(typeof(BiotechHarmonyPatches), nameof(BiotechHarmonyPatches.PollutionUtility_PawnPollutionTickInterval_Patch)));
            }

            if (ModsConfig.IsActive("sarg.rimbees"))
            {
                harmony.Patch(AccessTools.Method(AccessTools.TypeByName("Building_Beehouse"), "CheckRainLevels"), prefix: new HarmonyMethod(typeof(Compat_AlphaBees), nameof(Compat_AlphaBees.RimBees_Beehouse_AshStormPatch)));
            }

            ///Patching in support for SeedsPlease Lite, otherwise seeds are required to select plants, but never used when sowing them
            if (ModsConfig.IsActive("owlchemist.seedspleaselite") || ModsConfig.IsActive("evyatar108.seedspleaseliteredux"))
            {
                harmony.Patch(AccessTools.Method(typeof(WorkGiver_GrowerSowAsh), nameof(WorkGiver_GrowerSowAsh.JobOnCell)), postfix: new HarmonyMethod(AccessTools.Method(AccessTools.TypeByName("Patch_WorkGiver_GrowerSow_JobOnCell"), "Postfix")));
            }
        }
    }
}

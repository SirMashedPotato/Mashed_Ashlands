using HarmonyLib;
using RimWorld;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    /// <summary>
    /// Used Zombieland as a starting point, thanks Andreas Pardeike!
    /// Adds a new page during scenario setup, specifically for ashland world gen settings
    /// </summary>
    [HarmonyPatch(typeof(PageUtility))]
    [HarmonyPatch("StitchedPages")]
    public static class CreateWorldParams_DoWindowContents_Patch
    {
        //todo tutorial check?
        [HarmonyPrefix]
        public static void Patch(List<Page> pages)
        {
            if (Mashed_Ashlands_ModSettings.EnableSettingBeforeWorldGen)
            {
                pages.Insert(pages.FindIndex(x => x is Page_CreateWorldParams), new Page_AshlandWorldGenSettings());
            }
        }
    }
}

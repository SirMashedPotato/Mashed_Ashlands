using System;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public static class CliffRacerTrackerUtility
    {

        private static bool GetWorld(out World world)
        {
            world = Find.World;
            return world != null;
        }

        public static bool ExtinctionReached()
        {
            if (GetWorld(out World world))
            {
               return world.GetComponent<WorldComp_CliffRacerTracker>().Extinct;
            }
            return false;
        }

        public static void ModifyProgress(int change, Thing source = null)
        {
            if (GetWorld(out World world))
            {
                world.GetComponent<WorldComp_CliffRacerTracker>().ModifyProgress(change, source);
            }
        }
    }
}

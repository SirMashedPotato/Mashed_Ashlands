using System;
using Verse;
using RimWorld;

namespace Mashed_Ashlands
{
    public class Designator_ZoneAdd_GrowingAsh_Expand : Designator_ZoneAdd_GrowingAsh
    {
        public Designator_ZoneAdd_GrowingAsh_Expand()
        {
            defaultLabel = "DesignatorZoneExpand".Translate();
            hotKey = KeyBindingDefOf.Misc6;
        }
    }
}

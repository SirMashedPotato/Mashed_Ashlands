﻿using RimWorld;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class StatDefOf
    {
        static StatDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StatDefOf));
        }
        public static StatDef Mashed_Ashlands_AshResistance;
    }
}
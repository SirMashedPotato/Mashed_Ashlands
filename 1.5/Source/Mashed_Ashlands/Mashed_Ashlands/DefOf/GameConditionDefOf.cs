﻿using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    [DefOf]
    public static class GameConditionDefOf
    {
        static GameConditionDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(GameConditionDefOf));
        }
        public static GameConditionDef Mashed_Ashlands_AshStorm;
        public static GameConditionDef Mashed_Ashlands_VolcanicMiasma;
        public static GameConditionDef Mashed_Ashlands_PsychicEruption;
    }
}
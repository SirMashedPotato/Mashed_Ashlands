﻿using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace MorrowRim2
{
    /// <summary>
    /// Limit specific animals to tiles with specific landmarks
    /// </summary>
    [HarmonyPatch(typeof(WildAnimalSpawner))]
    [HarmonyPatch("CommonalityOfAnimalNow")]
    public static class WildAnimalSpawner_CommonalityOfAnimalNow_Patch
    {
        [HarmonyPostfix]
        public static void MorrowRim_CommonalityOfAnimalNow_Patch(PawnKindDef def, ref Map ___map, ref float __result)
        {
            if (true)   //potential mod setting, toggle
            {
                AnimalProperties props = AnimalProperties.Get(def.race);
                if (props != null)
                {
                    if (props.requireCaves && !Find.World.HasCaves(___map.Tile))
                    {
                        __result = 0;
                        return;
                    }
                    if (props.requireCoast && !Find.World.CoastDirectionAt(___map.Tile).IsValid)
                    {
                        __result = 0;
                        return;
                    }
                    if (props.requireHills && Find.WorldGrid[___map.Tile].hilliness == Hilliness.Flat)
                    {
                        __result = 0;
                        return;
                    }
                    if (props.requireRiver && Find.WorldGrid[___map.Tile].Rivers == null)
                    {
                        __result = 0;
                        return;
                    }
                }
            }
        }
    }
}
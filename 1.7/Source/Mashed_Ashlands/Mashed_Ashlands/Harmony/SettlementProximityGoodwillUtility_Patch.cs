using HarmonyLib;
using RimWorld.Planet;
using RimWorld.QuestGen;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// 
    /// </summary>
    [HarmonyPatch(typeof(SettlementProximityGoodwillUtility))]
    [HarmonyPatch("GetConfirmationDescriptions")]
    public static class SettlementProximityGoodwillUtility_GetConfirmationDescriptions_Patch
    {
        public static void Postfix(PlanetTile tile, ref IEnumerable<TaggedString> __result)
        {
            List<TaggedString> volcanoWarnings = new List<TaggedString>();
            foreach (WorldObject worldObject in WorldGenUtility.GetWorldVolcanosForLayer(tile.Layer))
            {
                if (worldObject.def == WorldObjectDefOf.Mashed_Ashlands_VolcanoExtinct)
                {
                    continue;
                }
                Volcano volcano = worldObject as Volcano;
                if (volcano.InAoE(tile, volcano.Category))
                {
                    TaggedString str = new TaggedString("Mashed_Ashlands_VolcanoSettleWarning".Translate(volcano, volcano.Category, volcano.def));

                    volcano.TryGetComponent(out WorldObjectComp_PermanentCondition comp);
                    if (comp != null)
                    {
                        str += "Mashed_Ashlands_VolcanoSettleWarning_ParmaCondition".Translate(comp.Props.volcanicConditionDef);
                    }

                    volcanoWarnings.Add(str);
                }
            }

            if (!volcanoWarnings.NullOrEmpty())
            {
                List<TaggedString> result = new List<TaggedString>();

                foreach(TaggedString str in __result)
                {
                    result.Add(str);
                }

                foreach (TaggedString str in volcanoWarnings)
                {
                    result.Add(str);
                }

                __result = result;
            }
        }
    }
}

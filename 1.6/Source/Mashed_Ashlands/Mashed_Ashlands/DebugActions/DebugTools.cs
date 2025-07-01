using Verse;
using RimWorld;
using LudeonTK;
using System.Collections.Generic;
using RimWorld.Planet;
using System.Linq;

namespace Mashed_Ashlands
{
    public class DebugTools
    {
        private const string Category = "Mashed's Ashlands";

        [DebugAction(
            category = Category,
            name = "Spawn volcano",
            allowedGameStates = AllowedGameStates.PlayingOnWorld,
            actionType = DebugActionType.ToolWorld
            )]
        private static List<DebugActionNode> SpawnVolcano()
        {
            List<DebugActionNode> list = new List<DebugActionNode>();
            foreach (WorldObjectDef volcanoDefs in DefDatabase<WorldObjectDef>.AllDefs.Where(x => x.worldObjectClass == typeof(Volcano)))
            {
                WorldObjectDef localDef = volcanoDefs;
                list.Add(new DebugActionNode(localDef.defName, DebugActionType.ToolWorld, delegate
                {
                    int num = GenWorld.MouseTile();
                    WorldObject worldObject = WorldObjectMaker.MakeWorldObject(localDef);
                    worldObject.Tile = num;
                    Find.WorldObjects.Add(worldObject);
                }));
            }
            return list;
        }

        [DebugAction(
            category = Category,
            name = "Generate primary Ashland biomes",
            allowedGameStates = AllowedGameStates.PlayingOnWorld,
            actionType = DebugActionType.Action
            )]
        private static void GeneratePrimaryBiomes()
        {
            WorldGenStep_AshlandBiomesEarly.DebugGenerate(Find.World.info.seedString, PlanetLayer.Selected);
            Find.World.renderer.RegenerateAllLayersNow();
        }

        [DebugAction(
            category = Category,
            name = "Generate secondary Ashland biomes",
            allowedGameStates = AllowedGameStates.PlayingOnWorld,
            actionType = DebugActionType.Action
            )]
        private static void GenerateSecondaryBiomes()
        {
            WorldGenStep_AshlandBiomesLate.DebugGenerate(Find.World.info.seedString, PlanetLayer.Selected);
            Find.World.renderer.RegenerateAllLayersNow();
        }
    }
}

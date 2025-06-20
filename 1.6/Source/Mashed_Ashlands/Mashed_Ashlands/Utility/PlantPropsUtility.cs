using Verse;

namespace Mashed_Ashlands
{
    public static class PlantPropsUtility
    {
        public static bool WildPlantSpawnChecker(PlantProperties props, Map map, IntVec3 c)
        {
            TerrainDef terrainDef = c.GetTerrain(map);
            if ((!props.allowedTerrainForWild.NullOrEmpty() && !props.allowedTerrainForWild.Contains(terrainDef))
                || !props.disallowedTerrainForWild.NullOrEmpty() && props.disallowedTerrainForWild.Contains(terrainDef))
            {
                return false;
            }
            else
            {
                if (props.requireWaterForWild)
                {
                    bool waterFlag = false;
                    foreach (IntVec3 neighbour in GenAdj.CellsAdjacent8Way(c, Rot4.North, new IntVec2(props.minTilesToWaterForWild, props.minTilesToWaterForWild)))
                    {
                        if (neighbour.InBounds(map))
                        {
                            TerrainDef neighbourTerrain = neighbour.GetTerrain(map);
                            if (neighbourTerrain != null && neighbourTerrain.IsWater)
                            {
                                waterFlag = true;
                                break;
                            }
                        }
                    }
                    if (!waterFlag)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

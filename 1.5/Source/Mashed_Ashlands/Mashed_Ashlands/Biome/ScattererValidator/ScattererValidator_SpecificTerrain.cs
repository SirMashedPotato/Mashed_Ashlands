using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class ScattererValidator_SpecificTerrain : ScattererValidator
    {
        public override bool Allows(IntVec3 c, Map map)
        {
            if (!terrainDefs.NullOrEmpty())
            {
                return terrainDefs.Contains(c.GetTerrain(map));
            }
            return true;
        }

        public List<TerrainDef> terrainDefs;
    }
}

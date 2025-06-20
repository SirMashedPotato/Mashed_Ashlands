using System.Linq;
using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_ColumnarBasalt : GenStep
    {
		public override int SeedPart => 1568957891;

        public override void Generate(Map map, GenStepParams parms)
        {
            if (Mashed_Ashlands_ModSettings.EnableColumnarBasalt)
            {
                if (!map.IsPocketMap && Find.World.NaturalRockTypesIn(map.Tile).Contains(ThingDefOf.Mashed_Ashlands_Basalt))
                {
                    foreach (IntVec3 cell in map.AllCells)
                    {
                        if (map.thingGrid.ThingAt(cell, ThingDefOf.Mashed_Ashlands_Basalt) != null && cell.UsesOutdoorTemperature(map))
                        {
                            GenSpawn.Spawn(ThingDefOf.Mashed_Ashlands_ColumnarBasalt, cell, map, WipeMode.Vanish);
                        }
                    }
                }
            }
        }
    }
}

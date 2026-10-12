using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_ScatterLumpsShallow : GenStep_ScatterLumpsMineable
    {
        protected override bool CanScatterAt(IntVec3 c, Map map)
        {
            if (base.CanScatterAt(c, map))
            {
                foreach (IntVec3 neighbourCell in GenAdj.CellsAdjacentCardinal(c, Rot4.North, IntVec2.One))
                {
                    if (neighbourCell.InBounds(map))
                    {
                        if (neighbourCell.GetEdifice(map) == null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}

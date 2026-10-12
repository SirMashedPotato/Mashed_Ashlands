using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class Spawner_CollapsingRockRoof : GroundSpawner
    {
        protected override IntRange ResultSpawnDelay => new IntRange(100, 300);

        protected override SoundDef SustainerSound => null;

        protected override void Spawn(Map map, IntVec3 loc)
        {
            RoofCollapserImmediate.DropRoofInCells(loc, map);
        }
    }
}

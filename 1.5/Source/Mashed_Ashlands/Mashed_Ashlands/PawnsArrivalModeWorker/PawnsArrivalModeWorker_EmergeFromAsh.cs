using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Mashed_Ashlands
{
    /// <summary>
    /// I'm going to be honest here
    /// This was copy pasted from PawnsArrivalModeWorker_EmergeFromWater
    /// I do not understand a decent chunk of this
    /// </summary>
    public class PawnsArrivalModeWorker_EmergeFromAsh : PawnsArrivalModeWorker
    {
        private const int AshAreaThreshold = 50;
        private const float MaxSpawnRadius = 30f;
        ///This is the length of time the spawns are spread over
        private const float SpawnDurationSeconds = 16f;
        public static readonly FloatRange StunRange = new FloatRange(2f, 4f);
        private static readonly HashSet<IntVec3> AshAreaCells = new HashSet<IntVec3>();
        public const int SpawnDelayTicks = 40;

        private bool IsBigSpawn(Pawn pawn) => pawn.BodySize > 1.5f;

        private bool IsValidTerrain(TerrainDef terrainDef) => !terrainDef.tags.NullOrEmpty() && terrainDef.tags.Contains("Mashed_Ashlands_Ash");

        public override bool CanUseWith(IncidentParms parms)
        {
            if (!Mashed_Ashlands_ModSettings.EnableAshRaids)
            {
                return false;
            }
            Map map = (Map)parms.target;
            if (map == null)
            {
                return false;
            }
            BiomeProperties props = BiomeProperties.Get(map.Biome);
            if (props == null || !props.allowAshRaids)
            {
                return false;
            }

            return base.CanUseWith(parms);
        }

        public override void Arrive(List<Pawn> pawns, IncidentParms parms)
        {
            if (!pawns.Empty())
            {
                List<IntVec3> list = new List<IntVec3>();
                List<IntVec3> list2 = new List<IntVec3>();
                for (int i = 0; i < pawns.Count; i++)
                {
                    IntVec3 item = AshAreaCells.RandomElement();
                    AshAreaCells.Remove(item);
                    (IsBigSpawn(pawns[i]) ? list2 : list).Add(item);
                    pawns[i].stances.stunner.StunFor(StunRange.RandomInRangeSeeded(pawns[i].ThingID.GetHashCode()).SecondsToTicks(), pawns[i], addBattleLog: true, showMote: false);
                }
                float num = SpawnDurationSeconds / pawns.Count;
                SpawnRequest spawnRequest = new SpawnRequest(pawns.Where((Pawn p) => !IsBigSpawn(p)).Cast<Thing>().ToList(), list, 1, num);
                SpawnRequest spawnRequest2 = new SpawnRequest(pawns.Where((Pawn p) => IsBigSpawn(p)).Cast<Thing>().ToList(), list2, 1, num * 2.7f);
                spawnRequest.spawnSound = RimWorld.SoundDefOf.Roof_Collapse;
                spawnRequest.spawnEffect = EffecterDefOf.Mashed_Ashlands_EmergeFromAsh;
                spawnRequest.preSpawnEffect = EffecterDefOf.Mashed_Ashlands_AshCloud;
                spawnRequest.preSpawnEffecterOffsetTicks = -1000;
                spawnRequest.initialDelay = SpawnDelayTicks;
                spawnRequest.lord = parms.lord;
                spawnRequest2.spawnSound = RimWorld.SoundDefOf.Roof_Collapse;
                spawnRequest2.spawnEffect = EffecterDefOf.Mashed_Ashlands_EmergeFromAshLarge;
                spawnRequest2.preSpawnEffect = EffecterDefOf.Mashed_Ashlands_AshCloud;
                spawnRequest2.preSpawnEffecterOffsetTicks = -1000;
                spawnRequest2.initialDelay = SpawnDelayTicks;
                spawnRequest2.lord = parms.lord;
                Find.CurrentMap.deferredSpawner.AddRequest(spawnRequest);
                Find.CurrentMap.deferredSpawner.AddRequest(spawnRequest2);
            }
        }

        public override bool TryResolveRaidSpawnCenter(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            int num = 20;
            while (true)
            {
                if (!(parms.spawnCenter == IntVec3.Invalid) || num <= 0)
                {
                    break;
                }
                AshAreaCells.Clear();
                parms.spawnCenter = CellFinderLoose.RandomCellWith((IntVec3 cell) => IsValidTerrain(cell.GetTerrain(map)) && cell.Walkable(map) && map.reachability.CanReachColony(cell), map);
                if (parms.spawnCenter != IntVec3.Invalid)
                {
                    map.floodFiller.FloodFill(parms.spawnCenter, (IntVec3 cell) => IsValidTerrain(cell.GetTerrain(map)) && cell.Walkable(map) && cell.InHorDistOf(parms.spawnCenter, MaxSpawnRadius), delegate (IntVec3 cell)
                    {
                        AshAreaCells.Add(cell);
                    });
                    if (AshAreaCells.Count > AshAreaThreshold)
                    {
                        return true;
                    }
                }
                num--;
            }
            return false;
        }
    }
}

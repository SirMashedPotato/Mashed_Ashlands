using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace MorrowRim2
{
    public class BiomeWorker_VolcanicCoralCoastAshlands : AshlandBiomeWorker
    {
        /// <summary>
        /// Only here to prevent gen through standard methods
        /// Possibly add in alternative gen, with setting to disable volcano based gen
        /// </summary>
        public override float GetScore(Tile tile, int tileID)
        {
            if (MorrowRim_ModSettings.OldBiomeGen)
            {

            }

            return 0;
        }

        public override float GetScore_Main(Tile tile, int tileID)
        {
            if (!MorrowRim_ModSettings.EnableVolcanicCoralCoastAshlands)
            {
                return -100f;
            }
            if (tile.biome != BiomeDefOf.MorrowRim_VolcanicAshlands)
            {
                return -100f;
            }
            int numberCoastalTiles = 0;
            List<int> neighbourTiles = new List<int>();
            Find.WorldGrid.GetTileNeighbors(tileID, neighbourTiles);
            foreach (int neighbourID in neighbourTiles)
            {
                Tile neighbourTile = Find.WorldGrid.tiles[neighbourID];
                if (neighbourTile != null)
                {
                    if (neighbourTile.WaterCovered || neighbourTile.biome == BiomeDefOf.MorrowRim_VolcanicCoralCoastAshlands)
                    {
                        numberCoastalTiles++;
                    }
                }
            }
            if (numberCoastalTiles < 2)
            {
                return 0;
            }
            return Rand.Range(12, 18) + numberCoastalTiles;
        }
    }
}

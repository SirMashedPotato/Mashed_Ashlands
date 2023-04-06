using RimWorld;
using RimWorld.Planet;

namespace MorrowRim2
{
    public abstract class AshlandBiomeWorker : BiomeWorker
    {
        public abstract float GetScore_Main(Tile tile, int tileID);
    }
}

using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;

namespace Mashed_Ashlands
{
    /// <summary>
    /// TODO switch to using this in 1.6
    /// </summary>
    public abstract class CaravanVolcanicEventWorker
    {
        public abstract void CaravanEventWorker(Volcano parentVolcano, int category, List<Caravan> targets);

        public virtual IEnumerable<string> ConfigErrors()
        {
            return Enumerable.Empty<string>();
        }
    }
}

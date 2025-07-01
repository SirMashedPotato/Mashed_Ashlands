using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;

namespace Mashed_Ashlands
{
    public abstract class CaravanVolcanicEventWorker
    {
        public abstract void CaravanEventWorker(Volcano parentVolcano, List<Caravan> targets);

        public virtual IEnumerable<string> ConfigErrors()
        {
            return Enumerable.Empty<string>();
        }
    }
}

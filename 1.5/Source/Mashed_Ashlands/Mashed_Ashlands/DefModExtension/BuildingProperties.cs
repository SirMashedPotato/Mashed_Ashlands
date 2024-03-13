using Verse;

namespace Mashed_Ashlands
{
    public class BuildingProperties : DefModExtension
    {
        public bool canBeMeteorite = true;

        public static BuildingProperties Get(Def def)
        {
            return def.GetModExtension<BuildingProperties>();
        }
    }
}

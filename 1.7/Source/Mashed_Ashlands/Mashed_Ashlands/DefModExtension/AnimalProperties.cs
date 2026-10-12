using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class AnimalProperties : DefModExtension
    {
        public bool glowOverlay = false;
        public List<AbilityDef> randomAbility;

        public static AnimalProperties Get(Def def) => def.GetModExtension<AnimalProperties>();
    }
}

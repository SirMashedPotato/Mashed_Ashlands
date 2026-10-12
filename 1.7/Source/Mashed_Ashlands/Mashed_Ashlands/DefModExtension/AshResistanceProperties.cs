using Verse;

namespace Mashed_Ashlands
{
    class AshResistanceProperties : DefModExtension
    {
        public bool treatAsMechanical = false;
        public bool immuneToAshBlinding = false;
        public bool buildingImmuneToBreakDowns = false;
        public bool buildingTakesDamage = false;
        public float avgDamageTaken = 5;
        public float chanceDamaged = 0.5f;

        public static AshResistanceProperties Get(Def def) => def.GetModExtension<AshResistanceProperties>();
    }
}

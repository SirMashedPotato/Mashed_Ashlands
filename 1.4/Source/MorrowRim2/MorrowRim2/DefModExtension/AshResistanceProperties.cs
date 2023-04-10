using Verse;

namespace MorrowRim2
{
    class AshResistanceProperties : DefModExtension
    {
        public bool treatAsMechanical = false;
        public bool immuneToAshBlinding = false;
        public bool buildingTakesDamage = false;
        public float avgDamageTaken = 5;
        public float chanceDamaged = 0.5f;

        public static AshResistanceProperties Get(Def def)
        {
            return def.GetModExtension<AshResistanceProperties>();
        }
    }
}

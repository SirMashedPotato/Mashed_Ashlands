﻿using Verse;

namespace MorrowRim2
{
    class AshResistanceProperties : DefModExtension
    {
        public bool treatAsMechanical = false;

        public static AshResistanceProperties Get(Def def)
        {
            return def.GetModExtension<AshResistanceProperties>();
        }
    }
}
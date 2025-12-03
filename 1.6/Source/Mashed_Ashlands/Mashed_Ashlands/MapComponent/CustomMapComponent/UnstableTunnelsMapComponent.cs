using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class UnstableTunnelsMapComponent : DangerousTunnelsMapComponent
    {
        private static IntRange caveInCountRange = new IntRange(1,3);
        private static IntRange caveInSizeRange = new IntRange(10, 20);

        public UnstableTunnelsMapComponent(Map map) : base(map) 
        { 

        }

        public override void TriggerInstabilityEffect()
        {
            Messages.Message("Mashed_Ashlands_Undercave_CaveIn".Translate(mineEntrance.UndercaveTypeDef), mineExit, MessageTypeDefOf.NegativeEvent);

            int caveInTarget = caveInCountRange.RandomInRange;
            for (int i = 0; i < caveInTarget; i++)
            {
                int caveInSize = caveInSizeRange.RandomInRange;
                CellFinder.TryFindRandomCell(map, c => Utility.CaveInCellValidator(map, c), out IntVec3 result);
                if (result.IsValid)
                {
                    List<IntVec3> caveIn = GridShapeMaker.IrregularLump(result, map, caveInSize, c => Utility.CaveInCellValidator(map, c));
                    foreach (IntVec3 cell in caveIn)
                    {
                        GenSpawn.Spawn(ThingDefOf.Mashed_Ashlands_CollapsingRockRoof, cell, map, WipeMode.FullRefund);
                    }
                }
            }
        }
    }
}

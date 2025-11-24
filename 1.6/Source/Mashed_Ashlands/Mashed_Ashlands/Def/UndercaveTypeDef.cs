using System.Collections.Generic;
using Verse;

namespace Mashed_Ashlands
{
    public class UndercaveTypeDef : Def
    {
        public MapGeneratorDef undercaveGeneratorDef;
        public List<GenStepDef> extraGenStepDefs;
        public int weight = 1;
        public bool naturallyGenerates = true;


        public override IEnumerable<string> ConfigErrors()
        {
            foreach (string item in base.ConfigErrors())
            {
                yield return item;
            }

            if (undercaveGeneratorDef == null)
            {
                yield return "undercaveGeneratorDef is null";
            }
        }
    }
}

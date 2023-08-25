using Verse;

namespace Mashed_Ashlands
{
    public class GenStep_ScatterFetcherflyHives : GenStep_ScatterBiomeSpecific
    {
        public override void Generate(Map map, GenStepParams parms)
        {
            if (Mashed_Ashlands_ModSettings.EnableFetcherflyHives)
            {
                base.Generate(map, parms);
            }
        }
    }
}

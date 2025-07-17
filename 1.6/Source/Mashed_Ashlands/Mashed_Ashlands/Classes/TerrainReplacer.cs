using System.Xml;
using Verse;

namespace Mashed_Ashlands
{
    public class TerrainReplacer
    {
        public TerrainDef originalTerrain;
        public TerrainDef replacedTerrain;

        public void LoadDataFromXmlCustom(XmlNode xmlRoot)
        {
            DirectXmlCrossRefLoader.RegisterObjectWantsCrossRef(this, "originalTerrain", xmlRoot);
            DirectXmlCrossRefLoader.RegisterObjectWantsCrossRef(this, "replacedTerrain", xmlRoot.InnerText);
        }
    }
}

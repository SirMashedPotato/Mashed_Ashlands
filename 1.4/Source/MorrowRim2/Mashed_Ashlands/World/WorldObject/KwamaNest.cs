using Verse;
using RimWorld.Planet;

namespace Mashed_Ashlands
{
    public class KwamaNest : WorldObject
    {
        public override bool HasName => nameInt != null;

        public string Name
        {
            get
            {
                return nameInt;
            }
            set
            {
                nameInt = value;
            }
        }

        public int NestSize
        {
            get
            {
                return kwamaNestSize;
            }
            set
            {
                kwamaNestSize = value;
            }
        }

        public override string Label
        {
            get
            {
                if (HasName)
                {
                    return nameInt;
                }
                return base.Label;
            }
        }

        public int EffectRadiusFor(int kwamaNestSize)
        {
            if (kwamaNestSize > 0)
            {
                int maxDistance = Mashed_Ashlands_ModSettings.VolcanoMaxAffectedArea;
                if (Mashed_Ashlands_ModSettings.VolcanoAffectedAreaScaleWithWorldSize)
                {
                    maxDistance = (int)(maxDistance * ((Find.World.PlanetCoverage * 3) + 0.1f));
                    if (maxDistance < 1)
                    {
                        maxDistance = 1;
                    }
                }
                return (int)(kwamaNestSize * 0.2f * maxDistance);
            }
            return -1;
        }

        public override void SpawnSetup()
        {
            base.SpawnSetup();
        }

        public override bool AllMatchingObjectsOnScreenMatchesWith(WorldObject other)
        {
            return def == other.def;
        }

        public override void ExposeData()
        {
            base.ExposeData();
            if (HasName)
            {
                Scribe_Values.Look(ref nameInt, "name", null);
            }
            Scribe_Values.Look(ref kwamaNestSize, "nestSize", 1);
        }

        private string nameInt = null;
        private int kwamaNestSize = 1;
    }
}

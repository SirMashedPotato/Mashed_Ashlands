using Verse;
using RimWorld.Planet;

namespace MorrowRim2
{
    public class Volcano : WorldObject
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

        public float Category
        {
            get
            {
                return volcanoCategory;
            }
            set
            {
                volcanoCategory = value;
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

        public override void SpawnSetup()
        {
            base.SpawnSetup();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            if (HasName)
            {
                Scribe_Values.Look(ref nameInt, "name", null);
            }
            Scribe_Values.Look(ref volcanoCategory, "category", 1);
        }

        private string nameInt = null;
        private float volcanoCategory = 1;
    }
}

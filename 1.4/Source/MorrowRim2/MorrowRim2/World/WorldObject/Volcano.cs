﻿using Verse;
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

        public int MaximumEffectRadius
        {
            get
            {
                if (volcanoCategory > 0)
                {
                    int maxDistance = MorrowRim_ModSettings.VolcanoMaxAffectedArea;
                    if (MorrowRim_ModSettings.BiomeScaleWithWorldSize)
                    {
                        maxDistance = (int)(maxDistance * ((Find.World.PlanetCoverage * 3) + 0.1f));
                        if (maxDistance < 10)
                        {
                            maxDistance = 10;
                        }
                    }
                    return (int)((volcanoCategory * 0.2f) * maxDistance);
                }
                return -1;
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
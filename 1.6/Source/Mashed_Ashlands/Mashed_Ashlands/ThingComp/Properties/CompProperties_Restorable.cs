using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_Restorable : CompProperties
    {
        public float restoreAmount;
        public SkillDef requiredSkillDef;
        public int requiredSkillLevel;
        public EffecterDef effectRestoring;
        public SoundDef restorationCompletedSound;
        [MustTranslate]
        public string notRestoredInspectString;

        public CompProperties_Restorable() => compClass = typeof(Comp_Restorable);
    }
}

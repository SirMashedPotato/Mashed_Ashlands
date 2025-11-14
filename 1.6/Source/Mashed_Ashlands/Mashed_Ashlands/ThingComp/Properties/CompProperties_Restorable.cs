using Verse;

namespace Mashed_Ashlands
{
    public class CompProperties_Restorable : CompProperties
    {
        public float restoreAmount;
        public int constructionSkillPrerequisite;
        public EffecterDef effectRestoring;
        public SoundDef restorationCompletedSound;
        [MustTranslate]
        public string notRestoredInspectString;
        [MustTranslate]
        public string restoredMessage;

        public CompProperties_Restorable() => compClass = typeof(Comp_Restorable);
    }
}

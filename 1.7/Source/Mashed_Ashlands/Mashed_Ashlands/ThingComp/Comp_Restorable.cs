using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class Comp_Restorable : ThingComp
    {
        private float restoreProgress = 0;
        private bool restored = false;
        private static readonly Texture2D MarkForRestorationTexture = ContentFinder<Texture2D>.Get("UI/Designators/Mashed_Ashlands_Restore");

        public float ProgressPercent => restoreProgress / Props.restoreAmount;

        public bool IsRestored => restored;

        public bool IsMarked => parent.Map.designationManager.DesignationOn(parent, DesignationDefOf.Mashed_Ashlands_Restore) != null;

        public CompProperties_Restorable Props => (CompProperties_Restorable)props;

        public void ProgressRestoration(float repairAmount)
        {
            restoreProgress += repairAmount;
            if (restoreProgress >= Props.restoreAmount)
            {
                CompleteRestoration();
            }
        }

        private void CompleteRestoration()
        {
            if (restored)
            {
                return;
            }

            restored = true;
            Messages.Message("Mashed_Ashlands_RestorationComplete".Translate(parent), parent, MessageTypeDefOf.PositiveEvent);
            parent.Map.designationManager.TryRemoveDesignationOn(parent, DesignationDefOf.Mashed_Ashlands_Restore);

            if (parent.Spawned)
            {
                parent.DirtyMapMesh(parent.Map);
            }

        }

        public AcceptanceReport CanRestoreNow(Pawn pawn)
        {
            if (IsRestored)
            {
                return false;
            }

            if (!IsMarked)
            {
                return false;
            }

            if (!pawn.CanReach(parent, PathEndMode.ClosestTouch, Danger.Deadly))
            {
                return "NoPath".Translate().CapitalizeFirst();
            }

            if (pawn.skills == null || (Props.requiredSkillDef !=  null && pawn.skills.GetSkill(Props.requiredSkillDef).TotallyDisabled))
            {
                return "IncapableOfCapacity".Translate(Props.requiredSkillDef.label);
            }

            if (Props.requiredSkillDef != null && pawn.skills.GetSkill(Props.requiredSkillDef).Level < Props.requiredSkillLevel)
            {
                return "SkillTooLow".Translate(Props.requiredSkillDef.label, pawn.skills.GetSkill(Props.requiredSkillDef).Level, Props.requiredSkillLevel);
            }

            return true;
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref restoreProgress, "restoreProgress", 0f);
            Scribe_Values.Look(ref restored, "restored", false);
        }

        public override string CompInspectStringExtra()
        {
            if (!IsRestored)
            {
                string inspectString = "";
                inspectString += Props.notRestoredInspectString;
                if (Props.requiredSkillDef != null)
                {
                    inspectString += "\n" + "Mashed_Ashlands_RestorationRequirement".Translate(Props.requiredSkillDef.LabelCap, Props.requiredSkillLevel);
                }
                inspectString += "\n" + "Mashed_Ashlands_RestorationProgress".Translate(ProgressPercent.ToStringPercent());
                return inspectString;
            }
            return base.CompInspectStringExtra();
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            foreach (Gizmo gizmo in base.CompGetGizmosExtra())
            {
                yield return gizmo;
            }

            if (!IsRestored)
            {
                yield return new Command_Action
                {
                    defaultLabel = "Mashed_Ashlands_MarkForRestoration_Label".Translate(),
                    defaultDesc = "Mashed_Ashlands_MarkForRestoration_Description".Translate(parent),
                    icon = MarkForRestorationTexture,
                    hotKey = KeyBindingDefOf.Misc3,
                    Disabled = IsMarked,
                    action = delegate
                    {
                        parent.Map.designationManager.AddDesignation(new Designation(parent, DesignationDefOf.Mashed_Ashlands_Restore));
                    }
                };

                if (DebugSettings.ShowDevGizmos)
                {
                    yield return new Command_Action
                    {
                        defaultLabel = "DEV: Complete restoration",
                        action = delegate
                        {
                            CompleteRestoration();
                        }
                    };
                }
            }
        }
    }
}

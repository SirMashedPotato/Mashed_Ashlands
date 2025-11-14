using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Mashed_Ashlands
{
    [StaticConstructorOnStartup]
    public class Comp_Restorable : ThingComp
    {
        private float restoreProgress = 0;
        private bool restored = false;
        private bool markedForRestoration = false;
        private static readonly Texture2D MarkForRestoration = ContentFinder<Texture2D>.Get("UI/Designators/Mine");
        private static readonly Texture2D ForceRestoreTexture = ContentFinder<Texture2D>.Get("UI/Designators/Mine");

        public float ProgressPercent => restoreProgress / Props.restoreAmount;

        public bool IsRestored => restored;

        public CompProperties_Restorable Props => (CompProperties_Restorable)props;

        public void RepairNow(float repairAmount)
        {
            restoreProgress += repairAmount;
            if (restoreProgress >= Props.restoreAmount)
            {
                CompleteRepair();
            }
        }

        private void CompleteRepair()
        {
            if (restored)
            {
                return;
            }

            restored = true;
            Messages.Message(Props.restoredMessage.Translate(parent), parent, MessageTypeDefOf.PositiveEvent);

            if (parent.Spawned)
            {
                parent.DirtyMapMesh(parent.Map);
            }

        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref restoreProgress, "restoreProgress", 0f);
            Scribe_Values.Look(ref restored, "restored", false);
            Scribe_Values.Look(ref markedForRestoration, "markedForRestoration", false);
        }

        public override string CompInspectStringExtra()
        {
            if (!IsRestored)
            {
                return Props.notRestoredInspectString;
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
                if (DebugSettings.ShowDevGizmos)
                {
                    yield return new Command_Action
                    {
                        defaultLabel = "DEV: Complete restoration",
                        action = delegate
                        {
                            CompleteRepair();
                        }
                    };
                }
            }
        }
    }
}

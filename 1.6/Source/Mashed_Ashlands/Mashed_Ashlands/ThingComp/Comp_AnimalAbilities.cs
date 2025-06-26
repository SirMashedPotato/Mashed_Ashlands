using Verse;
using RimWorld;
using System.Collections.Generic;

namespace Mashed_Ashlands
{
    public class Comp_AnimalAbilities : ThingComp
    {
        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            if (!ModsConfig.IsActive("oskarpotocki.vanillafactionsexpanded.core")) //TODO ???
            {
                foreach (Gizmo gizmo in base.CompGetGizmosExtra())
                {
                    yield return gizmo;
                }

                Pawn pawn = parent as Pawn;
                if (pawn.Faction != null && pawn.Faction == Faction.OfPlayer)
                {
                    foreach (Ability ability in pawn.abilities.abilities)
                    {
                        foreach (Gizmo gizmo in ability.GetGizmos())
                        {
                            yield return gizmo;
                        }
                    }
                }
            }
        }
    }
}

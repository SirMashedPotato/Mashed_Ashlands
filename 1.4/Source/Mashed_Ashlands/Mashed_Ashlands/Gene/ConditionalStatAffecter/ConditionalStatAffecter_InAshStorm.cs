using RimWorld;
using Verse;

namespace Mashed_Ashlands
{
    public class ConditionalStatAffecter_InAshStorm : ConditionalStatAffecter
    {
		public override string Label => "Mashed_Ashlands_StatsReport_InAshStorm".Translate();

		public override bool Applies(StatRequest req)
		{
			return ModsConfig.BiotechActive && req.HasThing && req.Thing.Spawned && !req.Thing.Position.Roofed(req.Thing.Map) && Utility.MapHasAshStorm(req.Thing.Map);
		}
	}
}

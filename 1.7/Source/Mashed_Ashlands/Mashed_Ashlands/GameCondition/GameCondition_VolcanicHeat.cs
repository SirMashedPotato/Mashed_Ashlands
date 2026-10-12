using RimWorld;

namespace Mashed_Ashlands
{
    public class GameCondition_VolcanicHeat : GameCondition
	{
		public override int TransitionTicks => 5000;

		public override float TemperatureOffset()
		{
			return GameConditionUtility.LerpInOutValue(this, TransitionTicks, MaxTempOffset);
		}

		private const float MaxTempOffset = 15f;
	}
}

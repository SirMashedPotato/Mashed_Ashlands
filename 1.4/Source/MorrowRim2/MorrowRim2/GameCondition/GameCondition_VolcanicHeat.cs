using RimWorld;

namespace MorrowRim2
{
    public class GameCondition_VolcanicHeat : GameCondition
	{
		public override int TransitionTicks
		{
			get
			{
				return 5000;
			}
		}

		public override float TemperatureOffset()
		{
			return GameConditionUtility.LerpInOutValue(this, TransitionTicks, MaxTempOffset);
		}

		private const float MaxTempOffset = 15f;
	}
}

using RimWorld;

namespace MorrowRim2
{
    public class GameCondition_DenseAshClouds : GameCondition_VolcanicWinter
	{
		public override int TransitionTicks
		{
			get
			{
				return 5000;
			}
		}
	}
}

using RimWorld;

namespace Mashed_Ashlands
{
    public class CompProperties_EffecterAtNight : CompProperties_Effecter
	{
		public CompProperties_EffecterAtNight() => compClass = typeof(Comp_EffecterExtendedAtNight);

		public int tickInterval = 3;
	}
}

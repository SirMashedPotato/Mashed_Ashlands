using System.Collections.Generic;
using UnityEngine;

namespace Mashed_Ashlands
{
    public static class ZoneUtility
	{
		static ZoneUtility()
		{
			foreach (Color color in GrowingZoneAshColors())
			{
				Color item = new Color(color.r, color.g, color.b, 0.09f);
				growingZoneAshColors.Add(item);
			}
		}

		public static Color NextGrowingZoneAshColor()
		{
			Color result = growingZoneAshColors[nextGrowingZoneAshColorIndex];
			nextGrowingZoneAshColorIndex++;
			if (nextGrowingZoneAshColorIndex >= growingZoneAshColors.Count)
			{
				nextGrowingZoneAshColorIndex = 0;
			}
			return result;
		}

		private static IEnumerable<Color> GrowingZoneAshColors()
		{
			yield return Color.Lerp(new Color(1f, 0.5f, 0f), Color.grey, 0.5f);
			yield return Color.Lerp(new Color(1f, 0.7f, 0f), Color.grey, 0.5f);
			yield return Color.Lerp(new Color(1f, 0.7f, 0.5f), Color.grey, 0.5f);
			yield return Color.Lerp(new Color(1f, 0.7f, 0.3f), Color.grey, 0.5f);
			yield return Color.Lerp(new Color(1f, 1f, 0.7f), Color.grey, 0.5f);
			yield break;
		}
		private static List<Color> growingZoneAshColors = new List<Color>();
		private static int nextGrowingZoneAshColorIndex = 0;
	}
}

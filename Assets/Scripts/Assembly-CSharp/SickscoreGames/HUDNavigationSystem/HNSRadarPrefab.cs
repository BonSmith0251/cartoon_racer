using UnityEngine;
using UnityEngine.UI;

namespace SickscoreGames.HUDNavigationSystem
{
	[AddComponentMenu("HUD Navigation System/HNS Radar Prefab")]
	public class HNSRadarPrefab : HNSPrefab
	{
		[Tooltip("Assign an image component.")]
		[Header("Icon")]
		public Image Icon;

		[Tooltip("Assign the above arrow image component.")]
		[Header("Height Arrows")]
		public Image ArrowAbove;

		[Tooltip("Assign the above arrow image component.")]
		public Image ArrowBelow;

		public override void ChangeIconColor(Color color)
		{
			base.ChangeIconColor(color);
			if (Icon != null)
			{
				Icon.color = color;
			}
		}
	}
}

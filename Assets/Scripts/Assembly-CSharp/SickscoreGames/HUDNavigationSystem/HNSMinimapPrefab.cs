using UnityEngine;
using UnityEngine.UI;

namespace SickscoreGames.HUDNavigationSystem
{
	[AddComponentMenu("HUD Navigation System/HNS Minimap Prefab")]
	public class HNSMinimapPrefab : HNSPrefab
	{
		[Header("Icon")]
		[Tooltip("Assign an image component.")]
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

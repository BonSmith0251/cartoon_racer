using UnityEngine;
using UnityEngine.UI;

namespace SickscoreGames.HUDNavigationSystem
{
	[AddComponentMenu("HUD Navigation System/HNS Indicator Prefab")]
	public class HNSIndicatorPrefab : HNSPrefab
	{
		[Tooltip("Assign the transform for the onscreen marker.")]
		[Header("Onscreen")]
		public RectTransform OnscreenRect;

		[Tooltip("Assign an onscreen image component.")]
		public Image OnscreenIcon;

		[Header("Offscreen")]
		[Tooltip("Assign the transform for the offscreen marker.")]
		public RectTransform OffscreenRect;

		[Tooltip("Assign the transform which should rotate towards the offscreen element.")]
		public RectTransform OffscreenPointer;

		[Tooltip("Assign an offscreen image component.")]
		public Image OffscreenIcon;

		[Tooltip("(optional) Assign an onscreen distance text component.")]
		[Header("Distance Text")]
		public Text OnscreenDistanceText;

		[Tooltip("(optional) Assign an offscreen distance text component.")]
		public Text OffscreenDistanceText;

		public void ChangeOffscreenIconColor(Color color)
		{
			if (OffscreenIcon != null)
			{
				OffscreenIcon.color = color;
			}
		}

		public override void ChangeIconColor(Color color)
		{
			base.ChangeIconColor(color);
			if (OnscreenIcon != null)
			{
				OnscreenIcon.color = color;
			}
		}
	}
}

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SickscoreGames.HUDNavigationSystem
{
	[DisallowMultipleComponent]
	[AddComponentMenu("HUD Navigation System/HUD Navigation Canvas")]
	public class HUDNavigationCanvas : MonoBehaviour
	{
		[Serializable]
		public class _RadarReferences
		{
			public RectTransform Panel;

			public RectTransform Radar;

			public RectTransform PlayerIndicator;

			public RectTransform ElementContainer;
		}

		[Serializable]
		public class _CompassBarReferences
		{
			public RectTransform Panel;

			public RawImage Compass;

			public RectTransform ElementContainer;
		}

		[Serializable]
		public class _IndicatorReferences
		{
			public RectTransform Panel;

			public RectTransform ElementContainer;
		}

		[Serializable]
		public class _MinimapReferences
		{
			public RectTransform Panel;

			public RectTransform MapContainer;

			public RectTransform PlayerIndicator;

			public RectTransform ElementContainer;
		}

		private static HUDNavigationCanvas _Instance;

		public _IndicatorReferences Indicator;

		public _MinimapReferences Minimap;

		public static HUDNavigationCanvas Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = UnityEngine.Object.FindObjectOfType<HUDNavigationCanvas>();
				}
				return _Instance;
			}
		}

		public float CompassBarCurrentDegrees { get; private set; }

		private void Awake()
		{
			_Instance = this;
		}

		public void InitRadar()
		{
			ShowRadar(value: true);
		}

		public void ShowRadar(bool value)
		{
		}

		public void UpdateRadar(Transform rotationReference, RadarModes radarType)
		{
		}

		public void InitCompassBar()
		{
			ShowCompassBar(value: true);
		}

		public void ShowCompassBar(bool value)
		{
		}

		public void UpdateCompassBar(Transform rotationReference)
		{
			Vector3 vector = Vector3.Cross(Vector3.forward, rotationReference.forward);
			float num = Vector3.Angle(new Vector3(rotationReference.forward.x, 0f, rotationReference.forward.z), Vector3.forward);
			CompassBarCurrentDegrees = ((!(vector.y >= 0f)) ? (360f - num) : num);
		}

		public void InitIndicators()
		{
			if (Indicator.Panel == null || Indicator.ElementContainer == null)
			{
				ReferencesMissing("Indicator");
			}
			else
			{
				ShowIndicators(value: true);
			}
		}

		public void ShowIndicators(bool value)
		{
			if (Indicator.Panel != null)
			{
				Indicator.Panel.gameObject.SetActive(value);
			}
		}

		public void InitMinimap(HNSMapProfile profile)
		{
			if (Minimap.Panel == null || Minimap.MapContainer == null || Minimap.ElementContainer == null)
			{
				ReferencesMissing("Minimap");
				return;
			}
			GameObject gameObject = new GameObject(profile.MapTexture.name);
			gameObject.transform.SetParent(Minimap.MapContainer, worldPositionStays: false);
			Image image = gameObject.AddComponent<Image>();
			image.sprite = profile.MapTexture;
			image.preserveAspect = true;
			image.SetNativeSize();
			if (profile.CustomLayers.Count > 0)
			{
				int num = 0;
				foreach (CustomLayer item in Enumerable.Reverse(profile.CustomLayers))
				{
					if (!(item.sprite == null))
					{
						GameObject gameObject2 = new GameObject(item.name + "_Layer_" + num++);
						gameObject2.transform.SetParent(Minimap.MapContainer, worldPositionStays: false);
						gameObject2.SetActive(item.enabled);
						Image image2 = gameObject2.AddComponent<Image>();
						image2.sprite = item.sprite;
						image2.preserveAspect = true;
						image2.SetNativeSize();
						item.instance = gameObject2;
					}
				}
			}
			ShowMinimap(value: true);
		}

		public void ShowMinimap(bool value)
		{
			if (Minimap.Panel != null)
			{
				Minimap.Panel.gameObject.SetActive(value);
			}
		}

		public void UpdateMinimap(Transform rotationReference, MinimapModes minimapMode, Transform playerTransform, HNSMapProfile profile, float scale)
		{
			Quaternion rotation = Minimap.Panel.transform.rotation;
			Quaternion rotation2 = rotation;
			if (minimapMode == MinimapModes.RotateMinimap)
			{
				rotation2 = Quaternion.Euler(Minimap.Panel.transform.eulerAngles.x, Minimap.Panel.transform.eulerAngles.y, rotationReference.eulerAngles.y);
			}
			if (Minimap.PlayerIndicator != null)
			{
				if (minimapMode == MinimapModes.RotateMinimap)
				{
					Minimap.PlayerIndicator.transform.rotation = rotation;
				}
				else
				{
					Minimap.PlayerIndicator.transform.rotation = Quaternion.Euler(Minimap.Panel.transform.eulerAngles.x, Minimap.Panel.transform.eulerAngles.y, 0f - rotationReference.eulerAngles.y);
				}
			}
			Vector2 mapUnitScale = profile.GetMapUnitScale();
			Vector3 vector = profile.MapBounds.center - playerTransform.position;
			Vector3 position = new Vector3(vector.x * mapUnitScale.x, vector.z * mapUnitScale.y, 0f) * scale;
			if (minimapMode == MinimapModes.RotateMinimap)
			{
				position = playerTransform.MinimapRotationOffset(position);
			}
			Minimap.MapContainer.localPosition = new Vector2(position.x, position.y);
			Minimap.MapContainer.rotation = rotation2;
			Minimap.MapContainer.localScale = new Vector3(scale, scale, 1f);
		}

		private void ReferencesMissing(string feature)
		{
			Debug.LogErrorFormat("{0} references are missing! Please assign them on the HUDNavigationCanvas component.", feature);
			base.enabled = false;
		}
	}
}

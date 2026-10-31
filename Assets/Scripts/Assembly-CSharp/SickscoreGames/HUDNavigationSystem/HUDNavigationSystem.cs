using System;
using System.Collections.Generic;
using UnityEngine;

namespace SickscoreGames.HUDNavigationSystem
{
	[DisallowMultipleComponent]
	[AddComponentMenu("HUD Navigation System/HUD Navigation System")]
	public class HUDNavigationSystem : MonoBehaviour
	{
		private static HUDNavigationSystem _Instance;

		public Camera PlayerCamera;

		public Transform PlayerController;

		public _RotationReference RotationReference;

		[Tooltip("Enable, if you want to use the radar feature.")]
		public bool useRadar = true;

		[Tooltip("Select the radar mode you want to use.")]
		public RadarModes radarMode;

		[Tooltip("Define the radar zoom. Change value to zoom the radar. Set to 1 for default radar zoom.")]
		public float radarZoom = 1f;

		[Tooltip("Define the radar radius. Elements outside this radius will be displayed on the border of the radar.")]
		public float radarRadius = 50f;

		[Tooltip("Define the maximum radar radius. Elements outside this radius will be hidden.")]
		public float radarMaxRadius = 75f;

		[Tooltip("Enable, if you want to show arrows pointing upwards/downwards if the element is physically above or below a certain distance.")]
		public bool useRadarHeightSystem = true;

		[Tooltip("Minimum distance upwards to activate the element's ABOVE arrow.")]
		public float radarDistanceAbove = 10f;

		[Tooltip("Minimum distance downwards to activate the element's BELOW arrow.")]
		public float radarDistanceBelow = 10f;

		[Tooltip("(DEBUG) Enable to show the radar's height gizmos.")]
		public bool showRadarHeightGizmos;

		[SerializeField]
		protected Vector2 radarHeightGizmoSize = new Vector2(100f, 100f);

		[SerializeField]
		protected Color radarHeightGizmoColor = new Color(0f, 0f, 1f, 0.4f);

		[Tooltip("Enable, if you want to use the compass bar feature.")]
		public bool useCompassBar = true;

		[Tooltip("Define the compass radius. Elements that don't ignore the radius will be hidden outside this radius.")]
		public float compassBarRadius = 150f;

		[Tooltip("Enable, if you want to use the indicator feature. Must be separately enabled on each element.")]
		public bool useIndicators = true;

		[Tooltip("Define the indicator radius. Indicators that don't ignore the radius will be hidden outside this radius.")]
		public float indicatorRadius = 25f;

		[Tooltip("Define the distance below which the indicator will automatically be hidden. (0 = no auto-hide)")]
		public float indicatorHideDistance = 3f;

		[Tooltip("Enable, if you want to use an offscreen indicator, when the element is not on screen.")]
		public bool useOffscreenIndicators = true;

		[Tooltip("Increase this value to move the indicators further away from the screen borders.")]
		public float indicatorOffscreenBorder = 0.075f;

		[Tooltip("Enable, if you want to scale the indicator by distance and within defined radius.")]
		public bool useIndicatorScaling = true;

		[Tooltip("Define the indicator scale radius. Indicator will scale when inside this radius. Must be smaller or equal to indicator radius.")]
		public float indicatorScaleRadius = 15f;

		[Tooltip("Minimum scale of the indicator. Set value to 1, if you don't want your indicator to scale")]
		public float indicatorMinScale = 0.8f;

		[Tooltip("Enable, if you want to use the minimap feature.")]
		public bool useMinimap = true;

		[Tooltip("Assign the map profile for your minimap.")]
		public HNSMapProfile minimapProfile;

		[Tooltip("Select the minimap mode you want to use.")]
		public MinimapModes minimapMode = MinimapModes.RotatePlayer;

		[Tooltip("Define the minimap scale. Change value to zoom the minimap.")]
		public float minimapScale = 0.25f;

		[Tooltip("Define the minimap radius. Elements outside this radius will be displayed on the border of the minimap.")]
		public float minimapRadius = 75f;

		[Tooltip("(DEBUG) Enable to show the minimap bounds gizmos.")]
		public bool showMinimapBounds = true;

		[SerializeField]
		protected Color minimapBoundsGizmoColor = new Color(0f, 1f, 0f, 0.85f);

		[Tooltip("Enable, if you want to show arrows pointing upwards/downwards if the element is physically above or below a certain distance.")]
		public bool useMinimapHeightSystem = true;

		[Tooltip("Minimum distance upwards to activate the element's ABOVE arrow.")]
		public float minimapDistanceAbove = 10f;

		[Tooltip("Minimum distance downwards to activate the element's BELOW arrow.")]
		public float minimapDistanceBelow = 10f;

		[Tooltip("(DEBUG) Enable to show the minimap's height gizmos.")]
		public bool showMinimapHeightGizmos;

		[SerializeField]
		protected Vector2 minimapHeightGizmoSize = new Vector2(100f, 100f);

		[SerializeField]
		protected Color minimapHeightGizmoColor = new Color(0f, 0f, 1f, 0.4f);

		[HideInInspector]
		public List<HUDNavigationElement> NavigationElements;

		private HUDNavigationCanvas _HUDNavigationCanvas;

		public static HUDNavigationSystem Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = UnityEngine.Object.FindObjectOfType<HUDNavigationSystem>();
				}
				return _Instance;
			}
		}

		private void Start()
		{
			_Instance = this;
			if (Application.loadedLevel == 0 || TRAFFIC_MANAGER.TRAFFIC_MODE)
			{
				base.enabled = false;
				return;
			}
			if (_HUDNavigationCanvas == null)
			{
				_HUDNavigationCanvas = HUDNavigationCanvas.Instance;
				if (_HUDNavigationCanvas == null)
				{
					Debug.LogError("HUDNavigationCanvas not found in scene!");
					base.enabled = false;
					return;
				}
			}
			if (PlayerCamera == null && Camera.main != null)
			{
				PlayerCamera = Camera.main;
			}
			if (PlayerCamera == null || PlayerController == null)
			{
				Debug.LogError("Player references are missing! Please assign them on the HUDNavigationSystem component.");
				base.enabled = false;
			}
			else
			{
				InitAllComponents();
			}
		}

		private void Update()
		{
			UpdateNavigationElements();
			Transform rotationReference = GetRotationReference();
			if (!GAME_MANAGER.ZOOM_MAP)
			{
				minimapScale = 0.9f;
				minimapRadius = 100f;
			}
			else
			{
				minimapRadius = 200f;
				minimapScale = 0.5f;
			}
			if (useMinimap && minimapProfile != null && PlayerController != null && Time.frameCount % 2 == 0)
			{
				_HUDNavigationCanvas.UpdateMinimap(rotationReference, minimapMode, PlayerController, minimapProfile, minimapScale);
			}
		}

		public void AddNavigationElement(HUDNavigationElement element)
		{
			if (!(element == null) && !NavigationElements.Contains(element))
			{
				NavigationElements.Add(element);
			}
		}

		public void RemoveNavigationElement(HUDNavigationElement element)
		{
			if (!(element == null))
			{
				NavigationElements.Remove(element);
			}
		}

		public void EnableRadar(bool value)
		{
			if (useRadar != value)
			{
				useRadar = value;
				_HUDNavigationCanvas.ShowRadar(value);
			}
		}

		public void EnableCompassBar(bool value)
		{
			if (useCompassBar != value)
			{
				useCompassBar = value;
				_HUDNavigationCanvas.ShowCompassBar(value);
			}
		}

		public void EnableIndicators(bool value)
		{
			if (useIndicators != value)
			{
				useIndicators = value;
				_HUDNavigationCanvas.ShowIndicators(value);
			}
		}

		public void EnableMinimap(bool value)
		{
			if (useMinimap != value)
			{
				useMinimap = value;
				_HUDNavigationCanvas.ShowMinimap(value);
			}
		}

		private void InitAllComponents()
		{
			if (_HUDNavigationCanvas == null)
			{
				return;
			}
			if (useRadar)
			{
				_HUDNavigationCanvas.InitRadar();
				if (radarMaxRadius < radarRadius)
				{
					radarMaxRadius = radarRadius;
				}
			}
			else
			{
				_HUDNavigationCanvas.ShowRadar(value: false);
			}
			if (useCompassBar)
			{
				_HUDNavigationCanvas.InitCompassBar();
			}
			else
			{
				_HUDNavigationCanvas.ShowCompassBar(value: false);
			}
			if (useIndicators)
			{
				_HUDNavigationCanvas.InitIndicators();
			}
			else
			{
				_HUDNavigationCanvas.ShowIndicators(value: false);
			}
			if (useMinimap && minimapProfile != null)
			{
				_HUDNavigationCanvas.InitMinimap(minimapProfile);
			}
			else
			{
				_HUDNavigationCanvas.ShowMinimap(value: false);
			}
		}

		private void UpdateNavigationElements()
		{
			if (_HUDNavigationCanvas == null || NavigationElements.Count <= 0)
			{
				return;
			}
			foreach (HUDNavigationElement navigationElement in NavigationElements)
			{
				if (navigationElement == null)
				{
					continue;
				}
				if (!navigationElement.IsActive)
				{
					navigationElement.SetMarkerActive(NavigationElementType.Minimap, value: false);
					navigationElement.SetIndicatorActive(value: false);
					continue;
				}
				Vector3 position = navigationElement.GetPosition();
				Vector3 screenPos = PlayerCamera.WorldToScreenPoint(position);
				float distance = navigationElement.GetDistance(PlayerController.transform);
				if (useIndicators && navigationElement.Indicator != null)
				{
					UpdateIndicatorElement(navigationElement, screenPos, distance);
				}
				if (Time.frameCount % 2 == 0 && useMinimap && navigationElement.Minimap != null)
				{
					UpdateMinimapElement(navigationElement, screenPos, distance);
				}
			}
		}

		public Transform GetRotationReference()
		{
			return (RotationReference != 0) ? PlayerController : PlayerCamera.transform;
		}

		private void OnDrawGizmos()
		{
		}

		private void UpdateRadarElement(HUDNavigationElement element, Vector3 screenPos, float distance)
		{
			float num = radarRadius * radarZoom;
			float num2 = radarMaxRadius * radarZoom;
			if (element.hideInRadar)
			{
				element.SetMarkerActive(NavigationElementType.Radar, value: false);
				return;
			}
			if (distance > num)
			{
				if (element.IsInRadarRadius)
				{
					element.IsInRadarRadius = false;
					element.OnLeaveRadius.Invoke(element, NavigationElementType.Radar);
				}
				if (distance > num2 && !element.ignoreRadarRadius)
				{
					element.SetMarkerActive(NavigationElementType.Radar, value: false);
					return;
				}
				distance = num;
			}
			else if (!element.IsInRadarRadius)
			{
				element.IsInRadarRadius = true;
				element.OnEnterRadius.Invoke(element, NavigationElementType.Radar);
			}
			Transform rotationReference = GetRotationReference();
			if (radarMode == RadarModes.RotateRadar)
			{
				element.Radar.PrefabRect.rotation = Quaternion.identity;
				if (element.rotateWithGameObject)
				{
					element.Radar.Icon.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f - element.transform.eulerAngles.y + rotationReference.eulerAngles.y));
				}
			}
			else if (element.rotateWithGameObject)
			{
				element.Radar.Icon.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f - element.transform.eulerAngles.y));
			}
			if (!element.rotateWithGameObject)
			{
				element.Radar.Icon.transform.rotation = Quaternion.identity;
			}
			element.SetMarkerActive(NavigationElementType.Radar, value: true);
			Vector3 positionOffset = element.GetPositionOffset(PlayerController.position);
			Vector3 markerPos = new Vector3(positionOffset.x, positionOffset.z, 0f);
			markerPos.Normalize();
			element.SetMarkerPosition(NavigationElementType.Radar, markerPos);
			element.ShowRadarAboveArrow(useRadarHeightSystem && element.useRadarHeightSystem && element.IsInRadarRadius && 0f - positionOffset.y < 0f - radarDistanceAbove);
			element.ShowRadarBelowArrow(useRadarHeightSystem && element.useRadarHeightSystem && element.IsInRadarRadius && 0f - positionOffset.y > radarDistanceBelow);
		}

		private void UpdateCompassBarElement(HUDNavigationElement element, Vector3 screenPos, float distance)
		{
			if (element.hideInCompassBar)
			{
				element.SetMarkerActive(NavigationElementType.CompassBar, value: false);
				return;
			}
			if (distance > compassBarRadius && !element.ignoreCompassBarRadius)
			{
				element.SetMarkerActive(NavigationElementType.CompassBar, value: false);
				if (element.IsInCompassBarRadius)
				{
					element.IsInCompassBarRadius = false;
					element.OnLeaveRadius.Invoke(element, NavigationElementType.CompassBar);
				}
				return;
			}
			if (!element.IsInCompassBarRadius)
			{
				element.IsInCompassBarRadius = true;
				element.OnEnterRadius.Invoke(element, NavigationElementType.CompassBar);
			}
			if (screenPos.z <= 0f)
			{
				element.SetMarkerActive(NavigationElementType.CompassBar, value: false);
				return;
			}
			element.ShowCompassBarDistance((int)distance);
			element.SetMarkerActive(NavigationElementType.CompassBar, value: true);
		}

		private void UpdateIndicatorElement(HUDNavigationElement element, Vector3 screenPos, float distance)
		{
			if (useIndicators && element.showIndicator)
			{
				if (distance > indicatorRadius && !element.ignoreIndicatorRadius)
				{
					element.SetIndicatorActive(value: false);
					if (element.IsInIndicatorRadius)
					{
						element.IsInIndicatorRadius = false;
						element.OnLeaveRadius.Invoke(element, NavigationElementType.Indicator);
					}
					return;
				}
				bool flag = element.IsVisibleOnScreen(screenPos);
				if (!flag)
				{
					if (!useOffscreenIndicators || !element.showOffscreenIndicator)
					{
						element.SetIndicatorActive(value: false);
						return;
					}
					if (screenPos.z < 0f)
					{
						screenPos.x = (float)Screen.width - screenPos.x;
						screenPos.y = (float)Screen.height - screenPos.y;
					}
					Vector3 vector = new Vector3(Screen.width, Screen.height, 0f) / 2f;
					screenPos -= vector;
					float num = Mathf.Atan2(screenPos.y, screenPos.x);
					num -= (float)Math.PI / 2f;
					float num2 = Mathf.Cos(num);
					float num3 = 0f - Mathf.Sin(num);
					float num4 = num2 / num3;
					screenPos = vector + new Vector3(num3 * 50f, num2 * 50f, 0f);
					float b = Mathf.Min(vector.x, vector.y);
					b = Mathf.Lerp(0f, b, indicatorOffscreenBorder);
					Vector3 vector2 = vector - new Vector3(b, b, 0f);
					float num5 = ((!(num2 > 0f)) ? (0f - vector2.y) : vector2.y);
					screenPos = new Vector3(num5 / num4, num5, 0f);
					if (screenPos.x > vector2.x)
					{
						screenPos = new Vector3(vector2.x, vector2.x * num4, 0f);
					}
					else if (screenPos.x < 0f - vector2.x)
					{
						screenPos = new Vector3(0f - vector2.x, (0f - vector2.x) * num4, 0f);
					}
					screenPos += vector;
					element.SetIndicatorOffscreenRotation(Quaternion.Euler(0f, 0f, num * 57.29578f));
				}
				element.ShowIndicatorDistance(flag, (int)distance);
				element.SetIndicatorOnOffscreen(flag);
				element.SetIndicatorPosition(screenPos, _HUDNavigationCanvas.Indicator.ElementContainer);
				element.SetIndicatorScale(distance, indicatorScaleRadius, indicatorMinScale);
				element.SetIndicatorActive(!(indicatorHideDistance > 0f) || element.ignoreIndicatorHideDistance || distance > indicatorHideDistance);
				if (!element.IsInIndicatorRadius)
				{
					element.IsInIndicatorRadius = true;
					element.OnEnterRadius.Invoke(element, NavigationElementType.Indicator);
				}
			}
			else
			{
				element.SetIndicatorActive(value: false);
			}
		}

		private void UpdateMinimapElement(HUDNavigationElement element, Vector3 screenPos, float distance)
		{
			if (element.hideInMinimap)
			{
				element.SetMarkerActive(NavigationElementType.Minimap, value: false);
				return;
			}
			if (distance > minimapRadius)
			{
				if (element.IsInMinimapRadius)
				{
					element.IsInMinimapRadius = false;
					element.OnLeaveRadius.Invoke(element, NavigationElementType.Minimap);
				}
				if (!element.ignoreMinimapRadius)
				{
					element.SetMarkerActive(NavigationElementType.Minimap, value: false);
					return;
				}
			}
			else if (!element.IsInMinimapRadius)
			{
				element.IsInMinimapRadius = true;
				element.OnEnterRadius.Invoke(element, NavigationElementType.Minimap);
			}
			if (element.rotateWithGameObjectMM)
			{
				element.Minimap.Icon.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f - element.transform.eulerAngles.y));
			}
			else
			{
				element.Minimap.Icon.transform.rotation = Quaternion.identity;
			}
			element.SetMarkerActive(NavigationElementType.Minimap, value: true);
			Vector2 mapUnitScale = minimapProfile.GetMapUnitScale();
			Vector3 positionOffset = element.GetPositionOffset(PlayerController.position);
			Vector3 vector = new Vector3(positionOffset.x * mapUnitScale.x, positionOffset.z * mapUnitScale.y, 0f) * minimapScale;
			if (minimapMode == MinimapModes.RotateMinimap)
			{
				vector = PlayerController.MinimapRotationOffset(vector);
			}
			bool outOfBounds = false;
			vector = _HUDNavigationCanvas.Minimap.ElementContainer.KeepInRectBounds(vector, out outOfBounds);
			element.SetMarkerPosition(NavigationElementType.Minimap, vector);
			element.ShowMinimapAboveArrow(useMinimapHeightSystem && element.useMinimapHeightSystem && !outOfBounds && 0f - positionOffset.y < 0f - minimapDistanceAbove);
			element.ShowMinimapBelowArrow(useMinimapHeightSystem && element.useMinimapHeightSystem && !outOfBounds && 0f - positionOffset.y > minimapDistanceBelow);
		}
	}
}

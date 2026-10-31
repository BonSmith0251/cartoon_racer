using SickscoreGames.HUDNavigationSystem;
using UnityEngine;

public class ExampleInteractions : MonoBehaviour
{
	public LayerMask layerMask = 1;

	public float interactionDistance = 4f;

	protected RaycastHit hit;

	private Transform pickupText;

	private Transform interactionText;

	private HUDNavigationSystem _HUDNavigationSystem;

	private void Start()
	{
		_HUDNavigationSystem = HUDNavigationSystem.Instance;
	}

	private void Update()
	{
		HandleKeyInput();
		HandleItemPickUp();
		HandlePrismColorChange();
	}

	private void HandleKeyInput()
	{
		if (Input.GetKey(KeyCode.X) && _HUDNavigationSystem.radarZoom < 5f)
		{
			_HUDNavigationSystem.radarZoom += 0.0175f;
		}
		else if (Input.GetKey(KeyCode.C) && _HUDNavigationSystem.radarZoom > 0.25f)
		{
			_HUDNavigationSystem.radarZoom -= 0.0175f;
		}
		else if (Input.GetKey(KeyCode.V) && _HUDNavigationSystem.indicatorOffscreenBorder < 0.7f)
		{
			_HUDNavigationSystem.indicatorOffscreenBorder += 0.01f;
		}
		else if (Input.GetKey(KeyCode.B) && _HUDNavigationSystem.indicatorOffscreenBorder > 0.07f)
		{
			_HUDNavigationSystem.indicatorOffscreenBorder -= 0.01f;
		}
		else if (Input.GetKey(KeyCode.N) && _HUDNavigationSystem.minimapScale > 0.06f)
		{
			_HUDNavigationSystem.minimapScale -= 0.01f;
		}
		else if (Input.GetKey(KeyCode.M) && _HUDNavigationSystem.minimapScale < 1f)
		{
			_HUDNavigationSystem.minimapScale += 0.01f;
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			_HUDNavigationSystem.EnableRadar(!_HUDNavigationSystem.useRadar);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			_HUDNavigationSystem.EnableCompassBar(!_HUDNavigationSystem.useCompassBar);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			_HUDNavigationSystem.EnableIndicators(!_HUDNavigationSystem.useIndicators);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			_HUDNavigationSystem.EnableMinimap(!_HUDNavigationSystem.useMinimap);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			_HUDNavigationSystem.radarMode = ((_HUDNavigationSystem.radarMode == RadarModes.RotateRadar) ? RadarModes.RotatePlayer : RadarModes.RotateRadar);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			_HUDNavigationSystem.minimapMode = ((_HUDNavigationSystem.minimapMode == MinimapModes.RotateMinimap) ? MinimapModes.RotatePlayer : MinimapModes.RotateMinimap);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7) && _HUDNavigationSystem.minimapProfile != null)
		{
			GameObject customLayer = _HUDNavigationSystem.minimapProfile.GetCustomLayer("blackWhite");
			if (customLayer != null)
			{
				customLayer.SetActive(!customLayer.activeSelf);
			}
		}
	}

	private void HandleItemPickUp()
	{
		if (Physics.Raycast(base.transform.position, base.transform.TransformDirection(Vector3.forward), out hit, interactionDistance, layerMask) && hit.collider.name.Contains("PickUp"))
		{
			HUDNavigationElement component = hit.collider.gameObject.GetComponent<HUDNavigationElement>();
			if (!(component != null))
			{
				return;
			}
			if (component.Indicator != null)
			{
				pickupText = component.Indicator.GetCustomTransform("pickupText");
				if (pickupText != null)
				{
					pickupText.gameObject.SetActive(value: true);
				}
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				Object.Destroy(component.gameObject);
			}
		}
		else if (pickupText != null)
		{
			pickupText.gameObject.SetActive(value: false);
			pickupText = null;
		}
	}

	private void HandlePrismColorChange()
	{
		if (Physics.Raycast(base.transform.position, base.transform.TransformDirection(Vector3.forward), out hit, interactionDistance, layerMask) && hit.collider.name.Contains("Prism"))
		{
			HUDNavigationElement componentInChildren = hit.collider.gameObject.GetComponentInChildren<HUDNavigationElement>();
			if (!(componentInChildren != null))
			{
				return;
			}
			if (componentInChildren.Indicator != null)
			{
				interactionText = componentInChildren.Indicator.GetCustomTransform("interactionText");
				if (interactionText != null)
				{
					interactionText.gameObject.SetActive(value: true);
				}
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
				if (componentInChildren.Radar != null)
				{
					componentInChildren.Radar.ChangeIconColor(color);
				}
				if (componentInChildren.CompassBar != null)
				{
					componentInChildren.CompassBar.ChangeIconColor(color);
				}
				if (componentInChildren.Indicator != null)
				{
					componentInChildren.Indicator.ChangeIconColor(color);
					componentInChildren.Indicator.ChangeOffscreenIconColor(color);
				}
				if (componentInChildren.Minimap != null)
				{
					componentInChildren.Minimap.ChangeIconColor(color);
				}
				Renderer component = componentInChildren.transform.parent.GetComponent<Renderer>();
				if (component != null)
				{
					component.material.color = new Color(color.r, color.g, color.b, component.material.color.a);
				}
			}
		}
		else if (interactionText != null)
		{
			interactionText.gameObject.SetActive(value: false);
			interactionText = null;
		}
	}
}

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RCC_DashboardInputs))]
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/RCC UI Dashboard Displayer")]
public class RCC_UIDashboardDisplay : MonoBehaviour
{
	public enum DisplayType
	{
		Full,
		Customization,
		TopButtonsOnly,
		Off
	}

	private RCC_Settings RCCSettingsInstance;

	private RCC_DashboardInputs inputs;

	public DisplayType displayType;

	public GameObject topButtons;

	public GameObject controllerButtons;

	public GameObject gauges;

	public GameObject customizationMenu;

	public Text RPMLabel;

	public Text KMHLabel;

	public Text GearLabel;

	public Text recordingLabel;

	public Image ABS;

	public Image ESP;

	public Image Park;

	public Image Headlights;

	public Image leftIndicator;

	public Image rightIndicator;

	public Image heatIndicator;

	public Image fuelIndicator;

	public Image rpmIndicator;

	private RCC_Settings RCCSettings
	{
		get
		{
			if (RCCSettingsInstance == null)
			{
				RCCSettingsInstance = RCC_Settings.Instance;
			}
			return RCCSettingsInstance;
		}
	}

	private void Awake()
	{
		inputs = GetComponent<RCC_DashboardInputs>();
		if (!inputs)
		{
			base.enabled = false;
		}
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
		if ((bool)topButtons && !topButtons.activeInHierarchy)
		{
			topButtons.SetActive(value: true);
		}
		if ((bool)controllerButtons && !controllerButtons.activeInHierarchy)
		{
			controllerButtons.SetActive(value: true);
		}
		if ((bool)gauges && !gauges.activeInHierarchy)
		{
			gauges.SetActive(value: true);
		}
		if ((bool)customizationMenu && customizationMenu.activeInHierarchy)
		{
			customizationMenu.SetActive(value: false);
		}
	}

	public void SetDisplayType(DisplayType _displayType)
	{
		displayType = _displayType;
	}
}

using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Misc/RCC Visual Dashboard Objects Manager")]
public class RCC_DashboardObjects : MonoBehaviour
{
	public enum RotateAround
	{
		X,
		Y,
		Z
	}

	private RCC_Settings RCCSettingsInstance;

	private RCC_CarControllerV3 carController;

	public GameObject RPMMeterDial;

	public GameObject speedOMeterDial;

	public GameObject engineHeatDial;

	public GameObject fuelDial;

	private Quaternion RPMMeterDialOrgRotation;

	private Quaternion speedOMeterDialOrgRotation;

	private Quaternion engineHeatDialOrgRotation;

	private Quaternion fuelDialOrgRotation;

	public float RPMMeterDialMultiplier = 1f;

	public float speedOMeterDialMultiplier = 1f;

	public float engineHeatDialMultiplier = 1f;

	public float fuelDialMultiplier = 1f;

	public RotateAround rotateAround;

	public Text RPMMeterText;

	public Text speedOMeterText;

	public Light[] dashboardLights;

	public float lightIntensity = 1f;

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
		carController = GetComponentInParent<RCC_CarControllerV3>();
		if ((bool)RPMMeterDial)
		{
			RPMMeterDialOrgRotation = RPMMeterDial.transform.localRotation;
		}
		if ((bool)speedOMeterDial)
		{
			speedOMeterDialOrgRotation = speedOMeterDial.transform.localRotation;
		}
		if ((bool)engineHeatDial)
		{
			engineHeatDialOrgRotation = engineHeatDial.transform.localRotation;
		}
		if ((bool)fuelDial)
		{
			fuelDialOrgRotation = fuelDial.transform.localRotation;
		}
		for (int i = 0; i < dashboardLights.Length; i++)
		{
			if (RCCSettings.useLightsAsVertexLights)
			{
				dashboardLights[i].renderMode = LightRenderMode.ForceVertex;
			}
			else
			{
				dashboardLights[i].renderMode = LightRenderMode.ForcePixel;
			}
		}
	}

	private void Update()
	{
		if ((bool)carController)
		{
			Dials();
			DashboardLights();
		}
	}

	private void Dials()
	{
		switch (rotateAround)
		{
		case RotateAround.X:
		{
			Vector3 forward = Vector3.right;
			break;
		}
		case RotateAround.Y:
		{
			Vector3 forward = Vector3.up;
			break;
		}
		case RotateAround.Z:
		{
			Vector3 forward = Vector3.forward;
			break;
		}
		}
		if ((bool)RPMMeterDial)
		{
			RPMMeterDial.transform.localRotation = RPMMeterDialOrgRotation * Quaternion.AngleAxis((0f - RPMMeterDialMultiplier) * carController.engineRPM, Vector3.forward);
		}
		if ((bool)speedOMeterDial)
		{
			speedOMeterDial.transform.localRotation = speedOMeterDialOrgRotation * Quaternion.AngleAxis((0f - speedOMeterDialMultiplier) * carController.speed, Vector3.forward);
		}
		if ((bool)engineHeatDial)
		{
			engineHeatDial.transform.localRotation = engineHeatDialOrgRotation * Quaternion.AngleAxis((0f - engineHeatDialMultiplier) * carController.engineHeat, Vector3.forward);
		}
		if ((bool)fuelDial)
		{
			fuelDial.transform.localRotation = fuelDialOrgRotation * Quaternion.AngleAxis((0f - fuelDialMultiplier) * carController.engineHeat, Vector3.forward);
		}
		if ((bool)RPMMeterText)
		{
			RPMMeterText.text = carController.engineRPM.ToString("F0");
		}
		if ((bool)speedOMeterText)
		{
			speedOMeterText.text = carController.speed.ToString("F0");
		}
	}

	private void DashboardLights()
	{
		for (int i = 0; i < dashboardLights.Length; i++)
		{
			dashboardLights[i].intensity = ((!carController.lowBeamHeadLightsOn && !carController.highBeamHeadLightsOn) ? 0f : lightIntensity);
			if (!dashboardLights[i].enabled)
			{
				dashboardLights[i].enabled = true;
			}
		}
	}
}

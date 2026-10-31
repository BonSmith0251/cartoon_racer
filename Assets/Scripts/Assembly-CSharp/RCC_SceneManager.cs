using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Main/RCC Scene Manager")]
public class RCC_SceneManager : MonoBehaviour
{
	private static RCC_SceneManager instance;

	public RCC_CarControllerV3 activePlayerVehicle;

	public RCC_Camera activePlayerCamera;

	public RCC_UIDashboardDisplay activePlayerCanvas;

	public Camera activeMainCamera;

	public bool registerFirstVehicleAsPlayer = true;

	public bool disableUIWhenNoPlayerVehicle;

	private float orgTimeScale = 1f;

	public List<RCC_CarControllerV3> allVehicles = new List<RCC_CarControllerV3>();

	public static RCC_SceneManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Object.FindObjectOfType<RCC_SceneManager>();
				if (instance == null)
				{
					GameObject gameObject = new GameObject("_RCCSceneManager");
					instance = gameObject.AddComponent<RCC_SceneManager>();
				}
			}
			return instance;
		}
	}

	private void Start()
	{
		activePlayerCamera = Object.FindObjectOfType<RCC_Camera>();
		activePlayerVehicle = Object.FindObjectOfType<RCC_CarControllerV3>();
		activePlayerCanvas = Object.FindObjectOfType<RCC_UIDashboardDisplay>();
		base.enabled = false;
		RCC_Camera.OnBCGCameraSpawned += RCC_Camera_OnBCGCameraSpawned;
		RCC_CarControllerV3.OnRCCPlayerSpawned += RCC_CarControllerV3_OnRCCSpawned;
		RCC_AICarController.OnRCCAISpawned += RCC_AICarController_OnRCCAISpawned;
		RCC_CarControllerV3.OnRCCPlayerDestroyed += RCC_CarControllerV3_OnRCCPlayerDestroyed;
		RCC_AICarController.OnRCCAIDestroyed += RCC_AICarController_OnRCCAIDestroyed;
		orgTimeScale = Time.timeScale;
	}

	private void RCC_CarControllerV3_OnRCCSpawned(RCC_CarControllerV3 RCC)
	{
		if (!allVehicles.Contains(RCC))
		{
			allVehicles.Add(RCC);
		}
		if (registerFirstVehicleAsPlayer)
		{
			RegisterPlayer(RCC);
		}
	}

	private void RCC_AICarController_OnRCCAISpawned(RCC_AICarController RCCAI)
	{
		if (!allVehicles.Contains(RCCAI.carController))
		{
			allVehicles.Add(RCCAI.carController);
		}
	}

	private void RCC_Camera_OnBCGCameraSpawned(GameObject BCGCamera)
	{
		activePlayerCamera = BCGCamera.GetComponent<RCC_Camera>();
	}

	private void RCC_CarControllerV3_OnRCCPlayerDestroyed(RCC_CarControllerV3 RCC)
	{
		if (allVehicles.Contains(RCC))
		{
			allVehicles.Remove(RCC);
		}
	}

	private void RCC_AICarController_OnRCCAIDestroyed(RCC_AICarController RCCAI)
	{
		if (allVehicles.Contains(RCCAI.carController))
		{
			allVehicles.Remove(RCCAI.carController);
		}
	}

	public void RegisterPlayer(RCC_CarControllerV3 playerVehicle)
	{
		activePlayerVehicle = playerVehicle;
		if ((bool)activePlayerCamera)
		{
			activePlayerCamera.SetTarget(activePlayerVehicle.gameObject);
		}
		if ((bool)Object.FindObjectOfType<RCC_CustomizerExample>())
		{
			Object.FindObjectOfType<RCC_CustomizerExample>().CheckUIs();
		}
	}

	public void RegisterPlayer(RCC_CarControllerV3 playerVehicle, bool isControllable)
	{
		activePlayerVehicle = playerVehicle;
		activePlayerVehicle.SetCanControl(isControllable);
		if ((bool)activePlayerCamera)
		{
			activePlayerCamera.SetTarget(activePlayerVehicle.gameObject);
		}
		if ((bool)Object.FindObjectOfType<RCC_CustomizerExample>())
		{
			Object.FindObjectOfType<RCC_CustomizerExample>().CheckUIs();
		}
	}

	public void RegisterPlayer(RCC_CarControllerV3 playerVehicle, bool isControllable, bool engineState)
	{
		activePlayerVehicle = playerVehicle;
		activePlayerVehicle.SetCanControl(isControllable);
		activePlayerVehicle.SetEngine(engineState);
		if ((bool)activePlayerCamera)
		{
			activePlayerCamera.SetTarget(activePlayerVehicle.gameObject);
		}
		if ((bool)Object.FindObjectOfType<RCC_CustomizerExample>())
		{
			Object.FindObjectOfType<RCC_CustomizerExample>().CheckUIs();
		}
	}

	public void DeRegisterPlayer()
	{
		if ((bool)activePlayerVehicle)
		{
			activePlayerVehicle.SetCanControl(state: false);
		}
		activePlayerVehicle = null;
		if ((bool)activePlayerCamera)
		{
			activePlayerCamera.RemoveTarget();
		}
	}

	public void CheckCanvas()
	{
		if (!activePlayerVehicle || !activePlayerVehicle.gameObject.activeInHierarchy || !activePlayerVehicle.enabled)
		{
			activePlayerCanvas.SetDisplayType(RCC_UIDashboardDisplay.DisplayType.Off);
		}
		else if (activePlayerCanvas.displayType != RCC_UIDashboardDisplay.DisplayType.Customization)
		{
			activePlayerCanvas.displayType = RCC_UIDashboardDisplay.DisplayType.Full;
		}
	}
}

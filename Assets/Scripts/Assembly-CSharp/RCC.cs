using UnityEngine;

public class RCC : MonoBehaviour
{
	public static RCC_CarControllerV3 SpawnRCC(RCC_CarControllerV3 vehiclePrefab, Vector3 position, Quaternion rotation, bool registerAsPlayerVehicle, bool isControllable, bool isEngineRunning)
	{
		RCC_CarControllerV3 rCC_CarControllerV = Object.Instantiate(vehiclePrefab, position, rotation);
		rCC_CarControllerV.gameObject.SetActive(value: true);
		rCC_CarControllerV.SetCanControl(isControllable);
		if (registerAsPlayerVehicle)
		{
			RCC_SceneManager.Instance.RegisterPlayer(rCC_CarControllerV);
		}
		if (isEngineRunning)
		{
			rCC_CarControllerV.StartEngine(instantStart: true);
		}
		else
		{
			rCC_CarControllerV.KillEngine();
		}
		return rCC_CarControllerV;
	}

	public static void RegisterPlayerVehicle(RCC_CarControllerV3 vehicle)
	{
		RCC_SceneManager.Instance.RegisterPlayer(vehicle);
	}

	public static void RegisterPlayerVehicle(RCC_CarControllerV3 vehicle, bool isControllable)
	{
		RCC_SceneManager.Instance.RegisterPlayer(vehicle, isControllable);
	}

	public static void RegisterPlayerVehicle(RCC_CarControllerV3 vehicle, bool isControllable, bool engineState)
	{
		RCC_SceneManager.Instance.RegisterPlayer(vehicle, isControllable, engineState);
	}

	public static void DeRegisterPlayerVehicle()
	{
		RCC_SceneManager.Instance.DeRegisterPlayer();
	}

	public static void SetControl(RCC_CarControllerV3 vehicle, bool isControllable)
	{
		vehicle.SetCanControl(isControllable);
	}

	public static void SetEngine(RCC_CarControllerV3 vehicle, bool engineState)
	{
		if (engineState)
		{
			vehicle.StartEngine();
		}
		else
		{
			vehicle.KillEngine();
		}
	}

	public static void SetMobileController(RCC_Settings.MobileController mobileController)
	{
		RCC_Settings.Instance.mobileController = mobileController;
	}

	public static void SetUnits()
	{
	}

	public static void SetAutomaticGear()
	{
	}
}

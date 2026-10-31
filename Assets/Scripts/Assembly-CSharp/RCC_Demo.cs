using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/RCC Demo Manager")]
public class RCC_Demo : MonoBehaviour
{
	[Header("Spawnable Vehicles")]
	public RCC_CarControllerV3[] selectableVehicles;

	internal int selectedVehicleIndex;

	internal int selectedBehaviorIndex;

	public void SelectVehicle(int index)
	{
		selectedVehicleIndex = index;
	}

	public void Spawn()
	{
		Vector3 vector = default(Vector3);
		Quaternion rotation = default(Quaternion);
		if ((bool)RCC_SceneManager.Instance.activePlayerVehicle)
		{
			vector = RCC_SceneManager.Instance.activePlayerVehicle.transform.position;
			rotation = RCC_SceneManager.Instance.activePlayerVehicle.transform.rotation;
		}
		if (vector == Vector3.zero && (bool)RCC_SceneManager.Instance.activePlayerCamera)
		{
			vector = RCC_SceneManager.Instance.activePlayerCamera.transform.position;
			rotation = RCC_SceneManager.Instance.activePlayerCamera.transform.rotation;
		}
		rotation.x = 0f;
		rotation.z = 0f;
		RCC_CarControllerV3 activePlayerVehicle = RCC_SceneManager.Instance.activePlayerVehicle;
		if ((bool)activePlayerVehicle)
		{
			Object.Destroy(activePlayerVehicle.gameObject);
		}
		RCC.SpawnRCC(selectableVehicles[selectedVehicleIndex], vector, rotation, registerAsPlayerVehicle: true, isControllable: true, isEngineRunning: true);
	}

	public void SelectBehavior(int index)
	{
		selectedBehaviorIndex = index;
	}

	public void InitBehavior()
	{
		switch (selectedBehaviorIndex)
		{
		case 0:
			RCC_Settings.Instance.behaviorType = RCC_Settings.BehaviorType.Simulator;
			RestartScene();
			break;
		case 1:
			RCC_Settings.Instance.behaviorType = RCC_Settings.BehaviorType.Racing;
			RestartScene();
			break;
		case 2:
			RCC_Settings.Instance.behaviorType = RCC_Settings.BehaviorType.SemiArcade;
			RestartScene();
			break;
		case 3:
			RCC_Settings.Instance.behaviorType = RCC_Settings.BehaviorType.Drift;
			RestartScene();
			break;
		case 4:
			RCC_Settings.Instance.behaviorType = RCC_Settings.BehaviorType.Fun;
			RestartScene();
			break;
		case 5:
			RCC_Settings.Instance.behaviorType = RCC_Settings.BehaviorType.Custom;
			RestartScene();
			break;
		}
	}

	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Quit()
	{
		Application.Quit();
	}
}

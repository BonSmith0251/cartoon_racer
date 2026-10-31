using System.Collections.Generic;
using UnityEngine;

public class RCC_CarSelectionExample : MonoBehaviour
{
	public RCC_CarControllerV3[] spawnableVehicles;

	private List<RCC_CarControllerV3> _spawnedVehicles = new List<RCC_CarControllerV3>();

	public Transform spawnPosition;

	public int selectedIndex;

	public RCC_Camera RCCCamera;

	private void Start()
	{
		if (!RCCCamera)
		{
			RCCCamera = Object.FindObjectOfType<RCC_Camera>();
		}
		CreateVehicles();
	}

	private void CreateVehicles()
	{
		for (int i = 0; i < spawnableVehicles.Length; i++)
		{
			RCC_CarControllerV3 rCC_CarControllerV = RCC.SpawnRCC(spawnableVehicles[i], spawnPosition.position, spawnPosition.rotation, registerAsPlayerVehicle: false, isControllable: false, isEngineRunning: false);
			rCC_CarControllerV.gameObject.SetActive(value: false);
			_spawnedVehicles.Add(rCC_CarControllerV);
		}
		_spawnedVehicles[selectedIndex].gameObject.SetActive(value: true);
		if ((bool)RCCCamera && (bool)RCCCamera.GetComponent<RCC_CameraCarSelection>())
		{
			RCCCamera.GetComponent<RCC_CameraCarSelection>().enabled = true;
		}
	}

	public void NextVehicle()
	{
		selectedIndex++;
		if (selectedIndex > _spawnedVehicles.Count - 1)
		{
			selectedIndex = 0;
		}
		for (int i = 0; i < _spawnedVehicles.Count; i++)
		{
			_spawnedVehicles[i].gameObject.SetActive(value: false);
		}
		_spawnedVehicles[selectedIndex].gameObject.SetActive(value: true);
	}

	public void PreviousVehicle()
	{
		selectedIndex--;
		if (selectedIndex < 0)
		{
			selectedIndex = _spawnedVehicles.Count - 1;
		}
		for (int i = 0; i < _spawnedVehicles.Count; i++)
		{
			_spawnedVehicles[i].gameObject.SetActive(value: false);
		}
		_spawnedVehicles[selectedIndex].gameObject.SetActive(value: true);
	}

	public void SelectVehicle()
	{
		RCC.RegisterPlayerVehicle(_spawnedVehicles[selectedIndex]);
		_spawnedVehicles[selectedIndex].StartEngine();
		_spawnedVehicles[selectedIndex].SetCanControl(state: true);
		if ((bool)RCCCamera && (bool)RCCCamera.GetComponent<RCC_CameraCarSelection>())
		{
			RCCCamera.GetComponent<RCC_CameraCarSelection>().enabled = false;
		}
	}

	public void DeSelectVehicle()
	{
		RCC.DeRegisterPlayerVehicle();
		_spawnedVehicles[selectedIndex].transform.position = spawnPosition.position;
		_spawnedVehicles[selectedIndex].transform.rotation = spawnPosition.rotation;
		_spawnedVehicles[selectedIndex].KillEngine();
		_spawnedVehicles[selectedIndex].SetCanControl(state: false);
		_spawnedVehicles[selectedIndex].GetComponent<Rigidbody>().ResetInertiaTensor();
		_spawnedVehicles[selectedIndex].GetComponent<Rigidbody>().velocity = Vector3.zero;
		_spawnedVehicles[selectedIndex].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		if ((bool)RCCCamera && (bool)RCCCamera.GetComponent<RCC_CameraCarSelection>())
		{
			RCCCamera.GetComponent<RCC_CameraCarSelection>().enabled = true;
		}
	}
}

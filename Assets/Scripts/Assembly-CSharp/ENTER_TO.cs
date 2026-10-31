using UnityEngine;
using UnityEngine.SceneManagement;

public class ENTER_TO : MonoBehaviour
{
	public bool TO_CITY;

	public bool TO_FARM;

	private void OnTriggerEnter(Collider car2)
	{
		if ((car2.gameObject.tag == "Player") & !GAME_MANAGER.IN_RACE & !COP_MANAGER.PASSENGER_PICKUP & !TAXI_MANAGER.PASSENGER_PICKUP & !MEDIC_MANAGER.PASSENGER_PICKUP)
		{
			Camera.main.GetComponent<ScreenFader>().RST();
			Object.Destroy(Object.FindObjectOfType<RCC_CarControllerV3>());
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				SceneManager.UnloadSceneAsync("FARM_STATIC");
			}
			if (MENU_MANAGER.LOADING_LEVEL == 1)
			{
				SceneManager.UnloadSceneAsync("CITY_STATIC");
			}
			Object.Destroy(GameObject.FindGameObjectWithTag("Player"));
			GameObject[] array = GameObject.FindGameObjectsWithTag("TERRAIN");
			GameObject[] array2 = array;
			foreach (GameObject obj in array2)
			{
				Object.Destroy(obj);
			}
			GameObject[] array3 = GameObject.FindGameObjectsWithTag("PASSENGER_TARGET");
			GameObject[] array4 = array3;
			foreach (GameObject obj2 in array4)
			{
				Object.Destroy(obj2);
			}
			GameObject[] array5 = GameObject.FindGameObjectsWithTag("PASSENGER_PREFAB");
			GameObject[] array6 = array5;
			foreach (GameObject obj3 in array6)
			{
				Object.Destroy(obj3);
			}
			GameObject[] array7 = GameObject.FindGameObjectsWithTag("TRAFFIC");
			GameObject[] array8 = array7;
			foreach (GameObject obj4 in array8)
			{
				Object.Destroy(obj4);
			}
			GameObject[] array9 = GameObject.FindGameObjectsWithTag("LETTER");
			GameObject[] array10 = array9;
			foreach (GameObject obj5 in array10)
			{
				Object.Destroy(obj5);
			}
			GameObject[] array11 = GameObject.FindGameObjectsWithTag("GEAR");
			GameObject[] array12 = array11;
			foreach (GameObject obj6 in array12)
			{
				Object.Destroy(obj6);
			}
			Object.Destroy(GameObject.FindGameObjectWithTag("COINS_MANAGER"));
			if (TO_FARM)
			{
				MENU_MANAGER.LOADING_LEVEL = 0;
				Application.LoadLevel(1);
			}
			else if (TO_CITY)
			{
				MENU_MANAGER.LOADING_LEVEL = 1;
				Application.LoadLevel(1);
			}
		}
	}
}

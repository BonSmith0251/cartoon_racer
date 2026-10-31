using UnityEngine;
using UnityEngine.UI;

public class MISSION_MANAGER : MonoBehaviour
{
	public static float ADD_PROGRESS;

	private float PROGRESS;

	public GameObject[] MISSION_PREFAB;

	public GameObject MISSION_UI;

	public GameObject MISSION_COMPLETE_UI;

	public Image PROGRESS_UI;

	public Text MONEY_;

	public GameObject POINTS3D_FARM;

	public GameObject POINTS3D_CITY;

	private int PLAYER_MONEY;

	private float PLAYER_XP;

	public void START_MISSION()
	{
		GameObject gameObject = Object.Instantiate(MISSION_PREFAB[MISSION_TRIGGER._INDEX], MISSION_PREFAB[MISSION_TRIGGER._INDEX].transform.position, MISSION_PREFAB[MISSION_TRIGGER._INDEX].transform.rotation);
		MISSION_UI.SetActive(value: true);
		PROGRESS_UI.fillAmount = 0f;
		PROGRESS = 0f;
		PLAYER_MONEY = 0;
		PLAYER_XP = 0f;
		POINTS3D_FARM.SetActive(value: false);
		POINTS3D_CITY.SetActive(value: false);
	}

	private void Update()
	{
		if (!GAME_MANAGER.IN_MISSION)
		{
			return;
		}
		if (ADD_PROGRESS > 0f)
		{
			if (ADD_PROGRESS > 0f)
			{
				ADD_PROGRESS -= Time.deltaTime;
				PROGRESS += Time.deltaTime;
			}
			PROGRESS_UI.fillAmount = PROGRESS;
		}
		if ((PROGRESS > 0.99f) & !MISSION_COMPLETE_UI.activeInHierarchy)
		{
			MISSION_COMPLETE_UI.SetActive(value: true);
			GAME_MANAGER.IN_MISSION_POINT = true;
			GameObject[] array = GameObject.FindGameObjectsWithTag("MISSION_");
			GameObject[] array2 = array;
			foreach (GameObject obj in array2)
			{
				Object.Destroy(obj);
			}
			MONEY_.text = "+ " + MISSION_TRIGGER._MONEY;
		}
	}

	public void CLOSE_FINISH()
	{
		ES2.Save(1, "MISSION_" + RACE_TRIGGER._INDEX);
		GAME_MANAGER.IN_MISSION = false;
		GAME_MANAGER.PLAYER_MONEY += MISSION_TRIGGER._MONEY;
		ES2.Save(GAME_MANAGER.PLAYER_MONEY, "PLAYER_MONEY");
		PLAYER_XP = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
		PLAYER_XP += 0.5f;
		ES2.Save(PLAYER_XP, "PLAYER_LEVEL_PROGRESS");
		GAME_MANAGER.SHOW_XP = true;
		GAME_MANAGER.IN_MISSION_POINT = false;
		MISSION_COMPLETE_UI.SetActive(value: false);
		MISSION_UI.SetActive(value: false);
		base.gameObject.GetComponent<GAME_MANAGER>().CHECK_MISSIONS();
		base.gameObject.GetComponent<GAME_MANAGER>().HIDE_3D_ICONS();
		base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
	}
}

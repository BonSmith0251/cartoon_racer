using System.Collections;
using UnityEngine;

public class MISSION_TRIGGER : MonoBehaviour
{
	public int INDEX;

	public static int _INDEX;

	public int MONEY;

	public static int _MONEY;

	private bool ENTER;

	public int NEED_LEVEL;

	private void OnEnable()
	{
		if (ES2.Load<int>("MISSION_" + INDEX) == 1 || GAME_MANAGER.PLAYER_LEVEL < NEED_LEVEL)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			Object.FindObjectOfType<GAME_MANAGER>().CHECK_MISSIONS_();
		}
	}

	private void OnTriggerStay(Collider car2)
	{
		if ((car2.tag == "Player") & (RCC_CarControllerV3.SPEED < 15f) & (GAME_MANAGER.IN_RACE_POINT == 0) & !ENTER & !GAME_MANAGER.TAXI_DRIVER & !GAME_MANAGER.MEDIC_DRIVER & !GAME_MANAGER.COP_DRIVER & !GAME_MANAGER.CAR_WATER_ & (GAME_MANAGER.PLAYER_FUEL > 0.1f) & !GAME_MANAGER.IN_MISSION & !GAME_MANAGER.IN_MISSION_POINT)
		{
			_INDEX = INDEX;
			_MONEY = MONEY;
			GAME_MANAGER.IN_MISSION_POINT = true;
			ENTER = true;
			StartCoroutine(DELAY());
		}
	}

	private void OnTriggerExit(Collider car2)
	{
		if (car2.tag == "Player")
		{
			ENTER = false;
			GAME_MANAGER.IN_MISSION_POINT = false;
		}
	}

	private IEnumerator DELAY()
	{
		yield return new WaitForSecondsRealtime(15f);
		ENTER = false;
	}
}
